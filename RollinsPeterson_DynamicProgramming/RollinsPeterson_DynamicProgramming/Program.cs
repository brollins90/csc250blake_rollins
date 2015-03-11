using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollinsPeterson_DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFromBook();
            TestFromClass();
        }

        private static void TestFromBook()
        {
            int packSize = 6;
            Console.WriteLine("Test given from book - Pack size: "+packSize);
            List<Item> items = new List<Item>();
            items.Add(new Item(25, 3));
            items.Add(new Item(20, 2));
            items.Add(new Item(15, 1));
            items.Add(new Item(40, 4));
            items.Add(new Item(50, 5));
            //items.Add(new Item(42, 7));
            //items.Add(new Item(12, 3));
            //items.Add(new Item(40, 4));
            //items.Add(new Item(25, 5));

            ChooseBestCombination(items, packSize);
        }

        private static void TestFromClass()
        {
            int packSize = 8;
            Console.WriteLine("Test given from class - Pack size: "+packSize);
            List<Item> items = new List<Item>();
            items.Add(new Item(250, 1));
            items.Add(new Item(400, 4));
            items.Add(new Item(500, 5));
            items.Add(new Item(150, 3));
            items.Add(new Item(50, 2));

            ChooseBestCombination(items, packSize);
        }

        private static void ChooseBestCombination(List<Item> list, int packSize)
        {
            PrintItems(list);
            packSize = packSize + 1;

            int chartHeight = list.Count +1;
            int chartWidth = packSize;
            int[,] chart = new int[chartWidth, chartHeight];
            for (int r = 0; r < chart.GetLength(0); r++)
                for (int c = 0; c < chart.GetLength(1); c++)
                    chart[r, c] = -1;

            for(int weight = 0; weight < packSize; weight++)
            {
                KnapSack knap = new KnapSack(weight);
                for(int itemIndex = 1; itemIndex < list.Count + 1; itemIndex++)
                {
                    knap.Add(list[itemIndex -1]);
                    chart[weight, itemIndex] = Math.Max(chart[weight, itemIndex], knap.GetMaxValue());
                }
            }

            //do algarithmy things here
            Dictionary<int, int> WeightsToValue = new Dictionary<int, int>();
            foreach(Item i in list)
            {
                if(WeightsToValue.ContainsKey(i.Weight) && WeightsToValue[i.Weight] < i.Value)
                {
                    WeightsToValue[i.Weight] = i.Value;
                }
                else
                {
                    WeightsToValue[i.Weight] = i.Value;
                }
            }

            PrintChart(chart);
        }

        private static void PrintItems(List<Item> items)
        {
            foreach (Item i in items)
            {
                Console.WriteLine("Weight: " + i.Weight + ", Value: " + i.Value);
            }
            Console.WriteLine();
        }

        private static void PrintChart(int[,] chart)
        {
            int width = chart.GetLength(0);
            int height = chart.GetLength(1);
            Console.Write(" # |");
            for(int i = 0; i < width; i++)
            {
                Console.Write(" "+i+" |");
            }
            Console.WriteLine();

            for(int i = 0; i < height; i++)
            {
                for (int i2 = 0; i2 <= width; i2++)
                {
                    Console.Write("----");
                }
                Console.WriteLine("----");
                Console.Write(" " + i + " |");
                for (int i2 = 0; i2 < width; i2++)
                {
                    Console.Write(" "+chart[i2, i] + " |");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
