using System;
using Game.Graphics;
using Game.Graphics.Contexts;
using Game.Models.Rooms.Objects;
using Game.Patterns.Singleton;
using Game.UserInterface;

namespace Game.Models.Rooms.Objects
{
    [Serializable]
    public class Cloth : CollisionObject
    {
        public override bool Probe(float x, float y) {
            if (base.Probe(x, y)) {
                var data = Singleton.Get<DataManager>();

                // Set = null to avoid
                //data.CurrentRoom.Objects[this.ItemID] = null;

                this.SurfaceName = "graphics/room1_used_cloth.png";
                return true;
            }
            return false;
        }
    }
}
