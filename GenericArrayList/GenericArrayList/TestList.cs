using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingLists
{
	internal delegate void TestFun();

	public class TestList
	{
		private const int Size = 1000;
		private readonly Func<IAlgoList<int>> getTheirs;

		public TestList(Func<IAlgoList<int>> getTheirs)
		{
			this.getTheirs = getTheirs;
		}

		private void Assert(int should, int actual)
		{
			if (should != actual)
			{
				Console.Write(should + " != " + actual + " ");
				throw new Exception();
			}
		}

		private void Assert(bool should)
		{
			if (!should)
			{
				throw new Exception();
			}
		}

		public void Clear()
		{
			IAlgoList<int> toTest = getTheirs();
			for (int i = 0; i < Size; i++)
			{
				toTest.Add(i);
			}
			toTest.Clear();
			Assert(0, toTest.Count);
		}

		public void RunAll()
		{
            List<Tuple<string, Action>> funcs = new List<Tuple<string, Action>>();
            funcs.Add(new Tuple<string, Action>("BinSearch", BinSearch));
            funcs.Add(new Tuple<string, Action>("BinSearch2", BinSearch2));
            funcs.Add(new Tuple<string, Action>("BinSearch3", BinSearch3));
            funcs.Add(new Tuple<string, Action>("BinSearch4", BinSearch4));
            funcs.Add(new Tuple<string, Action>("Insert", Insert));
			funcs.Add(new Tuple<string, Action>("Add", Add));
			funcs.Add(new Tuple<string, Action>("Add2", Add2));
			funcs.Add(new Tuple<string, Action>("Iterate", Iterate));
			funcs.Add(new Tuple<string, Action>("RemoveAt", RemoveAt));
			funcs.Add(new Tuple<string, Action>("RemoveAt2", RemoveAt2));
			funcs.Add(new Tuple<string, Action>("Remove", Remove));
			funcs.Add(new Tuple<string, Action>("Remove2", Remove2));
			funcs.Add(new Tuple<string, Action>("Clear", Clear));
			funcs.Add(new Tuple<string, Action>("Insert", Insert));
			foreach (var action in funcs)
			{
				try
				{
					Console.Write("Running " + action.Item1 + " ");
					action.Item2();
					var t = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.WriteLine("Pass");
					Console.ForegroundColor = t;
				}
				catch (Exception e)
				{
					var t = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Fail " + e.Message);
					Console.ForegroundColor = t;
				}
			}
		}

		private static readonly Random Rand = new Random();

		private static void ShuffleArray<T>(IAlgoList<T> array)
		{
			for (int i = 0; i < array.Count; i++)
			{
				int randomIndex = Rand.Next(array.Count);
				T tmp = array[i];
				array[i] = array[randomIndex];
				array[randomIndex] = tmp;
			}
		}

		private static void ShuffleArray<T>(IList<T> array)
		{
			for (int i = 0; i < array.Count; i++)
			{
				int randomIndex = Rand.Next(array.Count);
				T tmp = array[i];
				array[i] = array[randomIndex];
				array[randomIndex] = tmp;
			}
		}

		public void Add()
		{
			IAlgoList<int> toTest = getTheirs();
			for (int i = 0; i < Size; i++)
			{
				toTest.Add(i);
			}
			for (int i = 0; i < Size; i++)
			{
				Assert(i, toTest[i]);
			}
		}

		public void Add2()
		{
			List<int> verify = new List<int>();
			IAlgoList<int> toTest = getTheirs();
			for (int i = 0; i < Size; i++)
			{
				int num = Rand.Next();
				verify.Add(num);
				toTest.Add(num);
			}
			for (int i = 0; i < Size; i++)
			{
				Assert(verify[i], toTest[i]);
			}
		}

		public void Iterate()
		{
			List<int> verify = new List<int>();
			IAlgoList<int> toTest = getTheirs();
			for (int i = 0; i < Size; i++)
			{
				int num = Rand.Next();
				verify.Add(num);
				toTest.Add(num);
			}
			int index = 0;
			foreach (var i in toTest)
			{
				Assert(verify[index++], i);
			}
		}

		public void RemoveAt()
		{
			IAlgoList<int> toTest = getTheirs();
			for (int i = 0; i < Size; i++)
			{
				toTest.Add(i);
			}
			int counter = 0;
			while (toTest.Count > 0)
			{
				toTest.RemoveAt(Rand.Next(toTest.Count));
				counter++;
			}
			Assert(Size, counter);
		}

		public void RemoveAt2()
		{
			IAlgoList<int> toTest = getTheirs();
			for (int i = 0; i < Size; i++)
			{
				toTest.Add(i);
			}
			int counter = 0;
			while (toTest.Count > 0)
			{
				toTest.RemoveAt(0);
				counter++;
			}
			Assert(Size, counter);
		}

		public void Remove()
		{
			List<int> toRemoveOrder = new List<int>();
			IAlgoList<int> toTest = getTheirs();
			for (int i = 0; i < Size; i++)
			{
				toTest.Add(i);
				toRemoveOrder.Add(i);
			}
			ShuffleArray(toRemoveOrder);
			foreach (int t in toRemoveOrder)
			{
				Assert(toTest.Remove(t));
			}
			Assert(0, toTest.Count);
		}

		public void Remove2()
		{
			IAlgoList<int> toTest = getTheirs();
			for (int i = 0; i < Size; i++)
			{
				toTest.Add(i);
			}
			ShuffleArray(toTest);
			for (int i = 0; i < Size; i++)
			{
				Assert(toTest.Remove(i));
			}
			Assert(0, toTest.Count);
		}

		public void Insert()
		{
			IAlgoList<int> toTest = getTheirs();
			List<int> toCompare = new List<int>();
			for (int i = Size - 1; i >= 0; i--)
			{
				/* val, index
				toTest.Insert(i,0);
				/*/
				// index, val
				toTest.Insert(0, i);
				//*/
			}
			int testing = 0;
			for (int i = 0; i < toTest.Count; ++i)
			{
				Assert(i, toTest[i]);
			}
		}

        public void BinSearch()
        {
            IAlgoList<int> toTest = getTheirs();
            const int size = 100000;
            for (int i = 0; i < size; i++)
            {
                toTest.Add(i);
            }

            for (int i = 0; i < 100; i++)
            {
                int number = Rand.Next(100000);
                Assert(toTest[number], toTest[((GenericArrayList<int>)toTest).Find(number)]);
            }
        }

        public void BinSearch2()
        {
            IAlgoList<int> toTest = getTheirs();
            const int size = 100;
            for (int i = 0; i < size; i++)
            {
                toTest.Add(i);
            }

            Assert(0, ((GenericArrayList<int>)toTest).Find(0));
        }

        public void BinSearch3()
        {
            IAlgoList<int> toTest = getTheirs();
            const int size = 100;
            for (int i = 0; i < size; i++)
            {
                toTest.Add(i);
            }

            Assert(-1, ((GenericArrayList<int>)toTest).Find(100));
        }

        public void BinSearch4()
        {
            IAlgoList<int> toTest = getTheirs();
            const int size = 100;
            for (int i = 0; i < size; i++)
            {
                toTest.Add(i);
            }

            Assert(99, ((GenericArrayList<int>)toTest).Find(99));
        }
	}
}