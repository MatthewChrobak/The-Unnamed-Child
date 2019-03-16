using Game.Graphics;
using SFML.Window;
using System;

namespace Game.UserInterface.Components
{
    public abstract class UIElement : IDrawableObject
    {
        public abstract void Draw(IDrawableSurface surface);

        public (float x, float y) Position;


        public Action<JoystickButton> OnJoystickButtonPressed;
    }
}
