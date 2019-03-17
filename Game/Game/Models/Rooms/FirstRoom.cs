using Game.Patterns.Singleton;

namespace Game.Models.Rooms
{
    public class FirstRoom : Room
    {
        public FirstRoom() {
            this.Player_Y_Height = 540 - 225;
        }

        public override void OnEnter() {
            var data = Singleton.Get<DataManager>();
            //set size
            data.Player.SetPos(575, this.Player_Y_Height);
            data.Player.SetSize(175, 175);
        }

        public override void OnLeave() {
            
        }

        public override float GetBabaYagaStartXConstant() {
            return 100;
        }

        public override float GetBabaYagaStartYConstant() {
            return 200;
        }
    }
}
