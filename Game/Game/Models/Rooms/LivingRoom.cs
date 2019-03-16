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
            data.Player.SetPos(0, this.Player_Y_Height);
            data.Player.SetSize(100 / 2, 175 / 2);
        }
    }
}
