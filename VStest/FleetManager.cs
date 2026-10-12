using System;
using System.Collections.Generic;
using System.Text;

namespace VStest
{
    public class FleetManager
    {

        private List<Car> _cars = new List<Car>()
        {
            new Car("MAN truck", 80, 400, false, "Pidr"),
            new Car("Volvo fr", 350, 500, false, "Iran"),
            new Car("Kamaz" ,200, 350, true, "Peter")
        };

        public void ShowAllDriver()
        {
            Console.WriteLine("Список всех работающих водителей");

            // Метод .Select() берет каждую машину и откусывает от нее только строковое значение (свойство с типом данных string?)
            // На выходе дает List<string> со свойствами DriverName вместо List<Car>
            List<string?> drivers = _cars.Select(car => car.DriverName).ToList();

            foreach (string? driver in drivers)
            {
                Console.WriteLine($"Водитель: {driver}");
            }
        }

        public void CheckEmergency()
        {
            Console.WriteLine("Сканирование автопарка на уровень топлива (низкий)");

            // Any() метод - true/false
            // Проверка условия (например: Топливо < 15 И ПРИ ЭТОМ машина не в ремонте (!c.IsInRepair)

            bool hasEmergencyCars = _cars.Any(car => car.Fuel < 15 && !car.IsInRepair);


            if (hasEmergencyCars)
            {
                Console.WriteLine("Есть машины требующие заправки");
            }
            else
            {
                Console.WriteLine("Все впорядке");
            }
        }
        public void PrintRepairCars()
        {
            Console.WriteLine("Отчет по состоянию автопарка");

            // Передаем условие прямов в метод Count().
            // Не нужно делать .Where().ToList().Count
            int brokenCars = _cars.Count(car => car.IsInRepair);

            // Считываем рабочие машины, можно через отрицание (!car.IsInRepair), либо просто вычитанием
            int workingcars = _cars.Count - brokenCars;

            Console.WriteLine($"Всего машин:{_cars.Count} шт");
            Console.WriteLine($"В ремонте: {brokenCars} шт");
            Console.WriteLine($"Работающих машин: {workingcars} шт");

        }

        public void ShowTopThreeFuelCars()
        {
            Console.WriteLine("наибольшее кол-во топлива");

            // сортировка идет по убыванию и выбираем первые три через Take(3) как самые полные машины и через .ToList() создаем с ними 3-емя новый список
            List<Car> topCars = _cars.OrderByDescending(car => car.Fuel).Take(3).ToList();

            int position = 1;
            foreach (Car car in topCars)
            {
                Console.WriteLine($"{position}, {car.Model} - {car.Fuel}/{car.MaxFuel} Л. {car.DriverName} - имя водителя");
                position++;
            }
        }
    }
}