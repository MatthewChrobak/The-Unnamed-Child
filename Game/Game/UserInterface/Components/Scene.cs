namespace Game.UserInterface.Components
{
    public class Scene : Container
    {
        public Scene() {
            this.OnJoystickButtonPressed += (button) => {
                foreach (var element in this.Children) {
                    if (element.OnJoystickButtonPressed != null) {
                        element.OnJoystickButtonPressed(button);
                        break;
                    }
                }
            };
        }
    }
}
