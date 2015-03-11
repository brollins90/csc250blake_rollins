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
        Console.WriteLine(new Solution().Go(i).ToString().ToLower());


        //Console.WriteLine(new Solution().Go(14));
        //Console.WriteLine(new Solution().Go(19));
        //Console.WriteLine(new Solution().Go(13));
        //Console.WriteLine(new Solution().Go(920));
        //Console.WriteLine(new Solution().Go(921));
    }

    public bool Go(int input)
    {

        HashSet<int> set = new HashSet<int>();

        while (true)
        {
            
            string temp = input.ToString();
            input = 0;
            char[] numbers = temp.ToCharArray();

            foreach (char c in numbers)
            {
                int i = int.Parse(c.ToString());

                input += i*i;

            }
            if (input == 1)
            {
                return true;
            } 
            else if (set.Contains(input))
            {
                return false;

            }
            else
            {
                set.Add(input);
            }

        }

    }
}