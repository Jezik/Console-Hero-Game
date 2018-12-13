using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Console_Hero_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Welcome to a game 
            Console.WriteLine("***************");
            Console.WriteLine("Welcome to a world number one console game \nwith blackjack and schluckhi!!! \nha-ha-ha with heroes and monsters of course!");
            Console.WriteLine("***************\n");

            // If condition to check for existing saved games
            if (HasFiles())
            {
                Console.WriteLine("Would you like to load existing game or start a new one?");
                Console.WriteLine("Press 'n' to start a new one or press 'l' to load saved game.");
                
                for (int i=0; i<3; i++)
                {
                    string str = Console.ReadLine();
                    if (str.ToLower().Equals("l"))
                    {
                        Console.WriteLine("Enter the nickname of your hero.");
                        string nickname = Console.ReadLine();
                        string fileName = "hero_" + nickname + ".chmg";
                        string pathFile = Path.Combine(Utils.pathFolder, fileName);
                        if (File.Exists(pathFile))
                        {
                            LoadGame(nickname);
                        }
                        else
                        {
                            Console.WriteLine("There is no such saved game. We'll start a new one.");
                            NewGame();
                        }
                        i = 3;
                    }
                    else if (str.ToLower().Equals("n"))
                    {
                        NewGame();
                        i = 3;
                    }
                    else
                    {
                        Console.WriteLine("Enter only 'l' or 'n'");
                        if (i == 2)
                        {
                            Console.WriteLine("You are Serega, aren't you?");
                            Console.WriteLine("We will start a new game");
                            NewGame();
                        }
                    }
                }
            }
            else
            {
                NewGame();
            }
                    
        }

        // New Game
        private static void NewGame()
        {
            // 2. Create Hero
            Hero player = new Hero();
            PlayGame(player);
        }

        // Main method of our game
        private static void PlayGame(Hero player)
        {            
            // Main game loop
            bool isGame = true; // Variable for controlling game-flow
            while(isGame)
            {
                // 3. Create first Monster
                Monster monster = new Monster();
                // 4. Battle
                KillMonster(player, monster);
                // 5. Show new Hero's stats
                player.ShowHeroStats();
                // 6. Continue game or save game
                Console.WriteLine("Continue game or save game?");
                Console.WriteLine("Press 'y' to continue and 'n' to save a game");
                for (int i=0; i<3; i++)
                {
                    string str = Console.ReadLine();
                    if (str.ToLower().Equals("y"))
                    {
                        i = 3;
                    }
                    else if (str.ToLower().Equals("n"))
                    {
                        isGame = false;
                        i = 3;
                        SaveGame(player);
                    }
                    else
                    {
                        Console.WriteLine("Please, enter only 'y' or 'n'");
                        if (i == 2)
                        {
                            Console.WriteLine("I think you are Serega... We will continue this game");                            
                        }
                    }
                }
            }    
        }

        // Just kill this monster
        private static void KillMonster(Hero hero, Monster monster)
        {
            Console.WriteLine("Your enemy is: \n{0} with {1} experince.\n", monster.MonsterName, monster.MonsterExperience);
            Console.WriteLine("FIGHT!!!\nPress any button to start.");
            Console.ReadKey();
            Console.Write("...");
            Thread.Sleep(2000);
            Console.WriteLine("...");
            Console.WriteLine("Victory!!!");

            hero.Experience += monster.MonsterExperience;
            hero.NumberOfKills += 1;
            hero.Level = hero.Experience;
        }

        // Save current game
        private static void SaveGame(Hero hero)
        {
            //string pathDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //tring pathFolder = Path.Combine(pathDoc, "Hero save");

            Directory.CreateDirectory(Utils.pathFolder);

            string fileName = "hero_" + hero.Nickname + ".chmg"; 
            string pathFile = Path.Combine(Utils.pathFolder, fileName);

            Dictionary<int, string> fields = new Dictionary<int, string>(4);
            fields.Add(1, hero.Nickname);
            fields.Add(2, hero.Experience.ToString());
            fields.Add(3, hero.NumberOfKills.ToString());
            fields.Add(4, hero.Level.ToString());

            using (StreamWriter sw = new StreamWriter(pathFile, false, Encoding.Default))
            {
                foreach (var entry in fields)
                    sw.WriteLine("{0} {1}", entry.Key, entry.Value);
            }
        }

        // Load Game
        private static void LoadGame(string nickname)
        {
            string fileName = "hero_" + nickname + ".chmg";
            string pathFile = Path.Combine(Utils.pathFolder, fileName);

            Hero player = new Hero(pathFile);
            player.ShowHeroStats();
            PlayGame(player);
        }

        // Check if there are any saved games
        private static bool HasFiles()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Utils.pathFolder);
                return dirInfo.GetFiles("*.chmg").Length > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
