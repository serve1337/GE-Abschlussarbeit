﻿using System;
using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using static Fusee.Engine.Core.Input;
using static Fusee.Engine.Core.Time;
using Fusee.Engine.Core.GUI;

namespace Fusee.Engine.SceneViewer.Core
{

    [FuseeApplication(Name = "FUSEE SceneViewer", Description = "Watch any FUSEE scene.")]
    public class SceneViewer : RenderCanvas
    {
        // angle variables
        private static float _angleHorz = M.PiOver6*2.0f, _angleVert = -M.PiOver6*0.5f,
                             _angleVelHorz, _angleVelVert, _angleRoll, _angleRollInit, _zoomVel, _zoom;
        private static float2 _offset;
        private static float2 _offsetInit;

        private const float RotationSpeed = 7;
        private const float Damping = 0.8f;

        private SceneContainer _scene;
        private SceneRenderer _sceneRenderer;
        private float4x4 _sceneCenter;
        private float4x4 _sceneScale;
        private float4x4 _projection;
        private bool _twoTouchRepeated;

        private bool _keys;

        private GUIHandler _guiHandler;

        private GUIButton _guiFuseeLink;
        private GUIImage _guiFuseeLogo;
        private FontMap _guiLatoBlack;
        private GUIText _guiSubText;
        private float _subtextHeight;
        private float _subtextWidth;
        private float _maxPinchSpeed;

        // Init is called on startup. 
        public override void Init()
        {
            _guiHandler = new GUIHandler();
            _guiHandler.AttachToContext(RC);

            _guiFuseeLink = new GUIButton(6, 6, 157, 87);
            _guiFuseeLink.ButtonColor = new float4(0, 0, 0, 0);
            _guiFuseeLink.BorderColor = new float4(0, 0.6f, 0.2f, 1);
            _guiFuseeLink.BorderWidth = 0;
            _guiFuseeLink.OnGUIButtonDown += _guiFuseeLink_OnGUIButtonDown;
            _guiFuseeLink.OnGUIButtonEnter += _guiFuseeLink_OnGUIButtonEnter;
            _guiFuseeLink.OnGUIButtonLeave += _guiFuseeLink_OnGUIButtonLeave;
            _guiHandler.Add(_guiFuseeLink);
            _guiFuseeLogo = new GUIImage(AssetStorage.Get<ImageData>("FuseeLogo150.png"), 10, 10, -5, 150, 80);
            _guiHandler.Add(_guiFuseeLogo);
            var fontLato = AssetStorage.Get<Font>("Lato-Black.ttf");
            fontLato.UseKerning = true;
            _guiLatoBlack = new FontMap(fontLato, 18);
            _guiSubText = new GUIText("Simple FUSEE Example", _guiLatoBlack, 100, 100);
            _guiSubText.TextColor = new float4(0.05f, 0.25f, 0.15f, 0.8f);
            _guiHandler.Add(_guiSubText);
            _subtextWidth = GUIText.GetTextWidth(_guiSubText.Text, _guiLatoBlack);
            _subtextHeight = GUIText.GetTextHeight(_guiSubText.Text, _guiLatoBlack);

            // Initial "Zoom" value (it's rather the distance in view direction, not the camera's focal distance/opening angle)
            _zoom = 400;

            _angleRoll = 0;
            _angleRollInit = 0;
            _twoTouchRepeated = false;
            _offset = float2.Zero;
            _offsetInit = float2.Zero;

            // Set the clear color for the backbuffer to white (100% intentsity in all color channels R, G, B, A).
            RC.ClearColor = new float4(1, 1, 1, 1);

            // Load the standard model
            _scene = AssetStorage.Get<SceneContainer>("Model.fus");
            AABBCalculator aabbc = new AABBCalculator(_scene);
            var bbox = aabbc.GetBox();
            if (bbox != null)
            {
                // If the model origin is more than one third away from its bounding box, 
                // recenter it to the bounding box. Do this check individually per dimension.
                // This way, small deviations will keep the model's original center, while big deviations 
                // will make the model rotating around its geometric center.
                float3 bbCenter = bbox.Value.Center;
                float3 bbSize = bbox.Value.Size;
                float3 center = float3.Zero;
                if (System.Math.Abs(bbCenter.x) > bbSize.x*0.3)
                    center.x = bbCenter.x;
                if (System.Math.Abs(bbCenter.y) > bbSize.y * 0.3)
                    center.y = bbCenter.y;
                if (System.Math.Abs(bbCenter.z) > bbSize.z * 0.3)
                    center.z = bbCenter.z;
                _sceneCenter = float4x4.CreateTranslation(-center);

                // Adjust the model size
                float maxScale = System.Math.Max(bbSize.x, System.Math.Max(bbSize.y, bbSize.z));
                if (maxScale != 0)
                    _sceneScale = float4x4.CreateScale(200.0f / maxScale);
                else
                    _sceneScale = float4x4.Identity;
            }
            // Wrap a SceneRenderer around the model.
            _sceneRenderer = new SceneRenderer(_scene);

            // Initialize the information text line.
            _guiSubText.Text = "FUSEE 3D Scene";
            if (_scene.Header.CreatedBy != null || _scene.Header.CreationDate != null)
            {
                _guiSubText.Text += " created";
                if (_scene.Header.CreatedBy != null)
                    _guiSubText.Text += " by " + _scene.Header.CreatedBy;

                if (_scene.Header.CreationDate != null)
                    _guiSubText.Text += " on " + _scene.Header.CreationDate;
            }
            // _guiSubText.Text = "dT: xxx ms, W: xxxx, H: xxxx, PS: xxxxxxxx";
            _subtextWidth = GUIText.GetTextWidth(_guiSubText.Text, _guiLatoBlack);
            _subtextHeight = GUIText.GetTextHeight(_guiSubText.Text, _guiLatoBlack);
        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
            // _guiSubText.Text = $"dt: {DeltaTime} ms, W: {Width}, H: {Height}, PS: {_maxPinchSpeed}";
            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            // Mouse and keyboard movement
            if (Keyboard.LeftRightAxis != 0 || Keyboard.UpDownAxis != 0)
            {
                _keys = true;
            }

            var curDamp = (float)System.Math.Exp(-Damping * DeltaTime);

            // Zoom & Roll
            if (Touch.TwoPoint)
            {
                if (!_twoTouchRepeated)
                {
                    _twoTouchRepeated = true;
                    _angleRollInit = Touch.TwoPointAngle - _angleRoll;
                    _offsetInit = Touch.TwoPointMidPoint - _offset;
                    _maxPinchSpeed = 0;
                }
                _zoomVel = Touch.TwoPointDistanceVel*-0.01f;
                _angleRoll = Touch.TwoPointAngle - _angleRollInit;
                _offset = Touch.TwoPointMidPoint - _offsetInit;
                float pinchSpeed = Touch.TwoPointDistanceVel;
                if (pinchSpeed > _maxPinchSpeed) _maxPinchSpeed = pinchSpeed; // _maxPinchSpeed is used for debugging only.
            }
            else
            {
                _twoTouchRepeated = false;
                _zoomVel = Mouse.WheelVel * -0.5f;
                _angleRoll *= curDamp*0.8f;
                _offset *= curDamp*0.8f;
            }

            // UpDown / LeftRight rotation
            if (Mouse.LeftButton)
            {
                _keys = false;
                _angleVelHorz = -RotationSpeed * Mouse.XVel * 0.000002f;
                _angleVelVert = -RotationSpeed * Mouse.YVel * 0.000002f;
            }
            else if (Touch.GetTouchActive(TouchPoints.Touchpoint_0) && !Touch.TwoPoint)
            {
                _keys = false;
                float2 touchVel;
                touchVel = Touch.GetVelocity(TouchPoints.Touchpoint_0);
                _angleVelHorz = -RotationSpeed * touchVel.x * 0.000002f;
                _angleVelVert = -RotationSpeed * touchVel.y * 0.000002f;
            }
            else
            {
                if (_keys)
                {
                    _angleVelHorz = -RotationSpeed * Keyboard.LeftRightAxis * 0.002f;
                    _angleVelVert = -RotationSpeed * Keyboard.UpDownAxis * 0.002f;
                }
                else
                {
                    _angleVelHorz *= curDamp;
                    _angleVelVert *= curDamp;
                }
            }

            _zoom += _zoomVel;
            // Limit zoom
            if (_zoom < 80)
                _zoom = 80;
            if (_zoom > 2000)
                _zoom = 2000;

            _angleHorz += _angleVelHorz;
            // Wrap-around to keep _angleHorz between -PI and + PI
            _angleHorz = M.MinAngle(_angleHorz);

            _angleVert += _angleVelVert;
            // Limit pitch to the range between [-PI/2, + PI/2]
            _angleVert = M.Clamp(_angleVert, -M.PiOver2, M.PiOver2);

            // Wrap-around to keep _angleRoll between -PI and + PI
            _angleRoll = M.MinAngle(_angleRoll);


            // Create the camera matrix and set it as the current ModelView transformation
            var mtxRot = float4x4.CreateRotationZ(_angleRoll) * float4x4.CreateRotationX(_angleVert) * float4x4.CreateRotationY(_angleHorz);
            var mtxCam = float4x4.LookAt(0, 20, -_zoom, 0, 0, 0, 0, 1, 0);
            RC.ModelView = mtxCam * mtxRot * _sceneScale * _sceneCenter;
            var mtxOffset = float4x4.CreateTranslation(2 * _offset.x / Width, - 2 * _offset.y / Height, 0);
            RC.Projection = mtxOffset * _projection;

            // Tick any animations and Render the scene loaded in Init()
            _sceneRenderer.Animate();
            _sceneRenderer.Render(RC);

            _guiHandler.RenderGUI();

            // Swap buffers: Show the contents of the backbuffer (containing the currently rerndered farame) on the front buffer.
            Present();
        }

        private InputDevice Creator(IInputDeviceImp device)
        {
            throw new NotImplementedException();
        }

        // Is called when the window was resized
        public override void Resize()
        {
            // Set the new rendering area to the entire new windows size
            RC.Viewport(0, 0, Width, Height);

            // Create a new projection matrix generating undistorted images on the new aspect ratio.
            var aspectRatio = Width/(float) Height;

            // 0.25*PI Rad -> 45° Opening angle along the vertical direction. Horizontal opening angle is calculated based on the aspect ratio
            // Front clipping happens at 1 (Objects nearer than 1 world unit get clipped)
            // Back clipping happens at 2000 (Anything further away from the camera than 2000 world units gets clipped, polygons will be cut)
            _projection = float4x4.CreatePerspectiveFieldOfView(M.PiOver4, aspectRatio, 1, 20000);

            _guiSubText.PosX = (int)((Width - _subtextWidth) / 2);
            _guiSubText.PosY = (int)(Height - _subtextHeight - 3);

            _guiHandler.Refresh();
        }

        private void _guiFuseeLink_OnGUIButtonLeave(GUIButton sender, GUIButtonEventArgs mea)
        {
            _guiFuseeLink.ButtonColor = new float4(0, 0, 0, 0);
            _guiFuseeLink.BorderWidth = 0;
            SetCursor(CursorType.Standard);
        }

        private void _guiFuseeLink_OnGUIButtonEnter(GUIButton sender, GUIButtonEventArgs mea)
        {
            _guiFuseeLink.ButtonColor = new float4(0, 0.6f, 0.2f, 0.4f);
            _guiFuseeLink.BorderWidth = 1;
            SetCursor(CursorType.Hand);
        }

        void _guiFuseeLink_OnGUIButtonDown(GUIButton sender, GUIButtonEventArgs mea)
        {
            OpenLink("http://fusee3d.org");
        }
    }
}