using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VStest
{
    public class Bee
    {
        public string? Name { get; set; }
        public string? Role { get; set; } // сборщик, охранник, трутень или королева
        public int Energy { get; set; } // от 0 до 100
        public int CollectedHoneyGram { get; set; } // мед за сегодня


        public Bee(string? name, string? role, int energy, int collectedHoneyGram)
        {
            Name = name;
            Role = role;
            Energy = energy;
            CollectedHoneyGram = collectedHoneyGram;
        }
    }
}
