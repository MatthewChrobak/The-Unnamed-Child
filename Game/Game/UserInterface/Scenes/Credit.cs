using Game.Graphics;
using Game.IO;
using Game.Models;
using Game.Models.Entities;
using Game.Models.Rooms;
using Game.Models.Rooms.Objects;
using Game.Patterns.Singleton;
using Game.UserInterface.Components;
using SFML.Graphics;
using System;
namespace Game.UserInterface.Scenes
{
    public class Credit : Scene
    {
        public override void Draw(IDrawableSurface surface)
        {
            //TODO: draw the credit image
            var data = Singleton.Get<DataManager>();
            data.CurrentRoom.Draw(surface);
            data.Player.Draw(surface);
            data.BabaYaga?.Draw(surface);
            base.Draw(surface);

            surface.Draw("graphics/end_credit.png", new Graphics.Contexts.SurfaceContext()
            {
                Size = (GameWindow.WINDOW_WIDTH, GameWindow.WINDOW_HEIGHT)
            });
        }
    }
}
