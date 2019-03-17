using Game.Patterns.Singleton;

namespace Game.Models.Rooms
{
    public class BoilerRoom : Room
    {
        public BoilerRoom()
        {
            this.Player_Y_Height = 540 - 225;
        }

        public override void OnEnter()
        {
            var data = Singleton.Get<DataManager>();
            //set size
            data.Player.SetPos(2000, 0);
            data.Player.SetSize(175, 175);
        }

        public override void OnLeave()
        {

        }

        public override float GetBabaYagaScalingConstant() {
            return 1;
        }

        public override float GetBabaYagaStartXConstant() {
            return 75;
        }

        public override float GetBabaYagaStartYConstant() {
            return 200;
        }
    }


}
