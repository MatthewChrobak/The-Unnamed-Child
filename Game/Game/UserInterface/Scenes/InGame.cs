using Game.Graphics;
using Game.IO;
using Game.Models;
using Game.Models.Rooms;
using Game.Models.Rooms.Objects;
using Game.Patterns.Singleton;
using Game.UserInterface.Components;
using System;

namespace Game.UserInterface.Scenes
{
    public class InGame : Scene
    {
        public InGame() {
            this.OnJoystickButtonPressed += (button) => {
                var data = Singleton.Get<DataManager>();
                var room = data.CurrentRoom;
                var player = data.Player;

                foreach (var child in this.Children) {
                    if (child.OnJoystickButtonPressed != null) {
                        child.OnJoystickButtonPressed(button);
                        break;
                    }
                }

                if (button == JoystickButton.Back) {
                    Singleton.Get<UIManager>().LoadScene<MainMenu>();
                }

#if DEBUG
                if (button == JoystickButton.Y) {
                    Console.Write("Waiting on input: ");
                    string[] cmd = Console.ReadLine().Split(' ');

                    switch (cmd[0]) {
                        case "new": {
                            string roomName = cmd[1];
                            var type = Room.GetRoomType(roomName);
                            object newRoom = Activator.CreateInstance(type);
                            XML.Serialize(Room.GetPath(roomName), newRoom, type);
                            data.LoadRoom(roomName);
                            break;
                        }
                        case "save": {
                            string roomName = cmd[1];
                            XML.Serialize(Room.GetPath(cmd[1]), room, room.GetType());
                            Console.WriteLine("Saved room.");
                            break;
                        }
                        case "load": {
                            string roomName = cmd[1];
                            data.LoadRoom(roomName);
                            break;
                        }
                        case "setbackground":
                            room.BackgroundImage = cmd[1];
                            break;
                        case "setbounds":
                            float lb = float.Parse(cmd[1]);
                            float ub = float.Parse(cmd[2]);
                            room.Bounds = (lb, ub);
                            break;
                        case "debug":
                            Console.WriteLine(player.X + " " + player.Y);
                            break;
                        case "newobj": {
                            string typeName = "Game.Models.Rooms.Objects." + cmd[1];
                            Type type = Type.GetType(typeName);
                            var obj = (CollisionObject)Activator.CreateInstance(type);
                            obj.SurfaceName = cmd[2];
                            obj.Position = (player.X, player.Y);
                            obj.Size = (player.Width, player.Height);

                            obj.HandleAdditionalParamsForCreation(cmd);

                            room.AddCollisionObject(obj);
                            break;
                        }
                    }
                }
#endif

                if (button == JoystickButton.A) {
                    for (int i =0; i <room.Objects.Count; i++) {
                        var obj = room.Objects[i];
                        obj?.Probe(player.X + player.Width / 2, player.Y + player.Height / 2);
                    }
                }

            };
        }

        public override void Draw(IDrawableSurface surface) {
            var data = Singleton.Get<DataManager>();
            data.CurrentRoom.Draw(surface);
            data.Player.Draw(surface);
            base.Draw(surface);
        }

        public override void JoystickMoved(uint joystickID, JoystickAxis axis, float position) {
            switch (axis) {
                case JoystickAxis.X:
                case JoystickAxis.Y:
                    Singleton.Get<DataManager>().CurrentRoom.HandleJoystickMoved(joystickID, axis, position);
                    break;
            }
        }
    }
}
