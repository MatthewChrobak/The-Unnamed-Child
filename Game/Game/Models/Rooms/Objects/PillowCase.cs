using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class PillowCase : CollisionObject
    {
        public override bool Probe(float x, float y) {
            if (base.Probe(x, y)) {
                var data = Singleton.Get<DataManager>();

                // Set = null to avoid
                data.CurrentRoom.Objects[this.ItemID] = null;

                data.CurrentRoom.AddFloatingMessage("You found a pillow case...", x, y - 100, 2500);
            }
            return true;
        }
    }
}
