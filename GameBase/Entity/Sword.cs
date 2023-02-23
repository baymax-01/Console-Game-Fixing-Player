using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Entity
{
    class Sword : EntityBase
    {
        public override string name { get; set; } = "Sword";
        public override char character { get; set; } = Constant.SwordChar;

        public override void DrawStats()
        {
             
        }

        public override void Start(GameScene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.BackgroundColor = ConsoleColor.Red;
            smoothRender = true;
        }
        public override void Update()
        {
           

            
           
        }
    }
}
