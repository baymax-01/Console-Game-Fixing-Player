using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    public class WallHorizonatal : EntityBase
    {
        public override string name { get; set; } = "WallHorizontal";
        public override char character { get; set; } = Constant.WallCharHorizontal;

        public override void DrawStats()
        {
             
        }

        public override void Start(GameScene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.BackgroundColor = ConsoleColor.DarkBlue;
            smoothRender = true;
        }
        public override void Update()
        {
        }
    }
}
