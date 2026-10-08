using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using VStest;

namespace VStest
{
    public class GarageManager
    {
        // Сверхзащищенный список машин (инкапсуляция коллекций)
        private List<Car> _cars = new List<Car>();
        private int _maxCapacity; // Максимальная вместимость гаража


        public GarageManager(int maxCapacity)
        {
            _maxCapacity = maxCapacity;
        }

        public bool AddCar(Car car)
        {
            if (_cars.Count >= _maxCapacity)
            {
                Console.WriteLine("Ошибка: Кол-во машин в гараже максимально");
                return false;
            }

            _cars.Add(car);
            Console.WriteLine("Ваша машина успешна добавлена в гараж");
            Console.WriteLine($"{_cars.Count} авто в гараже");
            return true;
        }
        public void ShowAllCars()
        {
            Console.WriteLine("-- Список Машин в Гараже --");
            if (_cars.Count == 0)
            {
                Console.WriteLine("Ваш гараж пуст");
                return;
            }

            foreach (Car car in _cars)
            {
                Console.WriteLine($"{car.Model} с {car.Color} цветом и {car.Fuel} литрами топлива из максимальных {car.MaxFuel}");
            }
        }


        public void DriveAllCars(int distance)
        {
            Console.WriteLine($"-- Отправка автопарка в рейс на {distance} километра(ов)");

            foreach (Car car in _cars)
            {
                car.Drive(distance);
            }

        }

    }
}


//Метод фильтраций - .where() - foreach + if

    //public void LowFuelCars()
    //{

    //    Console.WriteLine("Машины которым нужна заправка")



    //    List<Car> lowfuelcar _cars.Where(car => car.Fuel < 10).ToList()

    //        foreach (var car in LowFuelCars)
    //    {
    //        Console.WriteLine($"{car.Model} - срочно заправить, Осталось {car.Fuel} л.")
    //    }
    //}

// Поиск одного элемента - .FirstOrDefault()
//    public void FindCarByModeL(string modelName)
//{
//    Car? foundCar = _cars.FirstOrDefault(car => car.ModelName == modelName);

//    if (foundCar != null)
//    {
//        Console.WriteLine($"Машина найдена, {foundCar.Model} - ее модель и {foundCar.Color} - ее цвет");
//    }
//    else
//    {
//        Console.WriteLine("такой машины нет в гараже");
//    }
//}

// Метод сортировки .OrderBy() или .OrderByDescending();
//public void ShowCarsSortedFuel()
//{
//    Console.WriteLine("Вывод машин по топливу от большего бака к меньшему");

//    var SortedCars = _cars.OrderByDescending(car => car.MaxFuel).Tolist();

//    foreach (var car in SortedCars)
//    {
//        Console.WriteLine($"{car.MaxFuel} л. Бак. {car.Model} - модель");
//    }
//}