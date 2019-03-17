using Game.Events;
using Game.Graphics;
using Game.Graphics.Contexts;
using Game.Models.Rooms.Objects;
using Game.Patterns.Singleton;
using Game.UserInterface;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Game.Models.Rooms
{
    [XmlInclude(typeof(Door))]
    [XmlInclude(typeof(Stone))]
    [XmlInclude(typeof(PillowCase))]
    [XmlInclude(typeof(Cloth))]
    [XmlInclude(typeof(Apron))]

    [Serializable]
    public abstract class Room : IDrawableObject
    {
        private SurfaceContext _ctx;
        public string BackgroundImage;
        public (float x, float y) Size;
        public float Player_Y_Height;

        public List<CollisionObject> Objects;

        [XmlIgnore]
        private List<(string, float, float)?> _messages;

        public void AddCollisionObject(CollisionObject obj) {
            obj.ItemID = Objects.Count;
            obj.RefreshContext();
            Objects.Add(obj);
        }

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
            _messages = new List<(string, float, float)?>();
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
                obj?.Draw(surface);
            }

            foreach (var message in this._messages) {
                if (message == null) {
                    continue;
                }
                var ctx = new TextContext() {
                    FontColor = Color.White,
                    HorizontalCenter_Width = 1,
                    Position = (message.Value.Item2, message.Value.Item3),
                    FontSize = 24,
                    VerticalCenter_Height = 1,
                    Border = (25f, new Color(50, 50, 50))
                };
                surface.Draw(message.Value.Item1, ctx);
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

        public void AddFloatingMessage(string str_message, float x, float y, int duration) {
            var queue = Singleton.Get<EventQueue>();

            int count = duration / 100;
            int index = _messages.Count;
            for (int i = 0; i < _messages.Count; i++) {
                if (_messages[i] == null) {
                    index = i;
                    break;
                }
            }
            _messages.Add((str_message, x, y));

            queue.AddEvent(PriorityTypes.ANIMATION, () => {
                var msg = _messages[index].Value;
                _messages[index] = (msg.Item1, msg.Item2, msg.Item3 - 1.5f);
                count--;

                if (count == 0) {
                    _messages[index] = null;
                    return EVENT_RETURN.REMOVE_FROM_QUEUE;
                } else {
                    return EVENT_RETURN.NONE;
                }

            }, 100, 0);
        }

        public virtual float GetBabaYagaScalingConstant() {
            return 1;
        }

        public virtual float GetBabaYagaStartXConstant() {
            return 0;
        }

        public virtual float GetBabaYagaStartYConstant() {
            return 0; 
        }
    }
}
