using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTester
{
	class Rand
	{
		private static Random r = new Random();
		public static int Next() { return r.Next(); }
		public static int Next(int maxValue) { return r.Next(maxValue); }
		public static int Next(int minValue, int maxValue) { return r.Next(minValue,maxValue); }
		public static void NextBytes(byte[] buffer) { r.NextBytes(buffer); }
		public static double NextDouble() { return r.NextDouble(); }
	}
}
 