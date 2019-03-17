using Game.Patterns.Singleton;

namespace Game.Models.Rooms
{
    public class LivingRoom : Room
    {
        public LivingRoom() {
            this.Player_Y_Height = 280;
        }

        public override void OnEnter() {
            var data = Singleton.Get<DataManager>();
            data.Player.SetPos(50, this.Player_Y_Height);
            data.Player.SetSize(175 / 2, 175 / 2);
        }

        public override float AdjustSpeed(float position) {
            return base.AdjustSpeed(position) / 2;
        }

        public override float GetBabaYagaScalingConstant() {
            return 2;
        }

        public override float GetBabaYagaStartXConstant() {
            return 50;
        }

        public override float GetBabaYagaStartYConstant() {
            return 230;
        }

        public override bool IsBabaYagaFlipped() {
            return false;
        }
    }
}
