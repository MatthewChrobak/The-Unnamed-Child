using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class ScrewDriver : CollisionObject
    {
        public override bool Probe(float x, float y) {
            if (base.Probe(x, y))  {
                var data = Singleton.Get<DataManager>();

                // Bed is not pushed enough.
                if (data.CurrentRoom.Objects[this.ItemID + 1].Position.x < 410) {
                    return true;
                }
                data.Player.HasScrewDriver = true;
                data.CurrentRoom.AddFloatingMessage("You found a screwdriver.", x, y - 100, 3000);

                data.CurrentRoom.Objects[this.ItemID] = null;
            }

            return true;
        }
    }
}
