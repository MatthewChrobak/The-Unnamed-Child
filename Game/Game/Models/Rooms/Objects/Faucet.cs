using System;
using Game.Patterns.Singleton;
using SFML.Audio;
using Game.Sounds;
using System.IO;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Faucet : CollisionObject
    {
        public override bool Probe(float x, float y)
        {
            if (base.Probe(x, y))
            {
                var data = Singleton.Get<DataManager>();
                var sound = Singleton.Get<SoundManager>();

                if (!data.Player.HasBucket)
                {
                    data.CurrentRoom.AddFloatingMessage("I am thirsty, are you Baba yaga..?", x, y - 100, 2500);
                }
                if (data.Player.HasBucket && !data.Player.isBucketFilled)
                {
                    data.CurrentRoom.AddFloatingMessage("Wow! this bucket is getting heavy", x, y - 100, 2500);
                    data.Player.isBucketFilled = true;
                }
                if (data.Player.isBucketFilled && data.Player.HasBucket)
                {
                    data.CurrentRoom.AddFloatingMessage("What could I do with a bucket filled with water...", x, y - 100, 2500);
                }

                //TODO: add bucket/water sound
                SoundBuffer faucet = new SoundBuffer(File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + sound.saucepan));
                Sound m = new Sound(faucet);

                sound.PlaySound(m, 20f);

                sound.StopSound(m, 1000);

            }
            return true;
        }
    }
}
