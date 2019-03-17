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
                var sound = Singleton.Get<SoundManager>();

                if (data.Player.HasStones) {
                    return true;
                }

                if (!data.Player.HasPillowCase) {
                    data.CurrentRoom.AddFloatingMessage("Maybe I can use these to break the door handle...", x, y - 100, 2500);
                } else {
                    data.CurrentRoom.AddFloatingMessage("I can put these in my pillowcase!", x, y - 100, 2500);
                }
                data.Player.HasStones = true;

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
