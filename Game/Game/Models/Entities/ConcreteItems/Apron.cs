using System;
using Game.Graphics;
using Game.Graphics.Contexts;
using Game.UserInterface;

namespace Game.Models.Entities.ConcreteItems
{
    public class Apron : Items
    {
        public Apron()
        {
            this._ctx = new SurfaceContext()
            {
                Size = (10, 10)
            };
        }

    }
}
