using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine(); // read from standard input
        string[] numbers = input.Split(',');
        int[] intsarray = new int[numbers.Length];
        for (int index = 0; index < numbers.Length; index++)
        {
            int ii = int.Parse(numbers[index]);
            intsarray[index] = ii;
        }
        Console.WriteLine(new Solution().Go(intsarray)); // write to standard output


        //Console.WriteLine(new Solution().Go(new int[] { 50, -40, 42, -10, 9 }));
        //Console.WriteLine(new Solution().Go(new int[] { 9, -10, 42, -40, 50 }));
        //Console.WriteLine(new Solution().Go(new int[] { 10, -11, 10 }));
        //Console.WriteLine(new Solution().Go(new int[] { -10, 2, 3, -2, 0, 5, -15 }));
        //Console.WriteLine(new Solution().Go(new int[] { -1, -2, -3 }));
        //Console.WriteLine(new Solution().Go(new int[] { int.MaxValue, -2, -3 }));
        //Console.WriteLine(new Solution().Go(new int[] { int.MinValue, int.MaxValue, -3 }));
        //Console.WriteLine(new Solution().Go(new int[] { 0 }));
        //Console.WriteLine(new Solution().Go(new int[] { 0, 0 }));
        //Console.WriteLine(new Solution().Go(new int[] { -100 }));



    }

    public int Go(int[] ints)
    {
        int max = int.MinValue;
        
        for (int k = ints.Length - 1; k > -1; k--)
        {
            for (int i = 0; i < k + 1; i++)
            {
                List<int> sub = new List<int>();
                for (int j = i; j < k + 1; j++)
                {
                    sub.Add(ints[j]);
                }
                if (sub.Count > 0)
                {
                    int sum = SumThem(sub.ToArray());
                    if (sum > max)
                    {
                        max = sum;
                    }
                }
            }
        }
        int tmax = ints.Max();
        if (tmax > max)
            max = tmax;
        return max;
    }

    public int SumThem(int[] ints)
    {
            int retval = 0;
            foreach (int i in ints)
            {
                retval += i;
            }
            return retval;
        
        ;
    }
}