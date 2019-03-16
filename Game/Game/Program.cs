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
            var graphics = Singleton.Create<GameWindow>();
            var sound = Singleton.Create<SoundManager>();

            
            //PlaySound or PlayMusic; the second parameter is optional and sets the volume
            queue.AddEvent(PriorityTypes.SOUNDS, () =>
            {
                sound.PlaySound(sound.footstepGrass1, 15f);
                
                return EVENT_RETURN.NONE;
            }, 1000, 0);

            queue.AddEvent(PriorityTypes.SOUNDS, () =>
            {
                sound.PlaySound(sound.footstepGrass2, 0.01f);

                return EVENT_RETURN.NONE;
            }, 1500, 500);
            

            // Placeholder for actual graphics.
            queue.AddEvent(PriorityTypes.GRAPHICS, () => {

                graphics.Draw();
                return EVENT_RETURN.NONE;
            }, 16, 0);

            
            queue.Run();
        }
    }
}
