using System;
using System.Collections.Generic;
using System.Text;

public class BankCard
{
    // Открытые свойства
    public string? CardNumber { get; private set; }
    public string? OwnerName { get; private set; }


    // Сверхзащищенные поля (инкапсуляция)
    // private перед переменными, чтобы не было видно из других методов и классов через точку

    private decimal _balance;
    private string? _pinCode;

    private int _failedPinAttempts = 0; // Счетчик ошибок
    private bool _isBlocked = false; // Статус блокировки

    public BankCard(string cardnumber, string ownername, string pinCode, decimal startBalance) // Создание конструктора который в последствий работает с созданием объектов строго по шаблону
    {
        CardNumber = cardnumber;
        OwnerName = ownername;
        _pinCode = pinCode;

        if (startBalance < 0)
        {
            _balance = 0;
        }
        else
        {
            _balance = startBalance;
        }

    }

    public void CheckBalance(string? inputPin)
    {
        if (_isBlocked)
        {
            Console.WriteLine("Ошибка: Карта Заблокирована");
            Console.ReadKey();
            return;
        }



        if (inputPin == _pinCode)
        {
            Console.WriteLine("[Банкомат]: Авторизация успешна");
            Console.WriteLine($"[Банкомат]: Ваш текущий баланс: {_balance} рублей");
        }
        else
        {
            Console.WriteLine("Ошибка авторизаций: Неверный пин-код");
        }

    }


    public bool CardIsBlocked()
    {
        return _isBlocked;
    }



    public void DepositMoney(decimal inputBalance)
    {

        if (inputBalance <= 0)
        {
            Console.WriteLine("Ошибка: Сумма пополнения должна быть больше нуля");
            return;
        }

        _balance += inputBalance;
        Console.WriteLine($"Счет успешно пополнен на {inputBalance} рублей");
        Console.WriteLine("Ваш текущий баланс обновлен");
    }

    public bool WithDrawMoney(string? inputPin, decimal inputBalance)
    {
        if (_isBlocked)
        {
            return false; // Карта заблокирована

        }

        // Проверка пин-кода
        if (inputPin != _pinCode)
        {
            return false;
        }

        // Проверка хватает ли денег на карте (в отрицательную)
        if (inputBalance <= 0)
        {
            return false;
        }
        // Проверка хватает ли денег на карте (в положительную)
        if (inputBalance > _balance)
        {
            return false;
        }

        // Если все проверки прошли, меняем баланс
        _balance -= inputBalance;
        return true;
    }

    public bool IsPinCorrect2(string? InputPin)
    {
        if (_isBlocked)
        {
            return false;
        }

        if (InputPin == _pinCode)
        {
            _failedPinAttempts = 0; // Пин верный, Счетчик сбрасывается в 0 ошибок
            return true;
        }
        else
        {
            _failedPinAttempts++; // Ошибка - увеличение ошибок на одну

            if (_failedPinAttempts >= 3)
            {
                _isBlocked = true;
            }

            return false;
        }
    }

    public bool ChangePin(string? OldPin, string? newPin)
    {
        // Если карта заблокирована - ничего не делаем
        if (_isBlocked)
        {
            return false;
        }

        if (OldPin != _pinCode)
        {
            return false; // Старый пин-код неверен
        }

        if (string.IsNullOrWhiteSpace(newPin) || newPin.Length != 4 || int.TryParse(newPin, out _) == false)
        {
            return false;
        }

        if (newPin == _pinCode)
        {
            return false;
        }

        _pinCode = newPin;
        return true;
    }
}