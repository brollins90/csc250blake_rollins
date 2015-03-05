using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    public static void Main(string[] args)
    {
        //string input = Console.ReadLine(); // read from standard input
        //string[] numbers = input.Split(' ');
        //int start = int.Parse(numbers[0]);
        //int end = int.Parse(numbers[1]);
        //double step = double.Parse(numbers[2]);

        //int answer = new Solution().NumSteps(start, end, step);
        //Console.WriteLine(answer); // write to standard output

        Console.WriteLine(new Solution().NumSteps(14, 12, .01d));
        Console.WriteLine(new Solution().NumSteps(4, 36, 8));
        Console.WriteLine(new Solution().NumSteps(12, 14, .1d));
        Console.WriteLine(new Solution().NumSteps(7, 8, .1d));
        Console.WriteLine(new Solution().NumSteps(8, 8, 92d));
        Console.WriteLine(new Solution().NumSteps(6, 1, -1d));
    }



    int NumSteps(int start, int end, double step)
    {
        int ret = 0;

        double val = start;


        if (start <= end)
        {
            if (step <= 0)
                return -1;

            while (val <= end)
            {
                val += step;
                ret++;
            }
        }
        else
        {
            if (step >= 0)
                return -1;

            while (val >= end)
            {
                val += step;
                ret++;
            }
        }
        return ret;
    }
}
