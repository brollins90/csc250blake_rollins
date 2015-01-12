using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MakingLists;

namespace ListTester
{
	[TestClass]
	public class FindMax
	{
		private static void RunTheirProgram() {
			Program.MyProgram();
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
		[TestMethod]
		public void TestMethod1()
		{
			const int numRange = 7247;
			const int size = numRange/27;
			const int timesToTest = 100;

			for (int potato = 0; potato < timesToTest; potato++)
			{
				int max;

				StreamWriter sw = new StreamWriter("input.txt", false);
				sw.WriteLine(GetRandoms(numRange,size,out max));
				sw.Close();

				RunTheirProgram();

				StreamReader sr = new StreamReader("output.txt");
				int theirAnswer = int.Parse(sr.ReadLine());
				sr.Close();

				Assert.AreEqual(max, theirAnswer);
			}
		}
	}
}
