using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Game
{
    public class FinishScene
    {
        public void Run()
        {
            Renderer.Clear();
            Console.WriteLine(@"
██████╗░██████╗░░█████╗░██╗░░░██╗░█████╗░██╗
██╔══██╗██╔══██╗██╔══██╗██║░░░██║██╔══██╗██║
██████╦╝██████╔╝███████║╚██╗░██╔╝██║░░██║██║
██╔══██╗██╔══██╗██╔══██║░╚████╔╝░██║░░██║╚═╝
██████╦╝██║░░██║██║░░██║░░╚██╔╝░░╚█████╔╝██╗
╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░░╚════╝░╚═╝
");
            Console.ReadLine();
        }
    }
}
