using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Game
{
    class PlayerStats
    {
        public int total_player_death { get; set; }
        public int total_damage_dealt { get; set; }
        public int total_damage_taken { get; set; }
        public int total_monster_killed { get; set; }
        public int total_gold { get; set; }
       
        //For Load the Existing User From Text files
        public static PlayerStats LoadPlayerstats()
        {
            string filePath = "Resource/Savegame1.txt";
            // Load the records from the file
            List<string[]> loadedRecords = new List<string[]>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] fields = line.Split(',');
                    loadedRecords.Add(fields);
                }
            }
            // Use the loaded records as needed

            // Calculate the sum of monsters killed for all users
            int sumMonstersKilled = 0, sumgold = 0, sumdamagetaken = 0, sumdamagedealt = 0;
            foreach (string[] record in loadedRecords)
            {
                int monstersKilled = int.Parse(record[4]);
                sumMonstersKilled += monstersKilled;
                int gold = int.Parse(record[3]);
                sumgold += gold;
                int damagetaken = int.Parse(record[2]);
                sumdamagetaken += (100 - damagetaken);
                int damagedealth = int.Parse(record[2]);
                sumdamagedealt += damagedealth;
            }
            PlayerStats player = new PlayerStats()
            {
                total_player_death = loadedRecords.Count(),
                total_gold=sumgold,
                total_monster_killed=sumMonstersKilled,
                total_damage_taken=sumdamagetaken,
                total_damage_dealt=sumdamagedealt
                
            };
            
            return player;
        }
      
    }
}
