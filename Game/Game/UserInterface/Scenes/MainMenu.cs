using Game.Graphics.Contexts;
using Game.Models;
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
                    if (Singleton.Get<Globals>().DisableUserInput) {
                        return;
                    }
                    if (button == JoystickButton.A) {
                        Singleton.Get<DataManager>().NewGame();
                        Singleton.Get<UIManager>().LoadScene<InGame>();
                    }
                }
            });

            this.OnJoystickButtonPressed += (button) => {
                if (Singleton.Get<Globals>().DisableUserInput) {
                    return;
                }
                if (button == JoystickButton.Back) {
                    Singleton.Get<UIManager>().LoadScene<Closing>();
                }
            };
        }

        public override void OnEnter() {
            Singleton.Get<Globals>().DisableUserInput = false;
        }
    }
}
