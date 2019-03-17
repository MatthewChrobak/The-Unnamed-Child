using System;
using Game.Patterns.Singleton;
using SFML.Audio;
using Game.Sounds;
using System.IO;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Bucket : CollisionObject
    {
        public override bool Probe(float x, float y)
        {
            if (base.Probe(x, y))
            {
                var data = Singleton.Get<DataManager>();

                if (!data.Player.HasBucket)
                {
                    data.CurrentRoom.AddFloatingMessage("Interesting...", x - 115, y - 100, 2500);
                }
                if (data.Player.HasBucket)
                {
                    data.CurrentRoom.AddFloatingMessage("What can I do with this bucket...", x - 115, y - 100, 2500);
                }

                data.Player.HasBucket = true;

                var sound = Singleton.Get<SoundManager>();

                //TODO: add bucket sound
                SoundBuffer bucket = new SoundBuffer(File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + sound.saucepan));
                Sound m = new Sound(bucket);
                this.SurfaceName = "graphics/bucket_used.png";

                sound.PlaySound(m, 20f);

                sound.StopSound(m, 1000);

            }
            return true;
        }
    }
}
