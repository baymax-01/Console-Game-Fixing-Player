using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Entity
{
    class Entrance: EntityBase
    {
        public override string name { get; set; } = "Entrance";
        public override char character { get; set; } = Constant.EntranceChar;

        public override void DrawStats()
        {
             
        }

        public override void Start(GameScene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.BackgroundColor = ConsoleColor.Black;
            smoothRender = true;
        }
        public override void Update()
        {
        }
    }
}
