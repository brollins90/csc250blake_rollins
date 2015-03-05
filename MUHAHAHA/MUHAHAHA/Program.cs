using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUHAHAHA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1");
            Permutations("aaa", "");

            Console.WriteLine("Part 2");
            Combinations("super", "");
            
            
            foreach (var v in set)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine(set.Count);

            //Console.WriteLine("Part 3");
            //PhoneToWord(new int[] { 2, 2, 5, 8, 2, 2, 7 }, "");
        }

        static HashSet<String> set = new HashSet<string>();

        static void Combinations(string s, string pre)
        {
            char[] sort = pre.ToCharArray();
            Array.Sort(sort);
            string alphabetized = new string(sort);

            set.Add(alphabetized);
            {
                for (int i = 0; i < s.Length; i++)
                {
                    string cur = s.Substring(i, 1);
                    string before = s.Substring(0, i);
                    string after = s.Substring(i + 1);
                    Combinations(before + after, pre + cur);
                }
            }
        }

        static void Permutations(string s, string pre)
        {
            if (s.Length == 0)
            {
                Console.WriteLine(pre);
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    string cur = s.Substring(i, 1);
                    string before = s.Substring(0, i);
                    string after = s.Substring(i + 1);
                    Permutations(before + after, pre + cur);
                }
            }
        }

        static Dictionary<int, char[]> phoneDict = new Dictionary<int, char[]>() 
        {
            {2, new[] {'a','b','c'}},
            {3, new[] {'d','e','f'}},
            {4, new[] {'g','h','i'}},
            {5, new[] {'j','k','l'}},
            {6, new[] {'m','n','o'}},
            {7, new[] {'p','r','s'}},
            {8, new[] {'t','u','v'}},
            {9, new[] {'w','x','y'}},
        };

        static void PhoneToWord(int[] digits, string pre )
        {
            if (digits.Length == 0)
            {
                Console.WriteLine(pre);
            }
            else
            {
                foreach(var kvp in phoneDict[digits[0]])
                {
                    char next = kvp;
                    PhoneToWord(digits.Skip(1).ToArray(), pre + next);
                }
            }
        }
    }
}
