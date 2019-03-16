using Game.Graphics.Contexts;
using Game.Patterns.Singleton;
using Game.UserInterface.Components;
using SFML.Graphics;

namespace Game.UserInterface.Scenes
{
    public class MainMenu : Scene             
    {
        public MainMenu() {
            int x = 300;
            int y = 300;
            int width = 100;
            int height = 100;
            this.AddChild(new Button() {
                Position = (x, y),
                Text = "Enter Game",
                TextureName = "graphics/button.png",
                ctxSurface = new SurfaceContext() {
                    Position = (x, y),
                    Size = (width, height)
                },
                ctxText = new TextContext() {
                    Position = (x, y),
                    FontColor = Color.White,
                    HorizontalCenter_Width = width,
                    VerticalCenter_Height = height
                },
                OnJoystickButtonPressed = (button) => {
                    if (button == JoystickButton.A) {
                        Singleton.Get<UIManager>().LoadScene<GameScene>();
                    }
                }
            });

            this.OnJoystickButtonPressed += (button) => {
                foreach (var child in this.Children) {
                    if (child.OnJoystickButtonPressed != null) {
                        child.OnJoystickButtonPressed(button);
                        break;
                    }
                }

                if (button == JoystickButton.Back) {
                    Singleton.Get<UIManager>().LoadScene<Closing>();
                }
            };
        }
    }
}
