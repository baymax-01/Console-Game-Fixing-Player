using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameBase.Game
{
    class NextLevel
    {
        public void Run()
        {
            Renderer.Clear();
            Console.WriteLine(@"  
███╗░░██╗███████╗██╗░░██╗████████╗  ██╗░░░░░███████╗██╗░░░██╗███████╗██╗░░░░░
████╗░██║██╔════╝╚██╗██╔╝╚══██╔══╝  ██║░░░░░██╔════╝██║░░░██║██╔════╝██║░░░░░
██╔██╗██║█████╗░░░╚███╔╝░░░░██║░░░  ██║░░░░░█████╗░░╚██╗░██╔╝█████╗░░██║░░░░░
██║╚████║██╔══╝░░░██╔██╗░░░░██║░░░  ██║░░░░░██╔══╝░░░╚████╔╝░██╔══╝░░██║░░░░░
██║░╚███║███████╗██╔╝╚██╗░░░██║░░░  ███████╗███████╗░░╚██╔╝░░███████╗███████╗
╚═╝░░╚══╝╚══════╝╚═╝░░╚═╝░░░╚═╝░░░  ╚══════╝╚══════╝░░░╚═╝░░░╚══════╝╚══════╝            
");
            //int mapCount = 1;
            //string[] maps = new string[mapCount];
            //load the maps from text file
            //maps[0] = File.ReadAllText($"Resource/map{shareModel.Level + 1}.txt");
            //Console.WriteLine("This Map " + $" Has {shareModel.Level + 1} Monster");
            //Console.WriteLine(maps[0]);
            //Console.WriteLine("PRESS ANY KEY TO START");
            //Console.WriteLine();
            //Console.ReadLine();
            Thread.Sleep(2000);
        }
    }
}
