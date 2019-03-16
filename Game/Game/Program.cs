using Game.Events;
using Game.Graphics;
using Game.Patterns.Singleton;
using Game.Sounds;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args) {
            var queue = Singleton.Create<EventQueue>();
            var sound = Singleton.Create<SoundManager>();


            sound.getSound();
            var graphics = Singleton.Create<GameWindow>();

            // Placeholder for actual graphics.
            queue.AddEvent(PriorityTypes.GRAPHICS, () => {

                graphics.Draw();

                return EVENT_RETURN.NONE;
            }, 16, 0);

            
            queue.Run();
        }
    }
}
