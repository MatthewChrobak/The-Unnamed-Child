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
                var player = data.Player;

                if (!player.HasScrewDriver) {
                    data.CurrentRoom.AddFloatingMessage("I can't undo these screws.", x, y - 50, 2500);
                    return true;
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
