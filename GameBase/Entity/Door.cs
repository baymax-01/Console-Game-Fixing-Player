using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Entity
{
    class Door: EntityBase
    {
        public override string name { get; set; } = "Door";
        public override char character { get; set; } = Constant.DoorChar;

        public override void DrawStats()
        {

        }

        public override void Start(GameScene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.BackgroundColor = ConsoleColor.Gray;
            pixel.ForegroundColor = ConsoleColor.Black;
            smoothRender = true;
        }
        public override void Update()
        {
        }
    }
}
