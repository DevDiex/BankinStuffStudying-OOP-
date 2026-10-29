using System;
using System.Collections.Generic;
using System.Text;

namespace VStest
{
    public class Hero
    {
        public string? Name { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }

        public Hero(string? name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }

            Console.WriteLine($"{Name} получил {damage} урона. Осталось {Health} HP");
        }

        public void Attack(Hero target)
        {
            Console.WriteLine($"{Name} замахивается мечом на {target.Name}");

            target.TakeDamage(Damage);
        }
    }
}
