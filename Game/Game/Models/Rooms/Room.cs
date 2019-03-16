using Game.Graphics;
using Game.Graphics.Contexts;
using Game.Patterns.Singleton;
using Game.UserInterface;
using System;
using System.IO;

namespace Game.Models.Rooms
{
    [Serializable]
    public abstract class Room : IDrawableObject
    {
        private SurfaceContext _ctx;
        public string BackgroundImage;
        public (float x, float y) Size;
        public float Player_Y_Height;

        public (float lb, float ub) Bounds;

        static Room() {
            Directory.CreateDirectory("rooms/");
        }

        public static string GetPath(string roomName) {
            return $"rooms/{roomName}.xml";
        }

        public static Type GetRoomType(string roomName) {
            return Type.GetType("Game.Models.Rooms." + roomName);
        }

        public Room() {
            Size = (GameWindow.WINDOW_WIDTH, GameWindow.WINDOW_HEIGHT);
            RefreshContext();
        }

        public void RefreshContext() {
            this._ctx = new SurfaceContext() {
                Position = (0, 0),
                Size = (Size.x, Size.y)
            };
        }

        public void Draw(IDrawableSurface surface) {
            surface.Draw(this.BackgroundImage, this._ctx);
        }

        public virtual void HandleJoystickMoved(uint joystickID, JoystickAxis axis, float position) {
            switch (axis) {
                case JoystickAxis.X:
                case JoystickAxis.Y:
                    Singleton.Get<DataManager>().Player.HandleMove(axis, position);
                    break;
            }
        }

        public virtual void OnEnter() {

        }

        public virtual void OnLeave() {

        }

        public virtual (float x, float y) CheckBounds(float x, float y) {
            if (x < Bounds.lb) {
                return (Bounds.lb, Player_Y_Height);
            } else if (x > Bounds.ub) {
                return (Bounds.ub, Player_Y_Height);
            } else {
                return (x, Player_Y_Height);
            }
        }
    }
}
