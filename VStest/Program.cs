using System;
using System.Collections.Generic;
using System.Text;

namespace VStest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать на арену смерти");

            Hero warrior = new Hero("MegaKnight", 500, 75);
            Hero monster = new Hero("Ice Wizard", 250, 45);


            Console.WriteLine($"На арену выходят {warrior.Name} с {warrior.Health} ХП и {warrior.Damage} урона");
            Console.WriteLine("Нажмите enter чтобы продолжить...");
            Console.ReadKey();

            int round = 1;

            while (warrior.Health > 0 && monster.Health > 0)
            {
                Console.Clear(); // очистка консоли для красоты с каждого нового раунда
                Console.WriteLine($"РАУНД номер {round} начинается");
                Console.WriteLine($"{warrior.Name}: {warrior.Health} HP | {monster.Name}: {monster.Health} HP");

                // Ход рыцаря - 1-ый
                warrior.Attack(monster);

                if (monster.Health <= 0)
                {
                    Console.WriteLine($"{monster.Name} пал");
                    Console.WriteLine($"Победил {warrior.Name}");
                    break;
                }

                Console.WriteLine();

                if (warrior.Health <= 0)
                {
                    Console.WriteLine($"{warrior.Name} пал");
                    Console.WriteLine($"Победил {monster.Name}");
                    break;
                }

                round++;
                Console.WriteLine($"\nНажмите Enter для того чтобы продолжить...");
                Console.ReadKey();
            }
            Console.WriteLine();
            Console.ReadKey();
            ;
        }
    }
}
