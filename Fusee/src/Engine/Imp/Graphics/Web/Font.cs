// The only purpose of these implementations are to be cross-compiled with JSIL. 
// Implementations of class elemets can be found in handcoded .js files.

using Fusee.Engine.Common;
using JSIL.Meta;

namespace Fusee.Engine.Imp.Graphics.Web
{
    internal class Font : IFont
    {
        public ITexture TexAtlas { get; internal set; }

        public int Width { get; internal set; }

        public int Height { get; internal set; }

        public uint FontSize { get; internal set; }

        public bool UseKerning { get; set; }

        public CharInfoStruct[] CharInfo { get; internal set; }
    }
}