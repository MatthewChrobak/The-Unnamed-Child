using Game.Graphics.Content;
using Game.Graphics.Contexts;
using Game.Models;
using Game.Patterns.Singleton;
using Game.UserInterface;
using SFML.Graphics;
using SFML.System;

namespace Game.Graphics
{
    public class GameWindow : Singleton, IDrawableSurface
    {
        private RenderWindow _buffer;
        private TextureManager _textures;
        private FontManager _fonts;

        public GameWindow() {
            this._buffer = new RenderWindow(new SFML.Window.VideoMode(1080, 920), "Nameless Child");
            this._buffer.SetVisible(true);

            _textures = new TextureManager();
            _fonts = new FontManager();

            // TODO: Hookup ui event handlers.
        }

        public void Draw() {
            this._buffer.Clear(Color.Blue);

            this._buffer.DispatchEvents();

            Get<UIManager>().CurrentScene.Draw(this);

            this._buffer.Display();
        }

        public void Draw(string SurfaceName, SurfaceContext ctx) {
            var sprite = _textures.Get(SurfaceName);

            sprite.Position = new Vector2f(ctx.Position.x, ctx.Position.y);

            if (ctx.Rect.HasValue) {
                var rect = ctx.Rect.Value;

                sprite.TextureRect = new IntRect(rect.left, rect.top, rect.width, rect.height);

                sprite.Scale = new Vector2f(
                    ctx.Size.x / rect.width,
                    ctx.Size.y / rect.height
                    );
            } else {
                sprite.Scale = new Vector2f(
                    ctx.Size.x / sprite.Texture.Size.X,
                    ctx.Size.y / sprite.Texture.Size.Y
                    );
            }

            this._buffer.Draw(sprite);
        }

        public void Draw(string strText, TextContext ctx) {
            var font = _fonts.Get(ctx.FontName);

            var text = new Text(strText, font);
            text.Position = new Vector2f(ctx.Position.x, ctx.Position.y);
            text.FillColor = ctx.FontColor;
            text.CharacterSize = (uint)ctx.FontSize;

            if (ctx.HorizontalCenter_Width.HasValue) {
                float hw = ctx.HorizontalCenter_Width.Value;

                float right = text.FindCharacterPos((uint)(strText.Length - 1)).X;
                var previousPos = text.Position;
                text.Position = new Vector2f(previousPos.X + ((hw - right) / 2), previousPos.Y);
            }

            if (ctx.VerticalCenter_Height.HasValue) {
                float vh = ctx.VerticalCenter_Height.Value;

                var previousPos = text.Position;
                float top = previousPos.Y + ((vh - ctx.FontSize) / 2);
                text.Position = new Vector2f(previousPos.X, top);
            }

            this._buffer.Draw(text);
        }
    }
}
