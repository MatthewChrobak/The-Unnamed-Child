using Game.Patterns.Singleton;

namespace Game.Models.Rooms
{
    public class MasterBedroom : Room
    {
        public override void OnEnter() {
            var data = Singleton.Get<DataManager>();
            var player = data.Player;
            player.SetSize(175 / 2.5f, 175 / 2.5f);
        }

        public override float AdjustSpeed(float position) {
            return base.AdjustSpeed(position) / 2.5f;
        }

        public override bool IsBabaYagaFlipped() {
            return true;
        }

        public override float GetBabaYagaStartXConstant() {
            return 575;
        }

        public override float GetBabaYagaStartYConstant() {
            return 375;
        }

        public override float GetBabaYagaScalingConstant() {
            return 2.5f;
        }
    }
}
