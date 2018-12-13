using System;
using System.IO;
using System.Text;

namespace Console_Hero_Game
{
    public class Hero
    {
        // Class fields
        private string nickname;
        private int experience;
        private int level;
        private int numberOfKills;

        // Constructor. Nickname will be set during first run in a Main() method
        public Hero()
        {
            Experience = 0;
            NumberOfKills = 0;
            Level = 1;

            try {
                Console.WriteLine("Enter the name of your character:");
                for (int i=0; i<3; i++)
                {
                    string nick = Console.ReadLine();
                    if (nick.Length == 0)
                    {
                        if (i == 2)
                        {
                            Console.WriteLine("Are you crazy Serega? ONE SYMBOL AT LEAST!!!");
                            Console.WriteLine("Your nickname will be Serega");
                            Nickname = "Serega";
                        }
                        else
                        {
                            Console.WriteLine("Nickname must have one symbol at least. Try again.");
                        }
                    }
                    else
                    {
                        Nickname = nick;
                        i = 3;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error occured " + e);
            }
        }

        // Second constructor. Loading from a file
        public Hero(string filepath)
        {
            using (StreamReader sr = new StreamReader(filepath, Encoding.Default))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {   
                    string[] array = line.Split(" ");
                    switch (Int32.Parse(array[0]))
                    {
                        case 1:
                            Nickname = array[1];
                            break;
                        case 2:
                            Experience = Int32.Parse(array[1]);
                            break;
                        case 3:
                            NumberOfKills = Int32.Parse(array[1]);
                            break;
                        case 4:
                            Level = Int32.Parse(array[1]);
                            break;
                    }
                }
            }
        }

        // Properties
        public string Nickname
        { 
            get
            {
                return nickname;
            }
            private set
            {                
                nickname = value;
            } 
        }

        public int Experience 
        { 
            get
            {
                return experience;
            } 
            set
            {
                if (value > 0)
                {
                    experience = value;
                }
            }
        }

        public int Level 
        { 
            get
            {
                return level;
            }
            set
            {
                // TODO: implement more complex logic for level gain
                level = Experience / 100 + 1;
            } 
        }

        public int NumberOfKills
        {
            get
            {
                return numberOfKills;
            }
            set
            {
                if (value > 0)
                {
                    numberOfKills = value;
                }
            }
        }

        public void ShowHeroStats()
        {
            Console.WriteLine("{0}, your current stats are: ", Nickname);
            Console.WriteLine("Experince: {0}", Experience);
            Console.WriteLine("Level: {0}", Level);
            Console.WriteLine("Number of Kills: {0}\n", NumberOfKills);
        }
    }
}