using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Apron : CollisionObject
    {
        public override bool Probe(float x, float y) {
            if (base.Probe(x, y)) {
                var data = Singleton.Get<DataManager>();

                if (!data.Player.HasBroom) {
                    data.CurrentRoom.AddFloatingMessage("I can't reach that!", x, y - 100, 3000);
                    return true;
                }

                //// Set = null to avoid
                data.Player.HasApron = true;
                data.CurrentRoom.Objects[this.ItemID] = null;

                data.CurrentRoom.AddFloatingMessage("I can parachute out with this!", x, y - 100, 3000);
                return true;
            }
            return false;
        }
    }
}
