using System;
using Game.Graphics;
using Game.Graphics.Contexts;
using Game.UserInterface;

namespace Game.Models.Entities
{
    public class Player : IDrawableObject
    {
        public static Player CurrentPlayer = new Player();

        public float X;
        private SurfaceContext _ctx;

        public Player() {
            this._ctx = new SurfaceContext() {
                Size = (100, 200)
            };
        }

        public void Draw(IDrawableSurface surface) {
            this._ctx.Position = (this.X, GameWindow.WINDOW_HEIGHT - 250);
            surface.Draw("graphics/testStoneImages.jpg", this._ctx);
        }

        public void HandleMove(JoystickAxis axis, float position) {
            if (axis == JoystickAxis.X) {
                this.X += position / 4;
            }
        }
    }
}
