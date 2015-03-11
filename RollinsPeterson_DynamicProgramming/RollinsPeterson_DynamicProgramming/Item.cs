using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollinsPeterson_DynamicProgramming
{
    class Item
    {
        public int Value { get; set; }
        public int Weight { get; set; }

        public Item(int val, int weight)
        {
            Value = val;
            Weight = weight;
        }
    }
}
