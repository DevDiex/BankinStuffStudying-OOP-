using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VStest
{
    public class ApiaryManager
    {
        public List<BeeHive> _HivesList = new List<BeeHive>()
        {
            new BeeHive(1, "Wood", new List<Bee>()
            {
                new Bee("Rage bee", "Guard", 15, 25),
                new Bee("Cool bee", "Worker", 19, 65),
                new Bee("Wasp Killer", "Attacker-Guard", 110, 0),
                new Bee("Queen Bee", "Queen", 500, 0)
            }),

            new BeeHive(2, "Plastic", new List<Bee>()
            {
                new Bee("Systemic Bee", "Worker", 120, 96),
                new Bee("Trader Bee", "Worker", 7, 1500),
                new Bee("SeniorQBee", "Queen", 100, 0),
                new Bee("GuardianicBee", "Guard", 15, 0)
            }),
            new BeeHive(3, "Wood", new List<Bee>()
            {
               new Bee("Cheap", "Worker", 80, 67),
               new Bee("Boltica", "Queen", 18, 0),
               new Bee("RockFord", "Worker", 150, 80)
            })
        };

        public void ShowChampionHive()
        {
            Console.WriteLine("Поиск самого лучшего улья из трех");

            // результат запрроса ложится в переменную типа BeeHive? и может быть Null если пасека пуста
            BeeHive? Champion = _HivesList.OrderByDescending(hive => hive.Bees.Sum(bee => bee.CollectedHoneyGram)).FirstOrDefault();

            // если ульев вообще не будет в списке
            if (Champion == null)
            {
                Console.WriteLine("на пасеке нету ульев");
                return;
            }

            // вывод информаций на экран (id, material, honeycollectedgram) - номер улья с материалом и собранным медом
            // вместо отдельного сложного запроса для вывода сукммы можно подсчитать ее отдельно
            int totalHoney = Champion.Bees.Sum(b => b.CollectedHoneyGram);

            Console.WriteLine($"Champion Gladiator: {Champion.Id} || {Champion.Material}");
            Console.WriteLine($"Собрано этим ульем {totalHoney} грамм меда");
        }
    }
}
