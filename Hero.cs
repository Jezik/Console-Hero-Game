using System;

namespace Console_Hero_Game
{
    public class Hero
    {
        // Class fields
        private string nickname;
        private float experience;
        private int level;
        private int numberOfKills;

        // Constrcutor. Nickname will be set during first run in a Main() method
        public Hero(float experience, int level, int numberOfKills)
        {
            Experience = experience;
            Level = level;
            NumberOfKills = numberOfKills;
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

        public float Experience 
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
                level = (int)(Experience / 100) + 1;
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
    }
}