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

                // Set = null to avoid
                //data.CurrentRoom.Objects[this.ItemID] = null;
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
