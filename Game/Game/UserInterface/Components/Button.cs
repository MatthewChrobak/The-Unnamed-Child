using Game.Graphics;
using Game.Graphics.Contexts;

namespace Game.UserInterface.Components
{
    public class Button : UIElement
    {
        public SurfaceContext ctxSurface;
        public TextContext ctxText;
        public string TextureName;

        public string Text;

        public override void Draw(IDrawableSurface surface) {
            if (!string.IsNullOrEmpty(this.TextureName)) {
                surface.Draw(this.TextureName, this.ctxSurface);
            }

            if (!string.IsNullOrEmpty(this.Text)) {
                surface.Draw(this.Text, this.ctxText);
            }
        }
    }
}
