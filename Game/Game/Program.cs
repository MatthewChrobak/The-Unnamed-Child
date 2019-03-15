using Game.Events;
using Game.Patterns.Singleton;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args) {
            var queue = Singleton.Create<EventQueue>();



            queue.Run();
        }
    }
}
