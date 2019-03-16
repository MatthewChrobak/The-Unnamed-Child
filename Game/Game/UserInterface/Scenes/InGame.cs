using Game.Graphics;
using Game.Models;
using Game.Models.Entities;
using Game.Patterns.Singleton;
using Game.UserInterface.Components;

namespace Game.UserInterface.Scenes
{
    public class InGame : Scene
    {
        public InGame() {
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

        public override void Draw(IDrawableSurface surface) {
            Room.CurrentRoom.Draw(surface);
            Player.CurrentPlayer.Draw(surface);
            base.Draw(surface);
        }

        public override void JoystickMoved(uint joystickID, JoystickAxis axis, float position) {
            switch (axis) {
                case JoystickAxis.X:
                case JoystickAxis.Y:
                    Room.CurrentRoom.HandleJoystickMoved(joystickID, axis, position);
                    break;
            }
        }
    }
}
