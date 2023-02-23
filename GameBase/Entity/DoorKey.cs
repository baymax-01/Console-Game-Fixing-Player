using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Entity
{
    class DoorKey:EntityBase
    {
        public override string name { get; set; } = "DoorKey";
        public override char character { get; set; } = Constant.DoorKeyChar;

        public override void DrawStats()
        {

        }

        public override void Start(GameScene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.BackgroundColor = ConsoleColor.DarkGreen;
            smoothRender = true;
        }
        public override void Update()
        {
        }
    }
}
