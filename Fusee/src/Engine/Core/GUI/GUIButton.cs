﻿using System;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Math.Core;

namespace Fusee.Engine.Core.GUI
{
    /// <summary>
    ///     A delegation for the event listeners of a <see cref="GUIButton" />.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="mea">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    public delegate void GUIButtonHandler(GUIButton sender, GUIButtonEventArgs ea);

    /// <summary>
    /// Better than nothing.
    /// </summary>
    public class GUIButtonEventArgs
    {
        public int mouseX;
        public int mouseY;
    }

    /// <summary>
    ///     The <see cref="GUIButton" /> class provides functionality for creating 2D/GUI buttons.
    /// </summary>
    /// <remarks>
    ///     A <see cref="GUIButton" /> doesn't need to have a text on it. It can be modified to be a rectangle with
    ///     an event listener by making its background color transparent and setting a border width of 1 or greater.
    /// </remarks>
    public sealed class GUIButton : GUIElement
    {
        #region Private Fields

        private float4 _buttonColor;

        private int _borderWidth;
        private float4 _borderColor;

        private bool _mouseOnButton;

        #endregion

        #region Public Fields

        /// <summary>
        ///     Gets or sets the color of the button.
        /// </summary>
        /// <value>
        ///     The color of the button.
        /// </value>
        public float4 ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                Dirty = true;
            }
        }

        /// <summary>
        ///     Gets or sets the width of the border.
        /// </summary>
        /// <value>
        ///     The width of the border.
        /// </value>
        public int BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                Dirty = true;
            }
        }

        /// <summary>
        ///     Gets or sets the color of the border.
        /// </summary>
        /// <value>
        ///     The color of the border.
        /// </value>
        public float4 BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Dirty = true;
            }
        }

        /// <summary>
        ///     Occurs when mouse button is pressed on this button.
        /// </summary>
        public event GUIButtonHandler OnGUIButtonDown;

        /// <summary>
        ///     Occurs when mouse button is released on this button.
        /// </summary>
        public event GUIButtonHandler OnGUIButtonUp;

        /// <summary>
        ///     Occurs when the mouse cursor enters this button.
        /// </summary>
        public event GUIButtonHandler OnGUIButtonEnter;

        /// <summary>
        ///     Occurs when the mouse cursor leaves this button.
        /// </summary>
        public event GUIButtonHandler OnGUIButtonLeave;

        #endregion

        /// <summary>
        ///     Initializes a new instance of the <see cref="GUIButton" /> class.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public GUIButton(int x, int y, int width, int height)
            : base(String.Empty, null, x, y, 0, width, height)
        {
            SetupButton();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GUIButton" /> class.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="z">The z-index.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <remarks>
        ///     The z-index: lower values means further away. If two elements have the same z-index
        ///     then they are rendered according to their order in the <see cref="GUIHandler" />.
        /// </remarks>
        public GUIButton(int x, int y, int z, int width, int height)
            : base(String.Empty, null, x, y, z, width, height)
        {
            SetupButton();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GUIButton" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="fontMap">The font map.</param>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public GUIButton(string text, FontMap fontMap, int x, int y, int width, int height)
            : base(text, fontMap, x, y, 0, width, height)
        {
            SetupButton();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GUIButton" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="fontMap">The font map.</param>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="z">The z-index.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <remarks>
        /// The z-index: lower values means further away. If two elements have the same z-index
        /// then they are rendered according to their order in the <see cref="GUIHandler" />.
        /// </remarks>
        public GUIButton(string text, FontMap fontMap, int x, int y, int z, int width, int height)
            : base(text, fontMap, x, y, z, width, height)
        {
            SetupButton();
        }

        private void SetupButton()
        {
            // settings
            ButtonColor = new float4(1, 1, 1, 1);
            TextColor = new float4(0, 0, 0, 1);

            BorderWidth = 1;
            BorderColor = new float4(0, 0, 0, 1);

            // event listener
            if (Input.Mouse != null)
            {
                Input.Mouse.ButtonValueChanged += OnMouseButton;
                Input.Mouse.AxisValueChanged += OnMouseMove;
            }
            if (Input.Touch != null)
            {
                Input.Touch.ButtonValueChanged += OnMouseButton;
                Input.Touch.AxisValueChanged += OnMouseMove;
            }

            _mouseOnButton = false;

            // shader
            CreateGUIShader();
        }

        protected internal override void DetachFromContext()
        {
            base.DetachFromContext();
            if (Input.Mouse != null)
            {
                Input.Mouse.ButtonValueChanged -= OnMouseButton;
                Input.Mouse.AxisValueChanged -= OnMouseMove;
            }
            if (Input.Touch != null)
            {
                Input.Touch.ButtonValueChanged -= OnMouseButton;
                Input.Touch.AxisValueChanged -= OnMouseMove;
            }
        }

        protected override void CreateMesh()
        {
            // GUIMesh
            SetRectangleMesh(BorderWidth, ButtonColor, BorderColor);

            // TextMesh
            var x = PosX + OffsetX;
            var y = PosY + OffsetY;

            var maxW = GUIText.GetTextWidth(Text, FontMap);
            x = (int) System.Math.Round(x + (Width - maxW)/2);

            var maxH = GUIText.GetTextHeight(Text, FontMap);
            y = (int) System.Math.Round(y + maxH + (Height - maxH)/2);

            SetTextMesh(x, y);
        }

        private bool MouseOnButton()
        {
            int x = Input.Mouse.PositionInt.x;
            int y = Input.Mouse.PositionInt.y;
            return x >= PosX + OffsetX &&
                   x <= PosX + OffsetX + Width &&
                   y >= PosY + OffsetY &&
                   y <= PosY + OffsetY + Height;
        }

        private void OnMouseButton(object sender, ButtonValueChangedArgs bvca)
        {
            if (MouseOnButton())
                if (bvca.Pressed)
                    OnGUIButtonDown?.Invoke(this, new GUIButtonEventArgs { mouseX = Input.Mouse.PositionInt.x , mouseY = Input.Mouse.PositionInt.y });
                else
                    OnGUIButtonUp?.Invoke(this, new GUIButtonEventArgs { mouseX = Input.Mouse.PositionInt.x, mouseY = Input.Mouse.PositionInt.y });
        }

        private void OnMouseMove(object sender, AxisValueChangedArgs bvca)
        {
            if (MouseOnButton())
            {
                if (_mouseOnButton) return;
                _mouseOnButton = true;

                if (OnGUIButtonEnter == null) return;
                OnGUIButtonEnter(this, new GUIButtonEventArgs { mouseX = Input.Mouse.PositionInt.x, mouseY = Input.Mouse.PositionInt.y });
            }
            else
            {
                if (!_mouseOnButton) return;
                _mouseOnButton = false;

                if (OnGUIButtonLeave == null) return;
                OnGUIButtonLeave(this, new GUIButtonEventArgs { mouseX = Input.Mouse.PositionInt.x, mouseY = Input.Mouse.PositionInt.y });
            }
        }
    }
}