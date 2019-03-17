using System;
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

        private int _frame;
        private int _last_moved;
        private int _dir = 1;

        public float Width;
        public float Height;

        public bool HasPillowCase;
        public bool TouchedCrack;
        public bool HasStones;
        public bool HasBucket;
        public bool isBucketFilled = false;
        //Needs to be modified
        public bool HasBlanket = true;

        public bool HasUmbrella;

        public bool Hiding;
        public bool ShooedBirds;
        public bool HasScrewDriver { get; internal set; }
        public bool HasApron { get; internal set; }
        public bool HasBroom { get; internal set; }

        public Player() {
            this._ctx = new SurfaceContext() {
                Size = (175, 175)
            };
        }

        public void Draw(IDrawableSurface surface) {
            this._ctx.Position = (this.X, this.Y);
            this._ctx.Rect = (600 * _frame, 600 * _dir, 600, 600);
            surface.Draw("graphics/player.png", this._ctx);
        }

        public void HandleMove(JoystickAxis axis, float position) {
            if (axis == JoystickAxis.X || axis == JoystickAxis.Y) {
                position /= 32;

                position = Singleton.Get<DataManager>().CurrentRoom.AdjustSpeed(position);

                if (position == 0) {
                    return;
                }

                if (position > 0 && axis == JoystickAxis.X) {
                    _dir = 1;
                } else if (position < 0 && axis == JoystickAxis.X) {
                    _dir = 0;
                }

                if (axis == JoystickAxis.X) {
                    this.X += position;
                }
                if (axis == JoystickAxis.Y) {
                    this.Y += position / 32;
                }

                (float newX, float newY) = Singleton.Get<DataManager>().CurrentRoom.CheckBounds(this.X, this.Y);
                this._last_moved = Environment.TickCount;
                this.X = newX;
                this.Y = newY;
            }
        }

        public void UpdateFrame() {
            if (Environment.TickCount - this._last_moved < 100) {
                _frame = (_frame + 1) % 7;
            } else {
                this._frame = 0;
            }
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
