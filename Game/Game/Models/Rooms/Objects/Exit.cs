using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Exit : CollisionObject
    {
        public override bool Probe(float x, float y) {
            if (base.Probe(x, y)) {
                var data = Singleton.Get<DataManager>();
                var player = data.Player;
                
                if (!player.HasApron) {
                    data.CurrentRoom.AddFloatingMessage("I can't just jump out of this house!", 200, y - 100, 3000);
                    return true;
                }

            }

            return true;
        }
    }
}
