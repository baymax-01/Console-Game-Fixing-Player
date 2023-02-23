using GameBase.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Game
{
    public class IntroScene
    {
          public bool next=true;
        public bool avt = true;
        public void Run()
        {
                  
            while (next)
            {

            //Renderer.Clear();
            Console.WriteLine(@"    
██████╗░██╗░░░██╗███╗░░██╗░██████╗░███████╗░█████╗░███╗░░██╗  ██████╗░░█████╗░██╗░░░██╗
██╔══██╗██║░░░██║████╗░██║██╔════╝░██╔════╝██╔══██╗████╗░██║  ██╔══██╗██╔══██╗╚██╗░██╔╝
██║░░██║██║░░░██║██╔██╗██║██║░░██╗░█████╗░░██║░░██║██╔██╗██║  ██████╦╝██║░░██║░╚████╔╝░
██║░░██║██║░░░██║██║╚████║██║░░╚██╗██╔══╝░░██║░░██║██║╚████║  ██╔══██╗██║░░██║░░╚██╔╝░░
██████╔╝╚██████╔╝██║░╚███║╚██████╔╝███████╗╚█████╔╝██║░╚███║  ██████╦╝╚█████╔╝░░░██║░░░
╚═════╝░░╚═════╝░╚═╝░░╚══╝░╚═════╝░╚══════╝░╚════╝░╚═╝░░╚══╝  ╚═════╝░░╚════╝░░░░╚═╝░░░
 
░█████╗░██████╗░░█████╗░░██╗░░░░░░░██╗██╗░░░░░███████╗██████╗░  ░██████╗░█████╗░░██████╗░░█████╗░
██╔══██╗██╔══██╗██╔══██╗░██║░░██╗░░██║██║░░░░░██╔════╝██╔══██╗  ██╔════╝██╔══██╗██╔════╝░██╔══██╗
██║░░╚═╝██████╔╝███████║░╚██╗████╗██╔╝██║░░░░░█████╗░░██████╔╝  ╚█████╗░███████║██║░░██╗░███████║
██║░░██╗██╔══██╗██╔══██║░░████╔═████║░██║░░░░░██╔══╝░░██╔══██╗  ░╚═══██╗██╔══██║██║░░╚██╗██╔══██║
╚█████╔╝██║░░██║██║░░██║░░╚██╔╝░╚██╔╝░███████╗███████╗██║░░██║  ██████╔╝██║░░██║╚██████╔╝██║░░██║
░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝╚═╝░░╚═╝  ╚═════╝░╚═╝░░╚═╝░╚═════╝░╚═╝░░╚═╝
");
            Console.WriteLine("1. Start new game");
            Console.WriteLine("2. Continue saved game");
            Console.WriteLine("3. Menu");
            Console.WriteLine("Enter your choice: ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                next = false;
                Console.WriteLine("Enter username: ");
                string username = Console.ReadLine();
                shareModel.newgame = true;
                shareModel.name = username;
                shareModel.Level = 1;
            }
            else if (choice == "2")
            {
                GameDetails details = new GameDetails();
                Console.WriteLine("Enter User Name");
                string username = Console.ReadLine();
                details= GameDetails.LoadGameDetails(username);
                if (details==null || String.IsNullOrEmpty(details.Username))
                {
                    Console.WriteLine("This User Name Has Not Save Game");
                    Console.WriteLine("Please Start New Game");
                }
                else
                {
                    Console.WriteLine("Do you Want To Check Inventory Items y/n");
                    string checkinventory = Console.ReadLine();
                    if (checkinventory=="Y" || checkinventory=="y")
                        {
                            Console.WriteLine("Avatar Name:" + details.Username);
                            DisplayStats(details);
                            Console.WriteLine("=======BUY========");
                            Console.WriteLine("1 Armor = 2 Gold");
                            Console.WriteLine("20 Percent Health= 5 Gold");
                            Console.WriteLine("Do You Buy Armor/Health y /n");
                            var ans = Console.ReadLine();
                            if (ans == "Y" || ans == "y")
                            {
                                int number;
                                string more = "";
                                do
                                {
                                    Console.WriteLine("Buy Armor Press 1");
                                    Console.WriteLine("Buy Health Press 2");
                                    var inventory = Console.ReadLine();
                                    if (int.TryParse(inventory, out number))
                                    {

                                        if (inventory == "1")
                                        {
                                            Console.WriteLine("Enter Quantity like 1,2,3 ");
                                            string armorqyt = Console.ReadLine();

                                            if (int.TryParse(armorqyt, out number))
                                            {

                                                if (details.Gold >= Convert.ToInt32(armorqyt) * 2)
                                                {
                                                    details.Armor = details.Armor + Convert.ToInt32(armorqyt);
                                                    details.Gold = details.Gold-(Convert.ToInt32(armorqyt) * 2) ;
                                                    DisplayStats(details);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Dont Have Gold");
                                                    DisplayStats(details);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("The input is not a number.");
                                            }


                                        }
                                        else if (inventory == "2")
                                        {
                                            Console.WriteLine("Enter Quantity like 1,2,3 ");
                                            string healthqyt = Console.ReadLine();
                                            if (int.TryParse(healthqyt, out number))
                                            {

                                                if (details.Gold >= Convert.ToInt32(healthqyt) * 5)
                                                {
                                                    details.Health = details.Health + Convert.ToInt32(healthqyt);
                                                    details.Gold = details.Gold-(Convert.ToInt32(healthqyt) * 5);
                                                    DisplayStats(details);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Dont Have Gold");
                                                    DisplayStats(details);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("The input is not a number.");

                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please Enter 1 Or 2");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("The input is not a number.");
                                    }
                                    Console.WriteLine("Do you Want to Buy More y / n");
                                    more = Console.ReadLine();
                                } while (more == "y" || more == "Y");
                            }

                        }
                        shareModel.Armor = details.Armor;
                    shareModel.name = details.Username;
                    shareModel.Health = details.Health;
                    shareModel.Level = details.Level;
                    shareModel.Gold = details.Gold;
                    shareModel.Killed = details.MonsterKilled;
                    shareModel.newgame = false;
                    next = false;
                }
            }
            else if(choice == "3")
                {
                    Console.WriteLine("Check All Player stats Press 1");
                    Console.WriteLine("Change Avatart  Press 2");
                    var playerstats = Console.ReadLine();
                    if (playerstats=="1")
                    {
                        PlayerStats playerStats = PlayerStats.LoadPlayerstats();
                        Console.WriteLine(playerStats.total_gold);
                        Console.WriteLine("=====================");
                        Console.WriteLine("====PLAYER STATS=====");
                        Console.WriteLine("Total Player Deaths:"+playerStats.total_player_death);
                        Console.WriteLine("Total Damage Dealt:" + playerStats.total_damage_dealt);
                        Console.WriteLine("Total Damage Taken:" + playerStats.total_damage_taken);
                        Console.WriteLine("Total Monsters Killed:" + playerStats.total_monster_killed);
                        Console.WriteLine("Total gold:" + playerStats.total_gold);
                        Console.WriteLine("=====================");
                    }
                    else if(playerstats=="2")
                    {
                        Console.WriteLine("Default Avatar is @");
                        Console.WriteLine("Do You Want to change Avatar y/n");
                        string ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {

                            while (avt)
                            {
                                Console.WriteLine("These Are the Available Avatar +,$,%");
                                char avatar = Convert.ToChar(Console.ReadLine());
                                if (avatar == '+' || avatar == '$' || avatar == '%')
                                {
                                    shareModel.character = avatar;

                                    avt = false;
                                }
                                else
                                {
                                    Console.WriteLine("You Have Enter  Wrong Avatar");
                                    Console.WriteLine("Please Enter Avatar From above given Avatar");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please try again.");
                        }
                    }
                  
                }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            }



           


        }

        private static void DisplayStats(GameDetails details)
        {
            Console.WriteLine("No Of Armors:" + details.Armor);
            Console.WriteLine("Health:" + details.Health);
            Console.WriteLine("No of Gold:" + details.Gold);
        }
    }
}
