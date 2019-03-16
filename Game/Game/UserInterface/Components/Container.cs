using System.Collections.Generic;
using Game.Graphics;

namespace Game.UserInterface.Components
{
    public class Container : UIElement
    {
        public List<UIElement> Children = new List<UIElement>();

        public override void Draw(IDrawableSurface surface) {
            foreach (var element in this.Children) {
                element.Draw(surface);
            }
        }

        public void AddChild(UIElement child) {
            this.Children.Add(child);
        }
    }
}
