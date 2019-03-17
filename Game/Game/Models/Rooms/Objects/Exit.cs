using Game.Patterns.Singleton;
using Game.UserInterface.Scenes;
using System;
using Game.UserInterface;
using System.Timers;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Exit : CollisionObject
    {
        public override bool Probe(float x, float y) {
            if (base.Probe(x, y)) {
                var data = Singleton.Get<DataManager>();
                var player = data.Player;
                
                if (!player.HasApron && player.hasClever) {
                    data.CurrentRoom.AddFloatingMessage("I can't just jump out of this house!", 200, y - 100, 3000);
                    return true;
                }
                if (!player.hasClever)
                {
                    data.CurrentRoom.AddFloatingMessage("Oh no... I am blocked by this wood plank!", 200, y - 100, 3000);
                    return true;
                }
                if (player.hasClever && player.HasApron)
                {
                    data.CurrentRoom.AddFloatingMessage("This is fun, it's finally open...", 200, y - 100, 3000);
                    data.CurrentRoom.Objects[this.ItemID] = null;

                    Singleton.Get<UIManager>().LoadScene<Credit>();
                }
            }

            return true;
        }
    }
}
