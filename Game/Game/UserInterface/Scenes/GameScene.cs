using Game.Patterns.Singleton;
using Game.UserInterface.Components;

namespace Game.UserInterface.Scenes
{
    public class GameScene : Scene
    {
        public GameScene() {
            this.OnJoystickButtonPressed += (button) => {
                foreach (var child in this.Children) {
                    if (child.OnJoystickButtonPressed != null) {
                        child.OnJoystickButtonPressed(button);
                        break;
                    }
                }

                if (button == JoystickButton.Back) {
                    Singleton.Get<UIManager>().LoadScene<MainMenu>();
                }
            };
        }
    }
}
