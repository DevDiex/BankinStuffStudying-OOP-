using System;
using System.Collections.Generic;
using System.Text;

namespace VStest
{
    public class Program
    {

        static void Main(string[] args)

        {
            FleetManager FleetConstructor = new FleetManager();


            while (true)
            {

                Console.WriteLine("1 - Вывести всех водителей");
                Console.WriteLine("2 - Просканировать на низкий уровень топлива");
                Console.WriteLine("3 - ");
                Console.WriteLine("4 - ");
                Console.Write("Выберите действие: ");

                string? command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        FleetConstructor.ShowAllDriver();
                        Console.ReadKey();
                        break;

                    case "2":
                        FleetConstructor.CheckEmergency();
                        Console.ReadKey();
                        break;

                }

            }

        }


    }
}
