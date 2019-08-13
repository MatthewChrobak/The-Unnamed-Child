using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Door : CollisionObject
    {
        public string RoomName;
        public float PlayerX;
        public float PlayerY;

        public override bool Probe(float x, float y) {
            if (base.Probe(x, y)) {

                var data = Singleton.Get<DataManager>();
                if (data.Player.isBoilerOn)
                {
                    data.LoadRoom(this.RoomName);

                    float playerx = PlayerX;
                    float playery = PlayerY;

                    data.Player.SetPos(playerx, playery);

                    return true;
                }
                if (!data.Player.isBoilerOn)
                {
                    data.CurrentRoom.AddFloatingMessage("This house feel so cold...", x, y - 100, 2500);
                }

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
