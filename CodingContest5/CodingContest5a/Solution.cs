using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine(); // read from standard input
        int i = int.Parse(input);

        Console.WriteLine(new Solution().Go(i)); // write to standard output



        //Console.WriteLine(new Solution().Go(220)); // write to standard output
        //Console.WriteLine(new Solution().Go(50)); // write to standard output
        //Console.WriteLine(new Solution().Go(48)); // write to standard output
    }

    string Go(int input)
    {

        HashSet<int> set = new HashSet<int>();

        for (int i = 2; i < input + 1; i++)
        {
            int one = input / i;
            int two = one * i;

            if (input == two)
            {
                set.Add(one);
            }

        }

        int sum = set.Sum();

        HashSet<int> set2 = new HashSet<int>();

        for (int i = 2; i < sum + 1; i++)
        {
            int one = sum / i;
            int two = one * i;

            if (sum == two)
            {
                set2.Add(one);
            }

        }

        int sum2 = set2.Sum();

        if (input == sum2)
        {
            return sum.ToString();
        }

        HashSet<int> set3 = new HashSet<int>();

        for (int i = 2; i < input + 1; i++)
        {
            int one = input / i;
            int two = one * i;

            if (input == two)
            {
                set3.Add(one);
            }

        }

        int sum3 = set3.Sum() -1;

        HashSet<int> set4 = new HashSet<int>();

        for (int i = 2; i < sum3 + 1; i++)
        {
            int one = sum3 / i;
            int two = one * i;

            if (sum3 == two)
            {
                set4.Add(one);
            }

        }

        int sum4 = set4.Sum();

        if (input + 1 == sum4)
        {
            return sum3.ToString();
        }






        return "none";
    }
}
