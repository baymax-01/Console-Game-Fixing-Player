using GameBase.Entity;
using GameBase.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameBase
{
    public class Player : EntityBase
    {

        public Player(int level,string name,char avaatar)
        {
            Gold = 0;
            Health = 100;
            MaxHealth = 100;
            Name = name;
            Armor = 0;
            Killed = 0;
            Level = level;
            DoorKey = 0;
            if (avaatar!='@'&& avaatar!='\0')
            {
                character = avaatar;
            }
            else
            {
                character = Constant.PlayerChar;
            }
            
        }
        public Player(int gold,int health,string name,int armor,int level,char avaatar)
        {
            Gold = gold;
            Health = health;
            MaxHealth = 100;
            Name = name;
            Armor = armor;
            Level = level;
            DoorKey = 0;
            if (avaatar != '@' && avaatar != '\0')
            {
                character = avaatar;
            }
            else
            {
                character = Constant.PlayerChar;
            }
        }
        public bool swordcount = false;
        public bool enemycount = false;
        public bool keyCount = false;
        public bool DoorkeyCount = false;
        public int DoorkeyCounter = 0;
        public int keyCounter = 0;
        public bool Treasure = false;
        public bool gold = false;
        public bool waiting = false;
        public override string name { get; set; } = "Player";
        public override char character { get; set; } = Constant.PlayerChar;
        Queue<string> logdetails = new Queue<string>();
        Stack<string> reversedDetails = new Stack<string>();

       
        //This Method is For Displaying Logs,Legend and Details
        public override void DrawStats()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(60, 4);
            Console.WriteLine("LEGENDS:");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(60, 5);
            Console.WriteLine("G");
            Console.SetCursorPosition(63, 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"GOLD");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(60, 6);
            Console.WriteLine("M");
            Console.SetCursorPosition(63, 6);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"MONSTER");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(60, 7);
            Console.WriteLine("K");
            Console.SetCursorPosition(63, 7);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"KEY");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(60, 8);
            Console.WriteLine("S");
            Console.SetCursorPosition(63, 8);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"ARMOR");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(60, 7);
            Console.WriteLine("K");
            Console.SetCursorPosition(63, 7);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"KEY");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(33, 4);
            Console.WriteLine("STATS:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(33, 5);
            Console.WriteLine($"Name:{Name}");
            Console.SetCursorPosition(33, 6);
            Console.WriteLine($"Health:{Health} ");
            Console.SetCursorPosition(33, 7);
            Console.WriteLine($"Level:{Level}");
            Console.SetCursorPosition(33, 8);
            Console.WriteLine($"Armor:{Armor}");
            Console.SetCursorPosition(33, 9);
            Console.WriteLine($"Gold:{Gold}");
            Console.SetCursorPosition(33, 10);
            Console.WriteLine($"Key:{DoorKey}");
            Console.SetCursorPosition(33, 11);
            Console.WriteLine($"Anemies Killed:{Killed}");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("LOGS:");

            //For Clear Console  Text From Window Becasue I Use SetCursorPosition
            int count = 0;
            foreach (string detail in reversedDetails)
            {
                Console.SetCursorPosition(0, 18 + count);
                Console.Write(new string(' ', Console.WindowWidth));
                count++;
                if (count == 5)
                {
                    break;
                }
            }
            //For Printing Details In Reversed Order
            int incre = 0;
            foreach (string detail in reversedDetails)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, 18+ incre);
               // Console.SetCursorPosition(0, Console.CursorTop);
                Console.WriteLine(detail);
                incre++;
                if (incre == 5)
                {
                    break;
                }
            }
        }

        public override void Start(GameScene scene, int x, int y)
        {
            base.Start(scene, x, y);
            pixel.ForegroundColor = ConsoleColor.DarkGreen;
        }
        public override void Update()
        {
            //var direction= Direction.NONE;
            //if (waiting!=false)
            //{
            //     direction = GetInputs().Direction;
            //    Thread.Sleep(2000);
            //    waiting = false;
            //}
            //else
            //{
            //    direction = GetInputs().Direction;
            //}
           var direction = GetInputs().Direction;
            var destX = x;
            var destY = y;
            if (direction == Direction.RIGHT)
                destX++;
            else if (direction == Direction.LEFT)
                destX--;
            else if (direction == Direction.UP)
                destY--;
            else if (direction == Direction.DOWN)
                destY++;

            //destEntity it will return current dirention of the players
            var destEntity = GetEntityInDirection(direction, 1);
            if (destEntity.entityType == EntityType.GOLD)
            {
                Gold++;
                logdetails.Enqueue("You Found A Gold");
                while (logdetails.Count > 0)
                {
                    reversedDetails.Push(logdetails.Dequeue());
                }
                destEntity.DestroyGold();
                gold = true;
            }
            if (destEntity.entityType == EntityType.SWORD)
            {
                Armor++;
                logdetails.Enqueue("You Found A Sword Which grant 20 damage");
                while (logdetails.Count > 0)
                {
                    reversedDetails.Push(logdetails.Dequeue());
                }
                destEntity.DestroySword();
                swordcount = true;
            }
            if (destEntity.entityType == EntityType.GHOST)
            {
               // waiting = true;
               // logdetails.Enqueue("Press E Press E");
                // Task.Delay(1000).Wait();
               // Thread.Sleep(1000);
                if (Armor>0)
                {
                    Armor = Armor - 1;
                    destEntity.DestroyMoster();
                }
                else if (Health > 20)
                {
                        Health = Health - 20;
                        destEntity.DestroyMoster();
                }
                else if (Health<=20)
                {
                    StartTransition(TransitionType.Dead);
                }
                Killed++;
                logdetails.Enqueue("You Killed A  Monster");
                while (logdetails.Count > 0)
                {
                    reversedDetails.Push(logdetails.Dequeue());
                }
               // Thread.Sleep(2000);
                enemycount = true;
                shareModel.sleepgame = true;
            }
            if (destEntity.entityType==EntityType.KEY)
            {
                keyCount = true;
                DoorkeyCount = true;
                destEntity.DestroyKey();
                DoorKey++;
                logdetails.Enqueue("You Got  A  Key");
                while (logdetails.Count > 0)
                {
                    reversedDetails.Push(logdetails.Dequeue());
                }
            }
            if (destEntity.entityType == EntityType.EXIT)
            {
                if (!keyCount)
                {
                    keyCounter = 1;
                    logdetails.Enqueue("You Don't Have A Key");
                    while (logdetails.Count > 0)
                    {
                        reversedDetails.Push(logdetails.Dequeue());
                    }
                }
                else
                {
                    if (Level == 10)
                    {
                        StartTransition(TransitionType.Finish);
                    }
                    else
                    {
                        StartTransition(TransitionType.NextLevel);
                        GameDetails detail = new GameDetails
                        {
                            Armor = Armor,
                            Gold = Gold,
                            Health = Health,
                            Level = Level,
                            Username = Name,
                            MonsterKilled = Killed
                        };
                        GameDetails.SaveGameDetails(detail);
                    }
                    
                }
            }
            if (destEntity.entityType==EntityType.TRESURE)
            {
                Treasure = true;
                destEntity.DestroyTresure();
                logdetails.Enqueue("You Found  A  TRESURE");
                while (logdetails.Count > 0)
                {
                    reversedDetails.Push(logdetails.Dequeue());
                }
            }
            if (destEntity.entityType == EntityType.DOOR)
            {
                if (!keyCount)
                {
                    logdetails.Enqueue("You Dont  Have A  Key");
                    while (logdetails.Count > 0)
                    {
                        reversedDetails.Push(logdetails.Dequeue());
                    }
                    keyCounter = 1;
                }
                else
                {
                    logdetails.Enqueue("You Opened  A  Door");
                    while (logdetails.Count > 0)
                    {
                        reversedDetails.Push(logdetails.Dequeue());
                    }
                    destEntity.DestroyDoor();
                }
                
            }
           
            if (destEntity.entityType != EntityType.SPACE)
                return;
            
            
            if (destX != x || destY != y)
                Move(destX, destY);
        }
    }
}
