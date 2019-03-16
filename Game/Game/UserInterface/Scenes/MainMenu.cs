using Game.Graphics.Contexts;
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
                }
            });
        }
    }
}
