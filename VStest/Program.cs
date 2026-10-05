using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        BankCard myCard = new BankCard("4276 1234 5678 9012", "Arthur", "1111", 500); // Создание конкретной карты на 500 рублей с ПИНОМ: 1111
        while (true)
        {


            if (myCard.CardIsBlocked())
            {
                Console.WriteLine("[Банкомат]: Ваша карта заблокирована");
                Console.WriteLine("Заберите вашу карту...");
                return;
            }

            Console.WriteLine("МЕНЮ БАНКОМАТА");
            Console.WriteLine("1 - Проверить баланс карты ");
            Console.WriteLine("2 - Пополнить баланс карты");
            Console.WriteLine("3 - Снять деньги с карты");
            Console.WriteLine("4 - Выйти");
            Console.WriteLine("5 - Поменять пин-код карты");
            Console.WriteLine("Выберите действие");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":




                    Console.WriteLine("Введите 4-ех значный код");
                    string? userPin = Console.ReadLine();


                    if (myCard.IsPinCorrect2(userPin) == false)
                    {
                        if (myCard.CardIsBlocked() == true)
                        {
                            Console.WriteLine("Ошибка: соси яица");
                        }
                        else
                        {
                            myCard.CheckBalance(userPin);
                        }

                    }
                    Console.ReadKey();
                    break;

                case "2":
                    {
                        Console.WriteLine("-- Пополнение счета --");
                        Console.Write("Введите пин-код: ");
                        string? userPin2 = Console.ReadLine();

                        if (int.TryParse(userPin2, out int realPin) == false || string.IsNullOrWhiteSpace(userPin2))
                        {
                            Console.WriteLine("Ошибка: Неверный пин-код");
                            Console.ReadKey();
                            continue;
                        }

                        if (myCard.IsPinCorrect2(userPin2) == false)
                        {
                            // Проверка заблокирована ли карта прямо сейчас или уже была
                            if (myCard.CardIsBlocked() == true)
                            {
                                Console.WriteLine("Ваша карта заблокирована: Максимальное кол-во попыток (3) было потрачено");
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: Неверный пин-код");
                            }
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write("Введите сумму пополнения: ");

                        string? inputerMoney = Console.ReadLine();

                        // Считывание строки и безопасный перевод


                        if (decimal.TryParse(inputerMoney, out decimal inputBalance) == false || string.IsNullOrWhiteSpace(inputerMoney))
                        {
                            Console.WriteLine("Ошибка: вы ввели неккоректную сумму");
                            Console.ReadKey();
                            continue; // Возврат в меню while
                        }


                        myCard.DepositMoney(inputBalance);
                        Console.ReadKey();
                    }

                    break;

                case "3":
                    {
                        Console.WriteLine("-- Снятие денег --");
                        Console.Write("Введите пинки пай: ");

                        string? withDrawPin = Console.ReadLine();

                        if (int.TryParse(withDrawPin, out int pin) == false || string.IsNullOrWhiteSpace(withDrawPin))
                        {
                            Console.WriteLine("Ошибка: Неверный пин-код");
                            Console.ReadKey();
                            continue;
                        }

                        if (myCard.IsPinCorrect2(withDrawPin) == false)
                        {

                            if (myCard.CardIsBlocked() == true)
                            {
                                Console.WriteLine("Карта заблокирована: пароль был введен неверно 3 раза");
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: Неверный пинкод");
                            }
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write("Введите сумму для снятия денег: ");

                        string? amount = Console.ReadLine();

                        if (decimal.TryParse(amount, out decimal money) == false || string.IsNullOrWhiteSpace(amount))
                        {
                            Console.WriteLine("Ошибка: Неверный формат");
                            Console.ReadKey();
                            continue;
                        }

                        if (myCard.WithDrawMoney(withDrawPin, money))
                        {
                            Console.WriteLine("Ваши деньги успешно списаны");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка.");
                        }
                        Console.ReadKey();
                    }
                    break;

                case "4":
                    {
                        Console.WriteLine("Выходим...");
                        Console.WriteLine("Заберите карту! удачного дня");
                        return;
                    }
                case "5":
                    {
                        Console.WriteLine("-- Смена Пин-кода --");

                        Console.Write("Введите текущий пин-код: ");
                        string? pinp = Console.ReadLine();

                        Console.WriteLine("Введите новый 4-ех значный пин-код");
                        string? newPinp = Console.ReadLine();

                        // отдаем данные карте, по правилам инкапсуляций произойдет проверка

                        if (myCard.ChangePin(pinp, newPinp))
                        {
                            Console.WriteLine("Успешно изменен пин-код");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Неверный старый пин-код или новый пин неккоректен (должен отличаться от старого и состоять из 4 символов)");
                        }
                        Console.ReadKey();
                    }
                    break;
            }
        }
    }
}