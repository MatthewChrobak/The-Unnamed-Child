using SFML.Graphics;

namespace Game.Graphics.Contexts
{
    public class TextContext
    {
        public string FontName = "fonts/Dead Font Walking.otf";
        public Color FontColor = Color.Black;
        public int FontSize = 12;

        public (float x, float y) Position;        // Optional

        public float? HorizontalCenter_Width; // Optional
        public float? VerticalCenter_Height; // Optional

        public (float, Color)? Border; // Optional
    }
}
