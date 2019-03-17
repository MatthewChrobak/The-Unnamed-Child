using System;
using Game.Patterns.Singleton;
using SFML.Audio;
using Game.Sounds;
using System.IO;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Stone : CollisionObject
    {
        public override bool Probe(float x, float y)
        {
            if (base.Probe(x, y))
            {
                var data = Singleton.Get<DataManager>();

                // Set = null to avoid
                //data.CurrentRoom.Objects[this.ItemID] = null;

                var sound = Singleton.Get<SoundManager>();

                SoundBuffer pillowCaseSound = new SoundBuffer(File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + sound.stoneFall));
                Sound m = new Sound(pillowCaseSound);
                this.SurfaceName = "graphics/room1_used_trash.png";

                sound.PlaySound(m, 20f);

                sound.StopSound(m, 1000);
                
            }
            return true;
        }
    }
}
