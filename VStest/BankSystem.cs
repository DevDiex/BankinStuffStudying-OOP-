using System;
using System.Collections.Generic;
using System.Text;

namespace VStest
{


    public class BankSystem
    {
        private List<BankCLient> _bankCLients = new List<BankCLient>()
        {
            new BankCLient("Alexey", 12000, false, 0, "Platinum"),
            new BankCLient("Andrey", 255000, true, 3, "Gold"),
            new BankCLient("Anton", 235000, false, 2, "Platinum"),
            new BankCLient("Artem", 2222, false, 2, "Platinum"),
            new BankCLient("Olga", 12000, true, 3, "Silver")
        };


        public void ShowVipClients()
        {
            List<BankCLient> topClients = _bankCLients.Where(clients => clients.IsBlocked == false && (clients.CardType == "Platinum" || clients.CardType == "Gold")).OrderByDescending(clients => clients.Balance).ToList();

            foreach (BankCLient client in topClients)
            {
                Console.WriteLine($"{client}");
            }

        }

        public void CheckSecurityAlert()
        {
            Console.WriteLine("Сканирование банковской системы на ошибки ввода пин-кода");
            // Any - метод true/false, обычная проверка условий


            bool securityAlertPinAttempts = _bankCLients.Any(clients => !clients.IsBlocked && clients.FailedAttempts == 2);

            if (securityAlertPinAttempts)
            {
                Console.WriteLine("Лимит ввода пользователя был превышен: ");
            }
            else
            {
                Console.WriteLine("Пин-код был успешно введен");
            }

        }

        public void GetTotalDoubtfulMoney()
        {
            Console.WriteLine("Подсчет удерживаемых денежных средств на аккаунтах...");
            Thread.Sleep(1000);

            double DoubtfulMoney = _bankCLients.Where(clients => clients.IsBlocked == true).Sum(clients => clients.Balance);

            Console.WriteLine($"общая сумма замороженная на заблокированных аккаунтах: {DoubtfulMoney}");
        }
    }
}