using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VStest
{
    public class BeeHive
    {
        public int Id { get; set; }
        public string? Material { get; set; } // дерево или пластик
        public List<Bee> Bees { get; set; } // Матрешка!, список пчел внутри улья

        public BeeHive(int id, string? material, List<Bee> bees)
        {
            Id = id;
            Material = material;
            Bees = bees;
        }
    }
}
