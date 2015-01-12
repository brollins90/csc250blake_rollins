using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingLists
{
	public class FindMax
	{
		private readonly Action _runTheirProgram;

		public FindMax(Action runProgram)
		{
			_runTheirProgram = runProgram;
		}


		private static string GetRandoms(int range, int size, out int max)
		{
			max = -1;
			StringBuilder line = new StringBuilder();
			string dlim = "";
			for (int i = 0; i < size; i++)
			{
				int num = Rand.Next(range);
				max = Math.Max(max, num);
				line.Append(dlim + num);
				dlim = ",";
			}
			return line.ToString();
		}

		private void Assert(int should, int actual)
		{
			if (should != actual)
			{
				Console.WriteLine(should+" != "+actual);
				throw new Exception();
			}
		}

		public void Test()
		{
			Console.WriteLine("Testing finding max program");
			try
			{
				const int numRange = 7247;
				const int size = numRange/27;
				const int timesToTest = 100;

				for (int iteration = 0; iteration < timesToTest; iteration++)
				{
					CommandLineTools.PrintProgressBar(Console.CursorTop, iteration, timesToTest, 50);
					int max;

					StreamWriter sw = new StreamWriter("input.txt", false);
					sw.WriteLine(GetRandoms(numRange, size, out max));
					sw.Close();

					_runTheirProgram();

					StreamReader sr = new StreamReader("output.txt");
					int theirAnswer = int.Parse(sr.ReadLine());
					sr.Close();
					Assert(max,theirAnswer);
				}
				Console.WriteLine("\nPass");
			}
			catch
			{
				Console.WriteLine("\nFail");
			}
		}
	}
}
