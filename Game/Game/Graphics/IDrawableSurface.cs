using Game.Graphics.Contexts;

namespace Game.Graphics
{
    public interface IDrawableSurface
    {
        void Draw(string SurfaceName, SurfaceContext cts);
        void Draw(string Text, TextContext ctx);
    }
}
