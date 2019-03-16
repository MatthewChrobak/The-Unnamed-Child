using Game.Graphics;
using Game.Graphics.Contexts;

namespace Game.Models
{
    public class Foo : IDrawableObject
    {
        private SurfaceContext _ctx;

        public Foo() {
            this._ctx = new SurfaceContext();

            _ctx.Position = (100, 100);
            _ctx.Rect = (0, 0, 25, 25);
            _ctx.Size = (100, 100);
        }

        public void Draw(IDrawableSurface surface) {
            surface.Draw("graphics/test.png", this._ctx);
        }
    }

    public class Foo2 : IDrawableObject
    {
        private SurfaceContext _ctx;

        public Foo2() {
            this._ctx = new SurfaceContext();

            _ctx.Position = (300, 300);
            _ctx.Rect = (10, 10, 25, 25);
            _ctx.Size = (50, 50);
        }

        public void Draw(IDrawableSurface surface) {
            surface.Draw("graphics/test.png", this._ctx);
        }
    }
}
