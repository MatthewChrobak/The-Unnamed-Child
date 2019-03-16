using Game.Graphics.Content;
using Game.Graphics.Contexts;
using Game.Models;
using Game.Patterns.Singleton;
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

            // TODO: Draw game data on the current scene.

            new Foo().Draw(this);
            new Foo2().Draw(this);

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
            }

            this._buffer.Draw(sprite);
        }

        public void Draw(string FontName, TextContext ctx) {
            var font = _fonts.Get(FontName);
        }
    }
}
