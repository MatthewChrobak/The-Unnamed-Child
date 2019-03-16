using Game.Graphics;
using Game.Models;
using Game.Models.Entities;
using Game.Patterns.Singleton;
using Game.UserInterface.Components;
using SFML.Window;

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

        public override void OnJoystickMoved(Joystick.Axis axis, float position) {
            base.OnJoystickMoved(axis, position);

            if (axis == Joystick.Axis.X) {
                Player.CurrentPlayer.Move(position);
            }
        }
    }
}
