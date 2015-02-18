using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public static void Main(string[] args)
    {
        //string input = Console.ReadLine(); // read from standard input
        //string[] numbers = input.Split(',');
        //int sum = 0;
        //foreach (string t in numbers)
        //{
        //    sum += int.Parse(t);
        //}
        //Console.WriteLine(new Solution().FlagCount(int.Parse(input))); // write to standard output

        Solution s = new Solution();
        s.FlagCountTest(459384753, 28603);
        s.FlagCountTest(50, 6);
        s.FlagCountTest(46, 7);
        s.FlagCountTest(115, 12);
        s.FlagCountTest(3, 2);
    }


    void FlagCountTest(int i, int expected)
    {
        int actual = FlagCount(i);
        if (expected == actual)
        {
            Console.WriteLine("{0} pass", i);
        }
        else
        {
            Console.WriteLine("i: {0} fail a: {1} e: {2}", i, actual, expected);
        }
    }

    int FlagCount(int i)
    {
        float smallestDif = float.MaxValue;
        int retval = 0;

        for (int n = 1; n < i; n++)
        {

            int m = 2 * n - 1;
            int div = i / m;
            int mod = i % m;
            int dif = diff(mod, n);
            if (dif == 0)
            {
                int numRows = div * 2;
                numRows = mod == 0 ? numRows : numRows + 1;
                int numCols = n;
                float howSquare = diff((float)numRows,(float)numCols);

                if (diff(howSquare, 1f) <= smallestDif)
                {
                    smallestDif = howSquare;
                    retval = numCols;
                }
            }
            else
            {
                if (dif == n)
                {
                    int numRows = div * 2;
                    numRows = mod == 0 ? numRows : numRows + 1;
                    int numCols = n;
                    float howSquare = diff((float)numRows, (float)numCols);

                    if (diff(howSquare, 1f) <= smallestDif)
                    {
                        smallestDif = howSquare;
                        retval = numCols;
                    }
                }
            }
        }
        return retval;
    }

    int diff(int one, int two)
    {
        if (one > two)
        {
            return one - two;
        }
        else
        {
            return two - one;
        }
    }

    float diff(float one, float two)
    {
        if (one > two)
        {
            return one - two;
        }
        else
        {
            return two - one;
        }
    }

}

