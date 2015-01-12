using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MakingLists
{
	public class Program
	{
		public static void MyProgram()
		{
			//develop a program that will read in "input.txt" into your custom List and output the largest integer into a file called "output.txt".
			//The "input.txt" file will contain comma delimited, positive integers "1,6,43,23,76,123,654,123,..." they will all be on the first line of the file
			//the "output.txt" file should contain nothing but the largest integer
			//Restrictions:
			//You may not use any existing C# data structures except for primitives and arrays
			//you may not use any LINQ expressions to find the max number
			//You CAN use StreamReader and StreamWriter to reading and writing text files

            IAlgoList<int> mine = GetList();
            mine.Clear();

            StreamReader sr = new StreamReader("input.txt");
            string theLine = sr.ReadLine();
            sr.Close();

            if (!string.IsNullOrWhiteSpace(theLine))
            {
                string[] ints = theLine.Split(',');
                foreach (string i in ints)
                {
                    mine.Add(int.Parse(i));
                }
            }

            int max = 0;

            foreach (int i in mine)
            {
                if (i.CompareTo(max) > 0)
                {
                    max = i;
                }
            }

            StreamWriter sw = new StreamWriter("output.txt", false);
            sw.WriteLine(max);
            sw.Close();
		}

		static IAlgoList<int> GetList()
		{
			return new GenericArrayList<int>();
		}

		public static void Main(string[] args)
		{
			TestList listTester = new TestList(GetList);
            listTester.RunAll();

			FindMax maxTester = new FindMax(MyProgram);
			maxTester.Test();
		}
	}
}
