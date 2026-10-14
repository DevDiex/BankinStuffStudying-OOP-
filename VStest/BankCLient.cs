using System;
using System.Collections.Generic;
using System.Text;

namespace VStest
{
    public class BankCLient
    {
        public string? Name { get; private set; }
        public double Balance { get; private set; }
        public bool IsBlocked { get; private set; }
        public int FailedAttempts { get; private set; } // Неверные попытки ввода
        public string? CardType { get; private set; } // тип карты - "Gold", "Silver", "Platinum", "Base" 

        public BankCLient(string? name, double balance, bool isBlocked, int failedAttempts, string? cardType)
        {
            Name = name;
            Balance = balance;
            IsBlocked = isBlocked;
            FailedAttempts = failedAttempts;
            CardType = cardType;
        }
    }
}
