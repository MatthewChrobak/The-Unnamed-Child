using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Cleaver : CollisionObject
    {
        public override bool Probe(float x, float y) {
            if (base.Probe(x, y)) {
                var data = Singleton.Get<DataManager>();
                var player = data.Player;

                if (!data.Player.HasBroom) {
                    data.CurrentRoom.AddFloatingMessage("I can't reach that!", x, y - 100, 3000);
                    return true;
                }
                if (data.Player.HasBroom) {
                    data.CurrentRoom.AddFloatingMessage("This seem to be useful...but for what?", x, y - 100, 3000);
                    player.hasClever = true;
                    data.CurrentRoom.Objects[this.ItemID] = null;
                }
                return true;
            }
            return false;
        }
    }
}
