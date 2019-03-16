using System;
using Game.Graphics;
using Game.Graphics.Contexts;
using Game.UserInterface;

namespace Game.Models.Entities.ConcreteItems
{
    public class PillowCase : Items
    {
        public PillowCase()
        {
            this._ctx = new SurfaceContext()
            {
                Size = (10, 10)

            };
        }

    }
}
