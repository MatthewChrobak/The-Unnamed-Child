using Game.Graphics;
using Game.Graphics.Contexts;

namespace Game.Models
{
    public class Room : IDrawableObject
    {
        public static Room CurrentRoom = new Room("graphics/sample_room.jpg");

        private SurfaceContext _ctx;
        private string BackgroundImage;

        public Room(string backgroundImage) {
            this.BackgroundImage = backgroundImage;
            this._ctx = new SurfaceContext() {
                Position = (0, 0),
                Size = (GameWindow.WINDOW_WIDTH, GameWindow.WINDOW_HEIGHT)
            };
        }

        public void Draw(IDrawableSurface surface) {
            surface.Draw(this.BackgroundImage, this._ctx);
        }
    }
}
