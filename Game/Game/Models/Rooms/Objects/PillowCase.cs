using Game.Patterns.Singleton;
using Game.Sounds;
using SFML.Audio;
using System;
using System.IO;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class PillowCase : CollisionObject
    {

        public override bool Probe(float x, float y) {
            if (base.Probe(x, y)) {
                var data = Singleton.Get<DataManager>();

                if (data.Player.HasPillowCase) {
                    return true;
                }

                if (!data.Player.HasStones) {
                    data.CurrentRoom.AddFloatingMessage("Maybe I can put something in this.", x, y - 100, 2500);
                } else {
                    data.CurrentRoom.AddFloatingMessage("I can put my stones in here!", x, y - 100, 2500);
                }
                data.Player.HasPillowCase = true;


                var sound = Singleton.Get<SoundManager>();

                SoundBuffer pillowCaseSound = new SoundBuffer(File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + sound.pillowFluff));
                Sound m = new Sound(pillowCaseSound);
                this.SurfaceName = "graphics/apple2.png";

                sound.PlaySound(m);

                sound.StopSound(m, 1000);
            }
            return true;
        }
    }
}
