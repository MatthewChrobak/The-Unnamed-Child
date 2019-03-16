using System;
using Game.Graphics;
using Game.Graphics.Contexts;
using Game.UserInterface;

namespace Game.Models.Entities
{
    public abstract class Items : IDrawableObject
    {
        public string Images = "";
        public int Id { get; set; }
        public SurfaceContext _ctx;

        public Items()
        {
            this._ctx = new SurfaceContext()
            {
                Size = (20, 20)
            };
        }
        public void Draw(IDrawableSurface surface)
        {
            surface.Draw(this.Images, this._ctx);
        }
    }
}
