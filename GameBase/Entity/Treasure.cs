using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Entity
{
    class Treasure: EntityBase
    {
        public override string name { get; set; } = "Treasure";
        public override char character { get; set; } = Constant.TreasureChar;

        public override void DrawStats()
        {
             
        }

        public override void Start(GameScene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.BackgroundColor = ConsoleColor.DarkMagenta;
            smoothRender = true;
        }
        public override void Update()
        {
        }
    }
}
