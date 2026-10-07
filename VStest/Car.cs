using System;
using System.Collections.Generic;
using System.Text;

namespace VStest
{

    public class Car
    {
        // Открытые свойства без возможности их изменить вне класса
        public string? Model { get; private set; }
        public string? Color { get; private set; }
        public double Fuel { get; private set; }
        public double MaxFuel { get; private set; }

        // Конструктор
        public Car(string model, string color, double maxfuel)
        {
            Model = model;
            Color = color;
            if (maxfuel <= 0)
            {
                maxfuel = 25;
            }
            MaxFuel = maxfuel;

            Fuel = maxfuel;

        }

        public bool Drive(int distance)
        {
            // Предположим что на 1 км 0.1 литр бензина
            double fuelNeeded = distance * 0.1;

            if (fuelNeeded > Fuel)
            {
                Console.WriteLine("Не хватает Бензина, Заправь машину урод");
                return false;
            }

            Fuel -= fuelNeeded;
            Console.WriteLine($"Успешно проехали {distance}");
            return true;
        }
        // метод заправки
        public void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Ошибка: Вы не можете заправить 0 литрами");
                return;
            }

            Console.WriteLine($"Бак успешно заправлен на {liters} литров - ваш бак равен {Fuel}");
            Fuel += liters;

            if (Fuel > MaxFuel)
            {
                Fuel = MaxFuel;
                Console.WriteLine("Вы заправили полный бак");
                return;
            }
        }
    }
}

