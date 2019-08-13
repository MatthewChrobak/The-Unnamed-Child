using Game.Patterns.Singleton;
using Game.Sounds;
using SFML.Audio;
using System;
using System.IO;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Umbrella : CollisionObject
    {

        public override bool Probe(float x, float y) {
            if (base.Probe(x, y)) {
                var data = Singleton.Get<DataManager>();

                data.Player.HasUmbrella = true;
                data.CurrentRoom.AddFloatingMessage("You found an umbrella.", x, y - 100, 3000);

                data.CurrentRoom.Objects[this.ItemID] = null;
                return true;
            }
            return false;
        }

        public void reposition() {

        }
    }
}
