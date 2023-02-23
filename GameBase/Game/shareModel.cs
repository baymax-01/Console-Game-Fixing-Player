using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Game
{
    class shareModel
    {
        public shareModel()
        {
            Level = 1;
        }
        public static bool newgame { get; set; }
        public static string name { get; set; }
        public static int Armor { get; set; }
        public static int Health { get; set; }
        public static int Level { get; set; }
        public static int Gold { get; set; }
        public static int Killed { get; set; }
        public static char character { get; set; }
        public static bool sleepgame = false; 
    }
}
