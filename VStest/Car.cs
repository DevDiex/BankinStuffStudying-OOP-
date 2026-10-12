using System;
using System.Collections.Generic;
using System.Text;

namespace VStest
{

    public class Car
    {
        public string? Model { get; private set; }
        public int Fuel { get; private set; }
        public int MaxFuel { get; private set; }
        public bool IsInRepair { get; private set; } = false;
        public string? DriverName { get; private set; }
        public bool GameRunning { get; set; } = true;



        public Car(string? model, int fuel, int maxFuel, bool isInRepair, string? driverName)
        {
            Model = model;
            Fuel = fuel;
            MaxFuel = maxFuel;
            IsInRepair = isInRepair;
            DriverName = driverName;
        }


    }
}