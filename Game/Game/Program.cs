using Game.Events;
using Game.Graphics;
using Game.Models;
using Game.Patterns.Singleton;
using Game.UserInterface;
using Game.UserInterface.Scenes;
using SFML.Window;
using System;
using Game.Sounds;
using Game.Models.Rooms;
using Game.Models.Entities;
using SFML.Audio;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var globals = Singleton.Create<Globals>();
            var queue = Singleton.Create<EventQueue>();
            var data = Singleton.Create<DataManager>();
            var ui = Singleton.Create<UIManager>();
            var graphics = Singleton.Create<GameWindow>();
            var sound = Singleton.Create<SoundManager>();

            ui.LoadScene<MainMenu>();

            //PlaySound or PlayMusic; the second parameter is optional and sets the volume
            //queue.AddEvent(PriorityTypes.SOUNDS, () => {
            //    sound.PlayMusic(sound.mainTheme1Celeste);

            //    return EVENT_RETURN.NONE;
            //}, 35000, 0);


            // Placeholder for actual graphics.
            queue.AddEvent(PriorityTypes.GRAPHICS, () =>
            {
                graphics.Draw();
                return EVENT_RETURN.NONE;
            }, 16, 0);  
            queue.AddEvent(PriorityTypes.ANIMATION, () => {

                data.Player?.UpdateFrame();

                return EVENT_RETURN.NONE;
            }, 50, 0);
            queue.AddEvent(PriorityTypes.INPUT, () => {

                if (globals.DisableMovement) {
                    return EVENT_RETURN.NONE;
                }

                Joystick.Update();
                var scene = Singleton.Get<UIManager>().CurrentScene;


                for (uint i = 0; i < 1; i++)
                {
                    if (Joystick.IsConnected(i))
                    {
                        for (uint ii = 0; ii < (uint)JoystickAxis.LENGTH; ii++)
                        {
                            float position = Joystick.GetAxisPosition(i, (Joystick.Axis)ii);
                            if (Math.Abs(position) >= 5)
                            {
                                scene.JoystickMoved(i, (JoystickAxis)ii, position);
                            }
                        }
                    }
                }


                return EVENT_RETURN.NONE;
            }, 16, 0);


            var rng = new Random();
            bool spawning = false;
            queue.AddEvent(PriorityTypes.INPUT, () => {

            if (!spawning && data.CurrentRoom != null && data.CurrentRoom.GetType() != typeof(FirstRoom)) {
                if (rng.Next(0, 100) < 15) {
                        spawning = true;

                        sound.PlaySound(sound.laughFemale);

                        queue.AddEvent(PriorityTypes.INPUT, () => {
                            BabaYaga.Summon();
                            spawning = false;
                            return EVENT_RETURN.REMOVE_FROM_QUEUE;
                        }, 1, 10000);
                    }
                }
                return EVENT_RETURN.NONE;
            }, 1000, 0);

            queue.Run();

        }
    }
}
