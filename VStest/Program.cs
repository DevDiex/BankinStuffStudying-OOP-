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

            // Создание коллекций обьектов типа (класса) <Hero>
            // каждый элемент внутри списка независимый полноценный обьект со своим хп и уроном
            List<Hero> Heroes = new List<Hero>()
            {
                new Hero("Alexey Navalniy", 5000, 150),
                new Hero("Putin", 10000, 175),
                new Hero("VaZOV", 3000, 95)

            };

            List<Hero> Villains = new List<Hero>()
            {
                new Hero("Zelenskiy", 6500, 115),
                new Hero("Stalin", 1000000, 125),
                new Hero("Tesak", 500, 0)
            };


            int round = 1;

            // .Any - проверят есть ли в списке хотя бы один элемент подходящий под условие
            // цикл while будет кружиться пока у героев есть хотя бы один живой персонаж (> 0)
            // если в одной из команд умрут все .Any вернет false и все завершится (бой)
            while (Heroes.Any(h => h.Health > 0) && Villains.Any(h => h.Health > 0))
            {
                Console.Clear();
                Console.WriteLine($"раунд номер {round} начинается");


                // Sum. пробегается по всему списку по значениям свойствам health (складывает их между собой - удобно)
                
                int totalHeroesHP = Heroes.Sum(Heroes => Heroes.Health);
                int totalVillainsHP = Villains.Sum(monsters => monsters.Health);
                Console.WriteLine($"здоровье героев {totalHeroesHP} | здоровье монстров {totalVillainsHP}");


                // 1-ый ход героев
                Console.WriteLine("Очередь героев!");
                foreach (var HEROES in Heroes)
                {
                    // если героя убили он не может ходить (доп защита)
                    if (HEROES.Health <= 0)
                    {
                        Console.WriteLine($"{HEROES.Name} мертвы");
                        continue;
                    }

                    // умный тройной фильтр (1 - только живых, 2 - от меньшего хп к большему, 3 - забирает самого первого из отсортированной кучи)
                    Hero weakestMonster = Villains.Where(Villain => Villain.Health > 0).OrderBy(Villain => Villain.Health).FirstOrDefault();

                    // если нашелся живой монстр мы его атакуем
                    if (weakestMonster != null)
                    {
                        HEROES.Attack(weakestMonster);
                    }

                }
                // Проверка с LINQ .Any() на остаток живых монстров после атаки героев
                // Если не осталось (!), прерываем.
                if (!Villains.Any(Villain => Villain.Health > 0))
                {
                    break;
                }

                Console.WriteLine($"\nНажмите Enter чтобы монстры ответили своим ударом...");
                Console.ReadKey();
                // --------------

                Console.WriteLine("Ход монстров");
                foreach (var Monster in Villains)
                {
                    if (Monster.Health <= 0)
                    {
                        Console.WriteLine($"{Monster.Name} мертвы");
                        break;
                    }

                    var weakestHeroes = Heroes.Where(heroesHP => heroesHP.Health > 0).OrderBy(HeroesHP => HeroesHP.Health > 0).FirstOrDefault();

                    if (weakestHeroes != null)
                    {
                        Monster.Attack(weakestHeroes);
                    }
                }

                if (!Heroes.Any(HeroesHP => HeroesHP.Health > 0))
                {
                    break;
                }

                round++;
                Console.WriteLine("\n Нажмите Enter для следующего раунда...");
                Console.ReadKey();
            }

            Console.WriteLine("БОЙ ОКОНЧЕН!");


            if (Heroes.Any(HP => HP.Health > 0))
            {
                Console.WriteLine("Герои победили! УРА!");
            }
            else
            {
                Console.WriteLine("Монстры победили! НЕ УРА!");
            }
            Console.ReadKey();
        }
    }
}
