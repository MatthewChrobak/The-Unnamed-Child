using Game.Patterns.Singleton;

namespace Game.Models.Rooms
{
    public class MasterBedroom : Room
    {
        public override void OnEnter()
        {
            var data = Singleton.Get<DataManager>();
            var player = data.Player;
            player.SetSize(175 / 2.5f, 175 / 2.5f);
        }

        public override float AdjustSpeed(float position)
        {
            return base.AdjustSpeed(position) / 2.5f;
        }
    }
}
