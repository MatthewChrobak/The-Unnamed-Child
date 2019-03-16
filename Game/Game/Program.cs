using Game.Events;
using Game.Graphics;
using Game.Patterns.Singleton;
using Game.UserInterface;
using Game.UserInterface.Scenes;
using SFML.Window;
using System;
using Game.Sounds;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args) {
            var queue = Singleton.Create<EventQueue>();
            var ui = Singleton.Create<UIManager>();
            var graphics = Singleton.Create<GameWindow>();
            var sound = Singleton.Create<SoundManager>();

            
            //PlaySound or PlayMusic; the second parameter is optional and sets the volume
            queue.AddEvent(PriorityTypes.SOUNDS, () =>
            {
                sound.PlaySound(sound.footstepGrass1, 15f);
                
                return EVENT_RETURN.NONE;
            }, 1000, 0);

            queue.AddEvent(PriorityTypes.SOUNDS, () =>
            {
                sound.PlaySound(sound.footstepGrass2, 0.01f);

            // Placeholder for actual graphics.
            queue.AddEvent(PriorityTypes.GRAPHICS, () => {

                graphics.Draw();
                return EVENT_RETURN.NONE;
            }, 16, 0);
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


            queue.Run();
        }
    }
}
