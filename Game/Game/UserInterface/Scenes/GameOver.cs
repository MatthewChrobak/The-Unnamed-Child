using Game.Graphics;
using Game.Graphics.Contexts;
using Game.Patterns.Singleton;
using Game.UserInterface.Components;
using SFML.Graphics;

namespace Game.UserInterface.Scenes
{
    public class GameOver : Scene
    {
        public GameOver() {
            this.OnJoystickButtonPressed += (button) => {
                if (button == JoystickButton.Back) {
                    Singleton.Get<UIManager>().LoadScene<MainMenu>();
                }
            };
        }

        public override void Draw(IDrawableSurface surface) {
            surface.Draw("You died to Baba Yaga", new TextContext() {
                HorizontalCenter_Width = GameWindow.WINDOW_WIDTH,
                VerticalCenter_Height = GameWindow.WINDOW_HEIGHT,
                FontColor = Color.White,
                FontSize = 36
            });
        }
    }
}
