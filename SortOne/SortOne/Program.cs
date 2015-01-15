using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortOne
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> bigList = new List<int>();
            for (int i = 2000; i > 0; i--)
            {
                bigList.Add(i);
            }

            List<int> daList = new List<int>() { 7, 3, 9, 4, 2, 5, 6, 1, 8 };

            PrintList(daList);
            BubbleSort(daList);
            PrintList(daList);
            Console.WriteLine();

            daList = new List<int>() { 7, 3, 9, 4, 2, 5, 6, 1, 8 };

            PrintList(daList);
            SelectionSort(daList);
            PrintList(daList);
            Console.WriteLine();

            daList = new List<int>() { 7, 3, 9, 4, 2, 5, 6, 1, 8 };

            PrintList(daList);
            InsertionSort(daList);
            PrintList(daList);
            Console.WriteLine();


            //Console.WriteLine("Running a Bubble sort on the big list.");
            //Stopwatch stopwatch = Stopwatch.StartNew();
            //BubbleSort(bigList);
            //stopwatch.Stop();
            //Console.WriteLine("Done with the bubble sort- " + stopwatch.ElapsedMilliseconds);

            //Console.ReadKey();
        }

        private static void PrintList(List<int> list)
        {
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.Write("\n");
        }

        private static void BubbleSort(List<int> list)
        {
            bool sorted = false;

            while (!sorted)
            {

                bool madeASwitch = false;
                for (int i = 0; i < list.Count - 1 && !madeASwitch; i++)
                {
                    //PrintList(list);
                    int current = list[i];
                    int next = list[i + 1];

                    if (current > next)
                    {
                        list[i] = next;
                        list[i + 1] = current;
                        madeASwitch = true;
                    }
                }
                if (!madeASwitch)
                {
                    sorted = true;
                }
                //PrintList(list);
            }
        }

        private static void SelectionSort(List<int> list)
        {
            int startIndex = 0;

            while (startIndex < list.Count)
            {
                int indexOfMin = startIndex;
                int min = list[startIndex];

                for (int i = startIndex; i < list.Count; i++)
                {
                    int toCheck = list[i];
                    if (toCheck < min)
                    {
                        min = toCheck;
                        indexOfMin = i;
                    }
                }

                list[indexOfMin] = list[startIndex];
                list[startIndex] = min;
                startIndex++;
                //PrintList(list);
            }
        }

        private static void InsertionSort(List<int> list)
        {
            int unsortedIndex = 1;

            while (unsortedIndex < list.Count)
            {
                bool rightPlaceForI = false;
                for (int i = unsortedIndex; i > 0 && !rightPlaceForI; i--)
                {
                    int iValue = list[i];
                    int j = i - 1;
                    int jValue = list[j];

                    if (iValue < jValue)
                    {
                        list[i] = jValue;
                        list[j] = iValue;
                    }
                    else
                    {
                        rightPlaceForI = true;
                    }
                }
                unsortedIndex++;
                //PrintList(list);
            }
        }
    }
}
