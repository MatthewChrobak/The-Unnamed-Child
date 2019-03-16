using System;
using Game.Graphics;
using Game.Graphics.Contexts;
using Game.UserInterface;

namespace Game.Models.Entities.ConcreteItems
{
    public class Cloth : Items
    {
        public Cloth()
        {
            this._ctx = new SurfaceContext()
            {
                Size = (10, 10)
            };
        }
    }
}
