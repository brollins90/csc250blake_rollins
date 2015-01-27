using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTwo
{
    /// Blake Rollins
    /// Three more sorting algorithms
    /// Merge sort
    /// Quick sort 
    /// Shell sort
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            //List<int> bigList = new List<int>();
            //for (int i = 2000; i > 0; i--)
            //{
            //    bigList.Add(i);
            //}
            List<int> daList = null;
            Stopwatch stopwatch = null;
            //List<int> daList = new List<int>() { 7, 3, 9, 4, 2, 5, 6, 1, 8 };

            Console.WriteLine("MergeSort 100,000.");
            daList = new List<int>();
            for (int i = 100000; i > 0; i--)
            {
                daList.Add(rand.Next(1000));
            }
            stopwatch = Stopwatch.StartNew();
            //PrintList(daList);
            daList = MergeSort(daList);
            stopwatch.Stop();
            Console.WriteLine("Done with the MergeSort- " + stopwatch.ElapsedMilliseconds);
            //PrintList(daList);
            Console.WriteLine();

            //daList = new List<int>() { 7, 3, 9, 4, 2, 5, 6, 1, 8 };
            //daList = new List<int>() { 1, 12, 5, 26, 7, 14, 3, 7, 2 };

            Console.WriteLine("QuickSort 100,000.");
            daList = new List<int>();
            for (int i = 100000; i > 0; i--)
            {
                daList.Add(rand.Next(1000));
            }
            stopwatch = Stopwatch.StartNew();
            //PrintList(daList);
            daList = QuickSort(daList);
            stopwatch.Stop();
            Console.WriteLine("Done with the QuickSort- " + stopwatch.ElapsedMilliseconds);
            //PrintList(daList);
            Console.WriteLine();

            //daList = new List<int>() { 7, 3, 9, 4, 2, 5, 6, 1, 8 };

            Console.WriteLine("ShellSort 100,000.");
            daList = new List<int>();
            for (int i = 100000; i > 0; i--)
            {
                daList.Add(rand.Next(1000));
            }
            stopwatch = Stopwatch.StartNew();
            //PrintList(daList);
            daList = ShellSort(daList);
            stopwatch.Stop();
            Console.WriteLine("Done with the ShellSort- " + stopwatch.ElapsedMilliseconds);
            //PrintList(daList);
            Console.WriteLine();
        }

        private static void PrintList(List<int> list)
        {
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.Write("\n");
        }


        /// My thoughts:
        /// The merge sort tries to minimize the number of times it check any value by sorting small parts of the list and then merging the sorts together. 
        /// It stars with a part of size 1 then recursivly doubles the size of the list until the sort has completed.
        /// the size of the smaller list doubles each time, but only up to the value of n, the reverse of the doubling time is logrithmic so it would
        /// take close to O(log(n)).  The time to re merge the smaller lists is a number of fractions of n that add up to an n so the speed is closer to O(n * log(n)).
        /// 
        /// The internet says that the merge sort is one of the few sorting patterns that is almost always O(n * log(n)).  This is because of the recursive nature to the
        /// pattern.  each element is only swapped with the next part of the array and the values are not swapped if they are equal.  The downside of the merge sort is
        /// that it takes extra space to perform optimally.  All the values are usually stored in a temp array during a merge.
        /// 
        /// I think that I was close in my analysis.  I didnt realize that this sort is almost always the same speed no matter what the data is.  Sorted data has
        /// no advantage to reverse or random data.  I did notice that this sort does not happen in place, so it cannot be used if you do not have O(n) of free space.
        private static List<int> MergeSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                //PrintList(list);
                return list;
            }

            int middleIndex = list.Count / 2;

            List<int> left = new List<int>();
            for (int i = 0; i < middleIndex; i++)
            {
                left.Add(list[i]);
            }
            left = MergeSort(left);

            List<int> right = new List<int>();
            for (int i = middleIndex; i < list.Count; i++)
            {
                right.Add(list[i]);
            }
            right = MergeSort(right);

            return Merge(left, right);
        }


        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> newOne = new List<int>();

            bool sorted = false;
            int lIndex = 0;
            int rIndex = 0;

            while (lIndex < left.Count && rIndex < right.Count)
            {
                if (left[lIndex] <= right[rIndex])
                {
                    newOne.Add(left[lIndex]);
                    lIndex++;
                }
                else // right is larger
                {
                    newOne.Add(right[rIndex]);
                    rIndex++;
                }
            }

            while (lIndex < left.Count)
            {
                newOne.Add(left[lIndex]);
                lIndex++;
            }

            while (rIndex < right.Count)
            {
                newOne.Add(right[rIndex]);
                rIndex++;
            }
            //PrintList(newOne);
            return newOne;
        }

        /// My thoughts
        /// The quick sort takes a random value that is used to sub divide the list.  the sort swaps the left and right values it meets 
        /// until the list is sorted by "left to middle is less than the random value and the values to the right are all larger than the middle".
        /// The process is recursive until the sub list size is 1.  then the right values are added to the left values to create a sorted list.
        /// The sort cuts the set in half each time it is called, so the results are similar to the merge sort.  the process compares every element on the first
        /// round then recursively compares each value to only half of the remainder.  That makes the speed O(n * log(n)).  In a list that
        /// is backwards, every value will have to switch only one time, with it's opposite in the list, causing only one iteration. (even though it would then
        /// have to check every value still, there would be no more swapping.)
        /// 
        /// The internet says the quick sort is one of the most efficient sorts because of the way it splits the data.  if the data is random or nearly sorted,
        /// the sort is O(n * log(n)) because it check each value one time, and then only half the time recursivly.  the sort is very bad though if data is
        /// almost identical.  since the sort will swap two equal values if the data is almost unique, almost every value gets swapped each time leading to a 
        /// worst case of O(n^2)
        /// 
        /// The internet says that this is one of the best sorting algorithms because of the way it partitions the data, yet still does not use additional
        /// storage space.  I was correct with the average time,  but i didnt think that the sort is O(n^2) in the worst case.  It seems like there could be a
        /// better way to compare data that is equal.  it feels ineficient to swap data that is identical and that is why this algorithm can be slow.

        private static List<int> QuickSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int lIndex = 0;
            int rIndex = list.Count - 1;
            int partitionIndex = rIndex / 2;
            int partitionValue = list[partitionIndex];

            while (lIndex <= rIndex)
            {
                while (list[lIndex] < partitionValue)
                {
                    lIndex++;
                }
                while (list[rIndex] > partitionValue)
                {
                    rIndex--;
                }
                // swap
                if (lIndex <= rIndex)
                {
                    int t = list[lIndex];
                    list[lIndex] = list[rIndex];
                    list[rIndex] = t;
                    lIndex++;
                    rIndex--;
                }
                //PrintList(list);
            }

            List<int> left = new List<int>();
            for (int i = 0; i < lIndex; i++)
            {
                left.Add(list[i]);
            }
            left = QuickSort(left);

            List<int> right = new List<int>();
            for (int i = lIndex; i < list.Count; i++)
            {
                right.Add(list[i]);
            }
            right = QuickSort(right);

            foreach (int i in right)
            {
                left.Add(i);
            }
            return left;
        }

        ///  My thoughts
        ///  In the shell sort, the idea is to do an insertion sort with a different offset each time.
        ///  In most cases this raises the speed of the sort because not every value really needs to change every time.
        ///  The sort is still O(n^2) in the worst case, but usually the number of swaps is smaller because the 
        ///  numbers that are in a very wrong order are moved much more in the initial stages.
        ///  
        /// The internet says that the shell sort is rarely used now because it has such a high cache-miss rate.  Since 
        /// the whole list from left to right is searched, it is rare that the correct pieces of information stay in ram.
        /// The speed of the sort varies from O(n^(3/2)) to O(n^(4/3)) depending on the gap size it chooses. (This is math that is 
        /// beyond my guessing).  The sort is simple to implement and is good because it can easily be performed in place.
        /// 
        /// I dont know math well enough to agree that the speed is O(n^ to any number other than 2)  I agree with them because it 
        /// feels like the average is faster than o(n^2) because it probably will be, but since the gap that the algorithm uses
        /// is random to the data, I dont know where that number come from.  In general the speed is what I thought.  It is usually 
        /// faster than a normal insertion sort.
        private static List<int> ShellSort(List<int> list)
        {
            int gap = list.Count;

            while (gap >= 1)
            {
                //Console.WriteLine("gap: " + gap);
                int unsortedIndex = 1;

                while (unsortedIndex < list.Count)
                {
                    bool rightPlaceForI = false;
                    for (int i = unsortedIndex; i > 0 && !rightPlaceForI; i-=gap)
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
                    unsortedIndex+= gap;
                    //PrintList(list);
                }
                gap /= 2;
            }
            return list;
        }
    }
}
