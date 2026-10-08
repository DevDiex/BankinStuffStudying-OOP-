using System;
using System.Collections.Generic;
using System.Text;

namespace VStest
{
    public class Program
    {


        static void Main(string[] args)
        {

            GarageManager manager = new GarageManager(3);

            while (true)
            {
                Console.WriteLine("\nМеню Автопарка:");
                Console.WriteLine("1 - Показать все машины в гараже");
                Console.WriteLine("2 - Добавить новую машину в ручную");
                Console.WriteLine("3 - Отправить машины в рейс");
                Console.WriteLine("4 - выйти");
                Console.Write("Выберите действие: ");

                string? input = Console.ReadLine();

                switch (input)
                {

                    case "1":
                        manager.ShowAllCars();
                        break;

                    case "2":
                        Console.Write("Введите модель машины: ");
                        string? model = Console.ReadLine();

                        Console.Write("Введите цвет машины: ");
                        string? newColor = Console.ReadLine();

                        Console.Write("Введите объем бака машины (в литрах): ");
                        if (double.TryParse(Console.ReadLine(), out double maxFuel))
                        {
                            Car newCar = new Car(model, newColor, maxFuel);
                            if (manager.AddCar(newCar))
                            {
                                Console.WriteLine("Машина успешно добавлена в гараж");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка неверный формат обьема бака");

                        }
                        break;

                    case "3":
                        Console.Write("Введите дистанцию для рейса (КМ): ");
                        if (int.TryParse(Console.ReadLine(), out int distance))
                        {
                            manager.DriveAllCars(distance);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Неверный формат дистанций");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Ваш самолет падает");
                        return;

                    default:
                        Console.WriteLine("Неверный пункт меню");
                        break;
                }
            }
        }
    }
}