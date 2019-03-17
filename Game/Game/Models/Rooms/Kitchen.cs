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
    }
}
