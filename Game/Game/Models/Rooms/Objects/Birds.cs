using Game.Patterns.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Rooms.Objects
{
    public class Birds : CollisionObject
    {
        private int frameId;

        public override bool Probe(float x, float y) {
            var data = Singleton.Get<DataManager>();


            if (base.Probe(x, y)) {
                if (data.Player.ShooedBirds == false && data.Player.TouchedCrack == true) {
                    if (data.Player.HasBlanket) {
                        data.Player.ShooedBirds = true;
                        data.CurrentRoom.Objects[3] = null;
                        data.CurrentRoom.AddFloatingMessage("The birds have fled.", x, y - 100, 2500);

                        data.CurrentRoom.Bounds = (data.CurrentRoom.Bounds.lb, 2500);
                        data.Player.HasBlanket = false;

                        data.CurrentRoom.Objects[1].Position = (744, 320);
                        data.CurrentRoom.Objects[1].RefreshContext();
                    } else {
                        data.CurrentRoom.AddFloatingMessage("I need something to get rid of these birds.", x, y - 100, 2500);
                    }
                }

                return true;
            }
            return false;
        }

        public void Update() {
            frameId = (frameId + 1) % 12;
            this._ctx.Rect = (700 * frameId, 0, 1000, 700);
        }
    }
}
