using Game.Events;
using Game.Patterns.Singleton;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args) {
            var queue = Singleton.Create<EventQueue>();

            // Placeholder for actual graphics.
            queue.AddEvent(PriorityTypes.GRAPHICS, () => {
                return EVENT_RETURN.NONE;
            }, 16, 0);


            queue.Run();
        }
    }
}
