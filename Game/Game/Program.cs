using Game.Events;
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

            // Placeholder for actual graphics.
            queue.AddEvent(PriorityTypes.GRAPHICS, () => {
                return EVENT_RETURN.NONE;
            }, 16, 0);

            
            queue.Run();
        }
    }
}
