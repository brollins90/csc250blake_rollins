using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public static void Main(string[] args)
    {
        Solution s = new Solution();
        s.fibgen();


        string input = Console.ReadLine(); // read from standard input
        int i = int.Parse(input);

        Console.WriteLine(new Solution().Go(i)); // write to standard output


        //Console.WriteLine(s.Go(5)); // write to standard output
        //Console.WriteLine(s.Go(1)); // write to standard output
        //Console.WriteLine(s.Go(10)); // write to standard output
    }

    static List<long> fib = new List<long>();
    //static HashSet<long> prime = new HashSet<long>();

    string Go(int input)
    {
        return fib[input].ToString();
    }

    bool IsPrime(long l)
    {
        double rootl = Math.Sqrt(l);
        bool p = true;
        for (long j = 2; j < rootl &&  j < ((long)int.MaxValue * 4) && p; j++)
        {
            if (l % j == 0)
            {
                p = false;
            }
        }
        return p;
    }

    private void fibgen()
    {

        fib.Add(2);

        long pp = 1;
        long p = 1;
        for (int i = 3; i < 100; i++)
        {
            long one = pp;
            long two = p;
            long f = one + two;

            if (IsPrime(f))
            {
                fib.Add(f);
            }
            pp = p;
            p = f;
        }
    }

}
