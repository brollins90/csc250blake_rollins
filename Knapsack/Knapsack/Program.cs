using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> stuffs = new List<Item>()
            {
                new Item()
                {
                    Weight = 2,
                    Value = 12
                },
                new Item()
                {
                    Weight = 1,
                    Value = 10
                },
                new Item()
                {
                    Weight = 3,
                    Value = 20
                },
                new Item()
                {
                    Weight = 2,
                    Value = 15
                },
            };

            int[,] res = Knapsack.CalculateKnapsack(stuffs, 5);

            for (int row = 0; row < res.GetLength(0); row++)
            {
                for (int col = 0; col < res.GetLength(1); col++)
                {
                    Console.Write(res[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
