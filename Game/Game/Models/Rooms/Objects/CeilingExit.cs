using Game.Patterns.Singleton;
using System;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class CeilingExit : CollisionObject
    {
        public string RoomName;
        public float PlayerX;
        public float PlayerY;

        public override bool Probe(float x, float y)
        {
            var data = Singleton.Get<DataManager>();
            if (base.Probe(x, y))
            {


                if (data.Player.HasUmbrella == true)
                {
                    data.LoadRoom(this.RoomName);

                    float playerx = PlayerX;
                    float playery = PlayerY;

                    data.Player.SetPos(playerx, playery);

                    return true;
                }

                else
                {
                    data.CurrentRoom.AddFloatingMessage("There must be something I can use to open the door above.", x, y - 100, 2500);
                    return false;
                }
            }
            return false;
        }
    }
}
