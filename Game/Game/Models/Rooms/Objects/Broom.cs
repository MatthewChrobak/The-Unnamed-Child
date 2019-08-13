
using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Broom : CollisionObject
    {
        public override bool Probe(float x, float y) {

            if (base.Probe(x, y)) {

                var data = Singleton.Get<DataManager>();

                data.Player.HasBroom = true;

                data.CurrentRoom.AddFloatingMessage("Now I can reach those things!", x, y - 100, 3000);

                data.CurrentRoom.Objects[this.ItemID] = null;
                return true;
            }
            return false;
        }
    }
}
