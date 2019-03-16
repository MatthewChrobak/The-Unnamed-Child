using Game.Events;
using Game.Graphics;
using Game.Patterns.Singleton;
using Game.UserInterface;
using Game.UserInterface.Scenes;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args) {
            var queue = Singleton.Create<EventQueue>();
            var ui = Singleton.Create<UIManager>();
            var graphics = Singleton.Create<GameWindow>();

            ui.LoadScene<MainMenu>();

            // Placeholder for actual graphics.
            queue.AddEvent(PriorityTypes.GRAPHICS, () => {

                graphics.Draw();

                return EVENT_RETURN.NONE;
            }, 16, 0);


            queue.Run();
        }
    }
}
    