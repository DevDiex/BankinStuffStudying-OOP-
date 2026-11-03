using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VStest
{
    public class Program
    {
        static void Main(string[] args)
        {
            ApiaryManager apMan = new ApiaryManager();
            List<Bee> tiredBees = apMan._HivesList.SelectMany(hive => hive.Bees).Where(bee => bee.Energy < 20).ToList();
            var sumHoney = apMan._HivesList.SelectMany(Hive => Hive.Bees).Where(Bee => Bee.Role == "Worker").Sum(bee => bee.CollectedHoneyGram);

            while (true)
            {
                Console.WriteLine("Добро пожаловать в медовую Пасеку");



                Console.WriteLine("1 - Вывести пчел с энергией меньше 20 и накормить их");
                Console.WriteLine("2 - вывести статистику сбора пчел");
                Console.WriteLine("3 - показать улей чемпион");
                


                string? Command = Console.ReadLine();

                switch (Command)
                {
                    case "1":
                        // SelectMany превращает List<BeeHive> в общий List<Bee> всех ульев

                        foreach (Bee bee in tiredBees)
                        {
                            Console.WriteLine($"{bee.Name} с ролью {bee.Role} требуют подпитки");
                            Console.Write($"\n Для подпитки нажмите Enter: ");
                            Console.ReadKey();
                            bee.Energy += 25;
                            Console.WriteLine($"{bee.Name} успешно покормлена");
                        }
                        break;


                    case "2":
                        Console.WriteLine($"Ваши пчелы собирают {sumHoney} грамм меда");
                        Console.ReadKey();
                        break;

                    case "3":
                        apMan.ShowChampionHive();
                        Console.WriteLine("Удачи позорник, увидимся на следующем уроке");
                        Console.ReadKey();
                        break;
                }

            }

        }
}
}
