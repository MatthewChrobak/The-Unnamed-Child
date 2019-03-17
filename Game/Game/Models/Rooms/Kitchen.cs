using Game.Patterns.Singleton;

namespace Game.Models.Rooms
{
    public class Kitchen : Room
    {
        public override void OnEnter() {
            var data = Singleton.Get<DataManager>();
            var player = data.Player;

            player.SetSize(175, 175);
        }

        public override float GetBabaYagaScalingConstant() {
            return 1;
        }

        public override float GetBabaYagaStartXConstant() {
            return 600;
        }

        public override float GetBabaYagaStartYConstant() {
            return 180;
        }

        public override bool IsBabaYagaFlipped() {
            return true;
        }
    }
}
