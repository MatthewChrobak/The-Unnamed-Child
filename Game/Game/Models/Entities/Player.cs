using Game.Graphics;
using Game.Graphics.Contexts;
using Game.Patterns.Singleton;
using Game.UserInterface;

namespace Game.Models.Entities
{
    public class Player : IDrawableObject
    {
        public float Y;
        public float X;
        private SurfaceContext _ctx;

        public float Width;
        public float Height;
        
        public Player() {
            this._ctx = new SurfaceContext() {
                Size = (100, 175)
            };
        }

        public void Draw(IDrawableSurface surface) {
            this._ctx.Position = (this.X, this.Y);
            surface.Draw("graphics/player.png", this._ctx);
        }

        public void HandleMove(JoystickAxis axis, float position) {
            if (axis == JoystickAxis.X) {
                this.X += position / 4;
            }
            if (axis == JoystickAxis.Y) {
                this.Y += position / 4;
            }
            (float newX, float newY) = Singleton.Get<DataManager>().CurrentRoom.CheckBounds(this.X, this.Y);

            this.X = newX;
            this.Y = newY;
        }

        public void SetPos(float x, float y) {
            this.X = x;
            this.Y = y;
        }

        public void SetSize(float width, float height) {
            this.Width = width;
            this.Height = height;
            this._ctx.Size = (width, height);
        }
    }
}
