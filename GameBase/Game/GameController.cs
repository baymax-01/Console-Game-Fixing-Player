using GameBase.Entity;
using GameBase.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase
{
    //This the main class to mainting the overflow 
    public class GameController
    {
        private Renderer renderer = new Renderer();
        public bool nextlvl = true;
        public void Run()
        {
            Console.Title = "Console Dungeon Crawler saga";
            while (true)
            {
                Intro();
                Game(renderer);
            }
        }

        private void Intro()
        {
            new IntroScene().Run();
        }

        private void Game(Renderer renderer)
        {
            while (nextlvl)
            {
                var s = new GameScene(Constant.WindowXSize, Constant.WindowYSize, renderer);
                s.Load($"Resource/map{shareModel.Level}.txt");
               // s.Load($"Resource/map10.txt");
                var sw = new Stopwatch();
                while (s.transition == TransitionType.None)
                {
                    sw.Start();
                    s.Tick();
                    sw.Stop();
                    var elapsed = sw.ElapsedMilliseconds;
                    sw.Reset();
                    var target = (elapsed > Constant.GameLoopDelay) ? 0 : Constant.GameLoopDelay - elapsed;
                    Task.Delay(TimeSpan.FromMilliseconds(target)).Wait();
                }
                if (s.transition == TransitionType.NextLevel)
                {

                    NextLevel();
                    GameDetails details = new GameDetails();
                    details = GameDetails.LoadGameDetails(shareModel.name);
                    shareModel.newgame = false;
                    shareModel.Armor = details.Armor;
                    shareModel.name = details.Username;
                    shareModel.Health = details.Health;
                    shareModel.Level = details.Level;
                    shareModel.Gold = details.Gold;
                    shareModel.Killed = details.MonsterKilled;
                    nextlvl = true;
                    s.transition = TransitionType.None;
                }
                if (s.transition == TransitionType.Finish)
                {
                    nextlvl = false;
                    Finish();
                }
                if (s.transition == TransitionType.Dead)
                {
                    nextlvl = false;
                    Dead();
                }
                    
            }
        }
        private void NextLevel()
        {
            new NextLevel().Run();
        }
        private void Finish()
        {
            new FinishScene().Run();
        }

        private void Dead()
        {
            new DeadScene().Run();
        }
    }
}
