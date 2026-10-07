using System;
using System.Collections.Generic;
using System.Text;

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
            else if (_cars.Count != 0)
            {
                foreach (Car car in _cars)
                {
                    Console.WriteLine($"{car.Model} с {car.Color} цветом и {car.Fuel} литрами топлива из максимальных {car.MaxFuel}");
                }
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
