using Game.Events;
using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class ScrewDriverDoor : CollisionObject
    {
        public string RoomName;
        public float PlayerX;
        public float PlayerY;

        public override bool Probe(float x, float y) {
            if (base.Probe(x, y)) {

                var data = Singleton.Get<DataManager>();
                var globals = Singleton.Get<Globals>();
                var queue = Singleton.Get<EventQueue>();
                var player = data.Player;

                if (!player.HasScrewDriver) {
                    data.CurrentRoom.AddFloatingMessage("I can't undo these screws.", x, y - 50, 2500);

                    globals.DisableMovement = true;
                    globals.DisableUserInput = true;
                    int counter = 70;

                    queue.AddEvent(PriorityTypes.ANIMATION, () => {

                        data.Player.Y += 5;

                        counter--;
                        if (counter == 0) {
                            globals.DisableUserInput = false;
                            globals.DisableMovement = false;
                            return EVENT_RETURN.REMOVE_FROM_QUEUE;
                        }
                        return EVENT_RETURN.NONE;
                    }, 25, 0);
                    return true;
                } else {
                    globals.DisableUserInput = false;
                    globals.DisableMovement = false;
                }

                data.LoadRoom(this.RoomName);

                float playerx = PlayerX;
                float playery = PlayerY;

                data.Player.SetPos(playerx, playery);

                return true;
            }

            return false;
        }
    }
}
