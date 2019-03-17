using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class MasterBedSheet : CollisionObject
    {
    
            public override bool Probe(float x, float y)
            {

                if (base.Probe(x, y))
                {

                    var data = Singleton.Get<DataManager>();

                    data.Player.HasBlanket = true;

                    data.CurrentRoom.AddFloatingMessage("Picked up a blanket.", x, y - 100, 3000);

                    data.CurrentRoom.Objects[this.ItemID] = null;
                }

                return true;
            }
        
    }
}
