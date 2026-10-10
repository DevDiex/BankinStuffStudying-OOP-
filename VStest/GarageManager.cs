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

        public void ShowReadyForTripCars()
        {

            Console.WriteLine("\n -- Машины, готовые к дальнему рейсу (бак >= 50%) --");

            // LINQ запрос
            List<Car> readyCars = _cars.Where(c => c.Fuel >= (c.MaxFuel / 2)).ToList();

            // Проверяем если что-то нашли
            if (readyCars.Count == 0)
            {
                Console.WriteLine("Ни одна машина не готова к рейсу");
                return;
            }

            // Вывод результата
            foreach (Car car in readyCars)
            {
                Console.WriteLine($"({car.Model}) ({car.Color}) - готова, Топливо: {car.Fuel}/{car.MaxFuel}");

            }
            // ToList() - создает отдельный новый список не меняя старый для удобства который может быть изменен (только с нашими свойствами список)
        }

        public void FindCarByModel(string searchModel)
        {
            Console.WriteLine($"\n -- Поиск машины по модели: {searchModel}");

            // LINQ ищет первую машину совпадующую с запросом
            // .ToLower() - нужен чтобы поиск работал независимо от регистра (bmw, BMW, Bmw) - без разницы
            Car? foundCar = _cars.FirstOrDefault(c => c.Model.ToLower() == searchModel.ToLower());

            if (foundCar == null)
            {
                Console.WriteLine($"Модель {searchModel} была не найдена в вашем гараже");
            }
            else
            {
                Console.WriteLine($" {foundCar.Model} с цветом {foundCar.Color} была успешно найдена в гараже");
            }
            // First - останавливает список сразу экономя время процессора доходя до первой машины по свойству
            // OrDefault - пройдя список и ничего не найдя будет по умолчанию значением Null без вылета с ошибкой
        }

        public void ShowCarByFuel()
        {
            Console.WriteLine("\n -- Сортировка автопарка по уровню топлива (от большего к меньшему) -- ");

            if (_cars.Count == 0)
            {
                Console.WriteLine("Машин в гараже не найдено");
                return;
            }

            // Сортировка списка по убыванию свойства fuel
            List<Car> sortedCars = _cars.OrderByDescending(car => car.Fuel).ToList();

            foreach (Car car in sortedCars)
            {
                Console.WriteLine($"{car.Model} с {car.Fuel} литрами топлива");
            }
        }
        // Чем то схоже с методом пузырька

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