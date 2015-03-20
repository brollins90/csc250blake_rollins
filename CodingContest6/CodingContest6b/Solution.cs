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
        //Console.WriteLine(sum / numbers.Length); // write to standard output

        Console.WriteLine(new Solution().Go("ababa ab ba a abba"));
        Console.WriteLine(new Solution().Go("banana b ana"));
        Console.WriteLine(new Solution().Go("greenbatcorn art green bat corn"));
    }

    bool Go(string s)
    {
        string[] parts = s.Split(' ');

        return Go2(parts[0], parts.Skip(1));

    }

    static HashSet<string> set = new HashSet<string>();
    bool Go2(string s, IEnumerable<string> ss)
    
    {
        string tempWord = buildWord(ss);

        return set.Contains(s);
    }

    String buildWord(IEnumerable<string> s)
    {
        string ret = "";
        if (s.Count() == 1)
        {
            return s.First();
        }
        //else
        foreach (string w in s)
        {
            List<string> newList = new List<string>(s);
            newList.Remove(w);
            ret += buildWord(newList) + w;
            set.Add(ret);
        }
        return "";

    }
}