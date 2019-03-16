using System;
using Game.Graphics;
using Game.Graphics.Contexts;
using Game.Models.Entities;
using Game.UserInterface;

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
                Position = (50, 50),
                Size = (GameWindow.WINDOW_WIDTH - 100, GameWindow.WINDOW_HEIGHT - 100)
            };
        }

        public void Draw(IDrawableSurface surface) {
            surface.Draw(this.BackgroundImage, this._ctx);
        }

        public void HandleJoystickMoved(uint joystickID, JoystickAxis axis, float position) {
            switch (axis) {
                case JoystickAxis.X:
                case JoystickAxis.Y:
                    Player.CurrentPlayer.HandleMove(axis, position);
                    break;
            }
        }
    }
}
