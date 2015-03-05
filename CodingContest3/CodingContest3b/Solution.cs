using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine(); // read from standard input
        
        //Console.WriteLine(new Solution().Go((input))); // write to standard output


        //Console.WriteLine(new Solution().Go("abcdghijklmnopquvwxyz school trees street paper set"));
        //Console.WriteLine(new Solution().Go("bdefghijklmnopqrsuvwxyz cat act tack at"));
        //Console.WriteLine(new Solution().Go("abcdfghijklmnopquvwxyz school trees street paper set"));
        Console.WriteLine(new Solution().Go("abcdefghijklmnopqrstuvwxyz school trees street paper set"));
        Console.WriteLine(new Solution().Go("abcdefghijklmnopqrstuvwxyz "));
        
    }

    public string Go(string s)
    {
        string ret = "";
        string[] parts = s.Split(' ');
        string[] foundWords = new string[parts.Length - 1];

        for (int i = 1; i < parts.Length; i++)
        {
            foundWords[i - 1] = parts[i];
        }

        string letters = parts[0];


        foreach (string word in foundWords)
        {

            HashSet<char> alpha = new HashSet<char>();
            HashSet<char> stolen = new HashSet<char>();
            for (int i = (int)'a'; i < (int)'z' + 1; i++)
            {
                alpha.Add((char)i);
            }
            foreach (char c in letters)
            {
                alpha.Remove((c));
            }

            bool thisword = true;
            foreach (char c in word)
            {
                if (alpha.Contains(c) || stolen.Contains(c) )
                {
                    alpha.Remove((c));
                    stolen.Add((c));
                }
                
                else
                {
                    thisword = false;
                }
            }
            if (thisword && alpha.Count == 0)
                ret += word + " ";

        }
        return ret.Trim();
        ;


    }
}