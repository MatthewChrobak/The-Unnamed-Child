using Game.Events;
using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class MasterBed : CollisionObject
    {
        public override bool Probe(float x, float y) {

            if (base.Probe(x - 50, y)) {
                var data = Singleton.Get<DataManager>();
                var globals = Singleton.Get<Globals>();
                var queue = Singleton.Get<EventQueue>();
                var room = data.CurrentRoom;

                if (this.Position.x > 450) {

                    if (x < 600 || x > 610) {
                        return true;
                    }
                    globals.DisableMovement = true;
                    globals.DisableUserInput = true;
                    int counter = 70;

                    queue.AddEvent(PriorityTypes.ANIMATION, () => {

                        data.Player.Y -= 5;

                        counter--;
                        if (counter == 0) {
                            globals.DisableUserInput = false;
                            return EVENT_RETURN.REMOVE_FROM_QUEUE;
                        }
                        return EVENT_RETURN.NONE;
                    }, 25, 0);

                    return true;
                }

                this.Position.x += 10;
                room.Objects[this.ItemID + 1].Position.x += 10;
                this.RefreshContext();
                room.Objects[this.ItemID + 1].RefreshContext();
            }

            return true;
        }
    }
}
