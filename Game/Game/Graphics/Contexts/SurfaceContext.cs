namespace Game.Graphics.Contexts
{
    public class SurfaceContext
    {
        public (float x, float y) Position;
        public (float x, float y) Size;

        public (int top, int left, int width, int height)? Rect;
    }
}
