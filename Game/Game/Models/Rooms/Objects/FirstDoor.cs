using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class FirstDoor : CollisionObject
    {
        public string RoomName;
        public float PlayerX;
        public float PlayerY;

        private bool Broken = false;
        private int TimeBroken = 0;

        public override bool Probe(float x, float y) {
            if (base.Probe(x, y)) {

                var data = Singleton.Get<DataManager>();
                var player = data.Player;
                
                if (!player.HasPillowCase || !player.HasStones) {
                    data.CurrentRoom.AddFloatingMessage("I can't reach the door knob...", x, y - 100, 2500);
                    return true;
                }

                if (!Broken) {
                    Broken = true;
                    this.SurfaceName = "graphics/room1_used_door.png";
                    TimeBroken = Environment.TickCount;
                    return true;
                }

                if (Environment.TickCount - TimeBroken < 500) {
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

        public override void HandleAdditionalParamsForCreation(string[] cmd) {
            this.RoomName = cmd[3];
            this.PlayerX = float.Parse(cmd[4]);
            this.PlayerY = float.Parse(cmd[5]);
        }
    }
}
