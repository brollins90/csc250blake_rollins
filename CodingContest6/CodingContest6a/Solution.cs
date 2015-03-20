using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public static void Main(string[] args)
    {
    //    string input = Console.ReadLine(); // read from standard input
    //    string[] numbers = input.Split(',');
    //    int sum = 0;
    //    foreach (string t in numbers)
    //    {
    //        sum += int.Parse(t);
    //    }
    //    Console.WriteLine(sum / numbers.Length); // write to standard output

        Console.WriteLine(new Solution().Go("10 7 2 2 2 2 2 3")); // 2
        Console.WriteLine(new Solution().Go("60 59 29 14 6 3")); // -1
        Console.WriteLine(new Solution().Go("10 1 2 3 4 5 6 7 8 9 10")); // 1
        Console.WriteLine(new Solution().Go("10 7 2 2 2 2 2 4")); // 4
    }

    int Go(string s)
    {
        //string input = Console.ReadLine(); // read from standard input
        string[] numbers = s.Split(' ');

        int[] nums = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            nums[i] = int.Parse(numbers[i]);
        }


        return Go2(nums[0], new List<int>(nums.Skip(1)));
    }

    int Go2(int goal, List<int> nums)
    {
        int tempGoal = goal;
        int leastNumber = -1;

        bool done = false;
        List<int> tempnums = new List<int>(nums);
        while (tempnums.Count > 0)
        {
            foreach (int t in tempnums)
            {
                List<int> templist = new List<int>(tempnums);
                templist.Remove(t);

                int sum = templist.Sum();
                if (sum == tempGoal && leastNumber > templist.Count)
                {
                    leastNumber = templist.Count;
                }
            }
            tempnums.RemoveAt(0);
        }

        return leastNumber;


    }
}