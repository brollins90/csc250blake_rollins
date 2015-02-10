using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreAlgo
{
    class Program
    {

        #region main
        static void Main(string[] args)
        {
            Console.WriteLine("\nFind min number of squares...");
            FindMinNumberOfSquaresTest(1, 1);
            FindMinNumberOfSquaresTest(2, 2);
            FindMinNumberOfSquaresTest(3, 3);
            FindMinNumberOfSquaresTest(4, 1);
            FindMinNumberOfSquaresTest(5, 2);
            FindMinNumberOfSquaresTest(6, 3);
            FindMinNumberOfSquaresTest(8, 2);
            FindMinNumberOfSquaresTest(15, 4);
            FindMinNumberOfSquaresTest(16, 1);

            Console.WriteLine("\nFind smallest substring...");
            FindSmallestSubStringTest("abbcbcba", new HashSet<char>() { 'a', 'b', 'c' }, "cba");
            FindSmallestSubStringTest("abbcbcbabd", new HashSet<char>() { 'a', 'b', 'c', 'd' }, "cbabd");
            FindSmallestSubStringTest("abbcbcbabdac", new HashSet<char>() { 'a', 'b', 'c', 'd' }, "bdac");

            Console.WriteLine("\nSum and divisible...");
            SumAndDivisibleTest(9, 14);
            SumAndDivisibleTest(10, 23);
            SumAndDivisibleTest(53, 644);

            Console.WriteLine("\nSum preceding...");
            SumTest(1, 1);
            SumTest(2, 3);
            SumTest(3, 6);
            SumTest(10, 55);

            Console.WriteLine("\nSimplify fraction...");
            SimplifyFractionTest(1, 2, 1, 2);
            SimplifyFractionTest(2, 4, 1, 2);
            SimplifyFractionTest(1000, 1000, 1, 1);

            Console.WriteLine("\nAngry children...");
            AngryChildrenTest(3, new List<int>() { 10, 100, 300, 200, 1000, 20, 30 }, 20);
            AngryChildrenTest(4, new List<int>() { 1, 2, 3, 4, 10, 20, 30, 40, 100, 200 }, 3);
            AngryChildrenTest(3, new List<int>() { 10, 20, 30, 100, 101, 102 }, 2);

            Console.WriteLine("\nLonely integer...");
            LonelyIntegerTest(new List<int>() { 1 }, 1);
            LonelyIntegerTest(new List<int>() { 1, 1, 2 }, 2);
            LonelyIntegerTest(new List<int>() { 0, 0, 1, 2, 1 }, 2);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        #endregion


        #region Find min number of squares
        /*
         * http://www.careercup.com/question?id=5176833186201600
         * You are given a positive integer number N. Return the minimum number K, such that N can be represented as K integer squares.
        Examples:
        9 --> 1 (9 = 3^2)
        8 --> 2 (8 = 4^2 + 4^2)
        15 --> 4 (15 = 3^2 + 2^2 + 1^2 + 1^2)
        First reach a solution without any assumptions, then you can improve it using this mathematical lemma: 
         * For any positive integer N, there is at least one representation of N as 4 or less squares.*/

        public static void FindMinNumberOfSquaresTest(int i, int expected)
        {

            Console.Write("FindMinNumberOfSquares {0}", i);
            int actual = FindMinNumberOfSquares(i);

            if (expected.Equals(actual))
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = t;
            }
            else
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = t;
            }
        }


        public static int FindMinNumberOfSquares(int i)
        {
            // base case
            if (i == 0)
            {
                return 0;
            }
            else if (i == 1)
            {
                return 1;
            }
            int root = (int)Math.Sqrt(i);
            return FindMinNumberOfSquares(i - (root * root)) + 1;
        }
        #endregion

        #region Find smallest substring
        /*
         * http://www.careercup.com/question?id=5092414932910080
         You are given a set of unique characters and a string.

        Find the smallest substring of the string containing all the characters in the set.

        ex:
        Set : [a, b, c]
        String : "abbcbcba"

        Result: "cba"
         */
        public static void FindSmallestSubStringTest(string s, HashSet<char> chars, string expected)
        {

            Console.Write("FindSmallestSubString {0} {1}", s, chars.CSVCollection());
            string actual = FindSmallestSubString(chars, s);

            if (expected.Equals(actual))
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = t;
            }
            else
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = t;
            }
        }

        public static string FindSmallestSubString(HashSet<char> chars, string s)
        {
            string retVal = null;
            
            for (int startChar = 0; startChar < s.Length; startChar++)
            {
                HashSet<char> charsTemp = new HashSet<char>(chars);
                int i = startChar;

                while (charsTemp.Count > 0 && i < s.Length)
                {
                    char cur = s[i++];
                    charsTemp.Remove(cur);
                }
                if (charsTemp.Count == 0)
                {
                    string sub = s.Substring(startChar, i - startChar);

                    if (retVal == null || retVal.Length > sub.Length)
                    {
                        retVal = sub;

                        // if the string is the size of the chars array then the chars are never repeated and we can return it right now.
                        if (retVal.Length.Equals(chars.Count))
                        {
                            return retVal;
                        }
                    }
                }
            }
            return retVal;
        }
        

        //public static string FindSmallestSubString2(HashSet<char> chars, string s)
        //{
        //    string retVal = null;
        //    for (int charInString = 0; charInString < s.Length; charInString++)
        //    {
        //        //Console.WriteLine();
        //        for (int endChar = charInString + chars.Count; endChar < s.Length + 1; endChar++)
        //        {
        //            string sub = s.Substring(charInString, endChar - charInString);
        //            HashSet<char> charsTemp = new HashSet<char>(chars);
        //            foreach (char c in sub)
        //            {
        //                charsTemp.Remove(c);
        //                if (charsTemp.Count == 0)
        //                {
        //                    if (retVal == null || retVal.Length > sub.Length)
        //                    {
        //                        retVal = sub;
        //                    }
        //                }
        //            }

        //            //Console.WriteLine(sub);
        //        }
        //    }
        //    return retVal;
        //}
        #endregion

        #region Sum of numbers smaller and divisible by 3 and 5
        /*
         * http://www.careercup.com/question?id=5631511174840320
         write an algorithm to find sum of numbers which are smaller than N and divisible by 3 or 5

        Example:
        N = 9 => 3 + 5 + 6 = 14
        N = 10 => 3 + 5 + 6 + 9 = 23
         */
        public static void SumAndDivisibleTest(int n, int expected)
        {

            Console.Write("SumAndDivisible {0}", n);
            int actual = SumAndDivisible(n);

            if (expected.Equals(actual))
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = t;
            }
            else
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = t;
            }
        }

        public static int SumAndDivisible(int n)
        {
            int retVal = 0;

            for (int i = 1; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    retVal += i;
                }
            }

            return retVal;
        }
        #endregion

        #region Sum of previous numbers
        public static void SumTest(int n, int expected)
        {

            Console.Write("Sum {0}", n);
            int actual = Sum(n);

            if (expected.Equals(actual))
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = t;
            }
            else
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = t;
            }
        }

        public static int Sum(int n)
        {            
            return (n * (n + 1)) / 2;
        }

        public static int Sum2(int n)
        {
            int retVal = 0;

            for (int i = 1; i < n + 1; i++)
            {
                retVal += i;
            }

            return retVal;
        }
        #endregion
        
        #region Simplify a fraction / find the GCD
        public static void SimplifyFractionTest(int top, int bottom, int expectedT, int expectedB)
        {

            Console.Write("SimplifyFraction {0} / {1}", top, bottom);
            int outTop;
            int outBottom;
            SimplifyFraction(top, bottom, out outTop, out outBottom);

            if (expectedT.Equals(outTop) && expectedB.Equals(outBottom))
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail (e:{0} / {1}  a:{2} / {3}", expectedT, expectedB, top, bottom);
                Console.ForegroundColor = color;
            }
        }

        public static void SimplifyFraction(int top, int bottom, out int outTop, out int outBottom)
        {
            bool negative = (top < 0 || bottom < 0);
            top = Math.Abs(top);
            bottom = Math.Abs(bottom);

            int gcd = GCD(top, bottom);
            outTop = top / gcd;
            outBottom = bottom / gcd;

            if (negative)
            {
                top = top * -1;
            }
        }

        private static int GCD(int top, int bottom)
        {
            int a = top;
            int b = bottom;

            while (b > 0)
            {
                int remainder = a % b;
                a = b;
                b = remainder;
            }
            return a;
        }
        #endregion

        #region Angry children
        // https://www.hackerrank.com/challenges/angry-children
        public static void AngryChildrenTest(int k, List<int> list, int expected)
        {

            Console.Write("AngryChildren");
            int actual = AngryChildren(k, list);

            if (expected.Equals(actual))
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }

        public static int AngryChildren(int k, List<int> list)
        {
            list.Sort();

            int lowest = int.MaxValue;
            for (int i = 0; i < list.Count + 1 - k; i++)
            {
                int r = list[i + k - 1] - list[i];
                lowest = Math.Min(lowest, r);
            }
            return lowest;
        }
        #endregion

        #region Lonely Integer
        // https://www.hackerrank.com/challenges/lonely-integer
        public static void LonelyIntegerTest(List<int> list, int expected)
        {

            Console.Write("LonelyInteger");
            int actual = LonelyInteger(list);

            if (expected.Equals(actual))
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail (e:{0} a:{1}", expected, actual);
                Console.ForegroundColor = color;
            }
        }

        public static int LonelyInteger(IEnumerable<int> list)
        {
            Dictionary<int, int> table = new Dictionary<int, int>();
            foreach (int i in list)
            {
                table[i] = (table.ContainsKey(i)) ? table[i] + 1 : 1;
            }
            foreach (var kv in table)
            {
                if (kv.Value == 1)
                {
                    return kv.Key;
                }
            }
            return -1;
        }
        #endregion

    }
}
