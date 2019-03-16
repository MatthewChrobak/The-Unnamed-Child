using System;
using Game.Graphics;
using Game.Graphics.Contexts;
using Game.UserInterface;

namespace Game.Models.Entities.ConcreteItems
{
    public class Stone : Items
    {
        public Stone()
        {
            this.Images = "graphics/testStoneImages.jpg";
            this._ctx.Size = (100, 100);
            this._ctx.Position = (GameWindow.WINDOW_WIDTH/2, GameWindow.WINDOW_HEIGHT/2);
        }
    }
}
