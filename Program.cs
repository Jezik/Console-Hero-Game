using System;
using System.IO;
using System.Threading;

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

            // TODO: If condition to check for existing saved games

            // 2. Create Hero
            Hero player = new Hero();

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
                        // SaveGame();
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
    }
}
