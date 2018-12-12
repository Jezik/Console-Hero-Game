using System;

namespace Console_Hero_Game
{
    public class Monster
    {
        // Class fields
        private string monsterName;
        private int monsterExperince;

        // Constructor
        public Monster()
        {
            monsterName = SetMonsterName();
            monsterExperince = SetMonsterExperince();
        }

        // Properties
        public string MonsterName
        {
            get
            {
                return monsterName;
            }
        }

        public int MonsterExperience
        {
            get
            {
                return monsterExperince;
            }
        }


        // Generate monsterName
        private string SetMonsterName()
        {
            Random random = new Random();
            int nameLength = random.Next(3, 11);
            
            string name = "";
            for (int i = 0; i < nameLength; i++)
            {
                name += Utils.latinLetters[random.Next(0, 26)];
            }

            return name;
        }

        // Generate experince value for killing a monster
        private int SetMonsterExperince()
        {
            Random random = new Random();
            int experince = random.Next(0, 101);
            return experince;
        }
    }
}