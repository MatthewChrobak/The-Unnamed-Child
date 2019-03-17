using Game.Events;
using Game.Graphics;
using Game.Models;
using Game.Patterns.Singleton;
using Game.UserInterface;
using Game.UserInterface.Scenes;
using SFML.Window;
using System;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args) {
            var queue = Singleton.Create<EventQueue>();
            var data = Singleton.Create<DataManager>();
            var ui = Singleton.Create<UIManager>();
            var graphics = Singleton.Create<GameWindow>();

            ui.LoadScene<MainMenu>();

            // Placeholder for actual graphics.
            queue.AddEvent(PriorityTypes.GRAPHICS, () => {

                graphics.Draw();

                return EVENT_RETURN.NONE;
            }, 16, 0);
            queue.AddEvent(PriorityTypes.ANIMATION, () => {

                data.Player?.UpdateFrame();

                return EVENT_RETURN.NONE;
            }, 50, 0);
            queue.AddEvent(PriorityTypes.INPUT, () => {

                Joystick.Update();
                var scene = Singleton.Get<UIManager>().CurrentScene;

                for (uint i = 0; i < 1; i++) {
                    if (Joystick.IsConnected(i)) {
                        for (uint ii = 0; ii < (uint)JoystickAxis.LENGTH; ii++) {
                            float position = Joystick.GetAxisPosition(i, (Joystick.Axis)ii);
                            if (Math.Abs(position) >= 5) {
                                scene.JoystickMoved(i, (JoystickAxis)ii, position);
                            }
                        }
                    }
                }

                return EVENT_RETURN.NONE;
            }, 16, 0);

            queue.Run();
        }
    }
}
