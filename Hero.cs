using System;
using System.IO;

namespace Console_Hero_Game
{
    public class Hero
    {
        // Class fields
        private string nickname;
        private int experience;
        private int level;
        private int numberOfKills;

        // Constrcutor. Nickname will be set during first run in a Main() method
        public Hero()
        {
            Experience = 0;
            NumberOfKills = 0;
            Level = 1;

            try {
                Console.WriteLine("Enter the name of your character:");
                Nickname = Console.ReadLine();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error occured " + e);
            }
        }

        // Properties
        public string Nickname
        { 
            get
            {
                return nickname;
            }
            set
            {
                if (value.Length == 0)
                {
                    Console.WriteLine("Nickname must have one symbol at least");
                }
                else
                {
                    nickname = value;
                }
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
                    experience += value;
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
                    numberOfKills += value;
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