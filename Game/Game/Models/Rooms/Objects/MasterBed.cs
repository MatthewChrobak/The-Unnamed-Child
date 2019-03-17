using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class MasterBed : CollisionObject
    {
        public override bool Probe(float x, float y) {

            if (base.Probe(x - 50, y)) {

                if (this.Position.x > 450) {
                    return true;
                }

                var room = Singleton.Get<DataManager>().CurrentRoom;
                this.Position.x += 10;
                room.Objects[this.ItemID + 1].Position.x += 10;
                this.RefreshContext();
                room.Objects[this.ItemID + 1].RefreshContext();
            }

            return true;
        }
    }
}
