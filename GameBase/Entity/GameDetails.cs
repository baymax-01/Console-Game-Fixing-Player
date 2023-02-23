using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBase.Entity
{
    class GameDetails
    {
        public string Username { get; set; }
        public int Armor { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public int MonsterKilled { get; set; }
        //For Load the Existing User From Text files
        public static GameDetails LoadGameDetails(string username)
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
            foreach (string[] record in loadedRecords)
            {
                GameDetails gameDetails = new GameDetails();
                gameDetails.Username = record[0];
                gameDetails.Armor = int.Parse(record[1]);
                gameDetails.Health = int.Parse(record[2]);
                gameDetails.Gold = int.Parse(record[3]);
                gameDetails.MonsterKilled = int.Parse(record[4]);
                gameDetails.Level = int.Parse(record[5]);
                Console.WriteLine();
                if (gameDetails.Username == username)
                {
                    return gameDetails;
                }
            }
            return null;
        }
        public static void SaveGameDetails(GameDetails gameDetails)
        {
            string filePath = "Resource/Savegame1.txt";
            string tempFilePath = "Resource/temp1.txt";

            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {

                writer.WriteLine($"{gameDetails.Username},{gameDetails.Armor},{gameDetails.Health},{gameDetails.Gold},{gameDetails.MonsterKilled},{gameDetails.Level + 1}");
                // copy the contents of the original file to the end of the temp file
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            // delete the original file and rename the temp file to the original file name
            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }

    }
}
