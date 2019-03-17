using System;
using Game.Patterns.Singleton;
using SFML.Audio;
using Game.Sounds;
using System.IO;
using Game.Events;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Crack : CollisionObject
    {
        public override bool Probe(float x, float y)
        {
            if (base.Probe(x, y))
            {
                var data = Singleton.Get<DataManager>();
                var sound = Singleton.Get<SoundManager>();
                var queue = Singleton.Get<EventQueue>();


                if (!data.Player.TouchedCrack)
                {
                    data.CurrentRoom.AddFloatingMessage("Whoa! What just happened..?", x, y - 100, 2500);

                    // Originally 875s
                    data.CurrentRoom.Bounds = (data.CurrentRoom.Bounds.lb, 300);

                    var birds = (Birds)data.CurrentRoom.Objects[3];

                    if (birds != null)
                    {
                        birds.SurfaceName = "graphics/crow sheet merged.png";
                    }

                    queue.AddEvent(PriorityTypes.ANIMATION, () =>
                    {

                        birds?.Update();

                        if (birds == null)
                        {
                            return EVENT_RETURN.REMOVE_FROM_QUEUE;
                        }

                        return EVENT_RETURN.NONE;
                    }, 100, 0);


                    data.Player.TouchedCrack = true;
                    return true;
                }
                else
                {
                    data.CurrentRoom.AddFloatingMessage("There is nothing inside this", x, y - 100, 2500);

                }

                

                SoundBuffer pillowCaseSound = new SoundBuffer(File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + sound.stoneFall));
                Sound m = new Sound(pillowCaseSound);
                this.SurfaceName = "graphics/crack 2.png";

                sound.PlaySound(m, 20f);

                sound.StopSound(m, 1000);

            }
            return true;
        }
    }
}
