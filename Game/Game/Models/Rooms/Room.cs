using Game.Graphics;
using Game.Graphics.Contexts;
using Game.Models.Rooms.Objects;
using Game.Patterns.Singleton;
using Game.UserInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Game.Models.Rooms
{
    [XmlInclude(typeof(Door))]
    [Serializable]
    public abstract class Room : IDrawableObject
    {
        private SurfaceContext _ctx;
        public string BackgroundImage;
        public (float x, float y) Size;
        public float Player_Y_Height;

        public List<CollisionObject> Objects;

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
            Objects = new List<CollisionObject>();
            Size = (GameWindow.WINDOW_WIDTH, GameWindow.WINDOW_HEIGHT);
            RefreshContext();
        }

        public virtual float AdjustSpeed(float position) {
            if (Math.Abs(position) < 1) {
                return 0;
            }
            return position;
        }

        public void RefreshContext() {
            this._ctx = new SurfaceContext() {
                Position = (0, 0),
                Size = (Size.x, Size.y)
            };
        }

        public void Draw(IDrawableSurface surface) {
            surface.Draw(this.BackgroundImage, this._ctx);

            foreach (var obj in this.Objects) {
                obj.Draw(surface);
            }
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
