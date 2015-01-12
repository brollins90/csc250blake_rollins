using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSC160_GenericLinkedList
{
    public class TestLinkedList
    {
        private const int Size = 1000;
        private static readonly Random Rand = new Random();

        private readonly Func<ILinkedList<int>> getTheirs;
        private readonly Func<ILinkedList<string>> getTheirsStr;

        public TestLinkedList(Func<ILinkedList<int>> getTheirs, Func<ILinkedList<string>> getTheirsStr)
        {
            this.getTheirs = getTheirs;
            this.getTheirsStr = getTheirsStr;
        }

        private void Assert(string should, string actual)
        {
            if (!should.Equals(actual))
            {
                Console.WriteLine(should + " != " + actual);
                throw new Exception();
            }
        }

        private void Assert(int should, int actual)
        {
            if (should != actual)
            {
                Console.WriteLine(should + " != " + actual);
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

        public void RunAll()
        {
            List<Tuple<string, Action>> funcs = new List<Tuple<string, Action>>();
            #region Blake Rollins
            funcs.Add(new Tuple<string, Action>("Rollins: AddAfter_int_Middle", Rollins_AddAfter_int_Middle));
            funcs.Add(new Tuple<string, Action>("Rollins: AddAfter_int_End", Rollins_AddAfter_int_End));
            funcs.Add(new Tuple<string, Action>("Rollins: AddBefore_int_Middle", Rollins_AddBefore_int_Middle));
            funcs.Add(new Tuple<string, Action>("Rollins: AddBefore_int_End", Rollins_AddBefore_int_Start));
            funcs.Add(new Tuple<string, Action>("Rollins: AddFirst_Empty", Rollins_AddFirst_Empty));
            funcs.Add(new Tuple<string, Action>("Rollins: AddLast_Empty", Rollins_AddLast_Empty));
            funcs.Add(new Tuple<string, Action>("Rollins: AddFirst_NonEmpty", Rollins_AddFirst_NonEmpty));
            funcs.Add(new Tuple<string, Action>("Rollins: AddLast_NonEmpty", Rollins_AddLast_NonEmpty));
            funcs.Add(new Tuple<string, Action>("Rollins: Clear_EmptyList", Rollins_Clear_EmptyList));
            funcs.Add(new Tuple<string, Action>("Rollins: Clear_NonEmpty", Rollins_Clear_NonEmpty));
            funcs.Add(new Tuple<string, Action>("Rollins: Contains_NonEmpty", Rollins_Contains_NonEmpty));
            funcs.Add(new Tuple<string, Action>("Rollins: Contains_Empty", Rollins_Contains_Empty));
            funcs.Add(new Tuple<string, Action>("Rollins: AddNodeFromDiffList", Rollins_AddNodeFromDiffList));
            funcs.Add(new Tuple<string, Action>("Rollins: AddNodeAfterClear", Rollins_AddNodeAfterClear));
            funcs.Add(new Tuple<string, Action>("Rollins: CopyToNotBigEnough", Rollins_CopyToNotBigEnough));
            funcs.Add(new Tuple<string, Action>("Rollins: CopyToNotBigEnough2", Rollins_CopyToNotBigEnough2));
            funcs.Add(new Tuple<string, Action>("Rollins: Enumerate", Rollins_Enumterate));
            funcs.Add(new Tuple<string, Action>("Rollins: Find_NonEmpty", Rollins_Find_NonEmpty));
            funcs.Add(new Tuple<string, Action>("Rollins: Find_Empty", Rollins_Find_Empty));
            funcs.Add(new Tuple<string, Action>("Rollins: Remove_NonEmpty", Rollins_Remove_NonEmpty));
            funcs.Add(new Tuple<string, Action>("Rollins: Remove_Empty", Rollins_Remove_Empty));
            funcs.Add(new Tuple<string, Action>("Rollins: RemoveFirst_NonEmpty", Rollins_RemoveFirst_NonEmpty));
            funcs.Add(new Tuple<string, Action>("Rollins: RemoveLast_NonEmpty", Rollins_RemoveLast_NonEmpty));
            funcs.Add(new Tuple<string, Action>("Rollins: AddAfter_NullValue_Middle", Rollins_AddAfter_NullValue_Middle));
            funcs.Add(new Tuple<string, Action>("Rollins: AddAfter_NullValue_End", Rollins_AddAfter_NullValue_End));
            funcs.Add(new Tuple<string, Action>("Rollins: AddAfter_String_Middle", Rollins_AddAfter_String_Middle));
            funcs.Add(new Tuple<string, Action>("Rollins: AddAfter_String_End", Rollins_AddAfter_String_End));
            funcs.Add(new Tuple<string, Action>("Rollins: AddBefore_NullValue_Middle", Rollins_AddBefore_NullValue_Middle));
            funcs.Add(new Tuple<string, Action>("Rollins: AddBefore_NullValue_Start", Rollins_AddBefore_NullValue_Start));
            funcs.Add(new Tuple<string, Action>("Rollins: AddBefore_String_Middle", Rollins_AddBefore_String_Middle));
            funcs.Add(new Tuple<string, Action>("Rollins: AddBefore_String_Start", Rollins_AddBefore_String_Start));
            funcs.Add(new Tuple<string, Action>("Rollins: AddFirst_NullValue_EmptyList", Rollins_AddFirst_NullValue_EmptyList));
            funcs.Add(new Tuple<string, Action>("Rollins: AddFirst_NullValue", Rollins_AddFirst_NullValue));
            funcs.Add(new Tuple<string, Action>("Rollins: AddFirst_String", Rollins_AddFirst_String));
            funcs.Add(new Tuple<string, Action>("Rollins: AddLast_NullValue_EmptyList", Rollins_AddLast_NullValue_EmptyList));
            funcs.Add(new Tuple<string, Action>("Rollins: AddLast_NullValue", Rollins_AddLast_NullValue));
            funcs.Add(new Tuple<string, Action>("Rollins: AddLast_String", Rollins_AddLast_String));
            #endregion

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
                    Console.WriteLine("Fail - {0}", e.Message);
                    Console.ForegroundColor = t;
                }
            }
        }

        #region Blake Rollins

        public void Rollins_AddAfter_int_Middle()
        {
            // arange
            ILinkedList<int> myList = getTheirs();
            LinkedListNode<int> node1 = myList.AddLast(1);
            LinkedListNode<int> node2 = myList.AddLast(2);
            int theValue = 3;

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<int> node3 = myList.AddAfter(node1, theValue);

            // assert
            Assert(3, myList.Count);
            Assert(node1.Equals(myList.First));

            Assert(node3.Equals(node1.Next));
            Assert(node1.Equals(node3.Previous));

            Assert(theValue.Equals(node3.Value));

            Assert(node2.Equals(node3.Next));
            Assert(node3.Equals(node2.Previous));

            Assert(node2.Equals(myList.Last));
        }

        public void Rollins_AddAfter_int_End()
        {
            // arange
            ILinkedList<int> myList = getTheirs();
            LinkedListNode<int> node1 = myList.AddLast(1);
            LinkedListNode<int> node2 = myList.AddLast(2);
            int theValue = 3;

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<int> node3 = myList.AddAfter(node2, theValue);

            // assert
            Assert(3, myList.Count);
            Assert(node1.Equals(myList.First));

            Assert(node2.Equals(node1.Next));
            Assert(node1.Equals(node2.Previous));

            Assert(node3.Equals(node2.Next));
            Assert(node1.Equals(node2.Previous));

            Assert(theValue.Equals(node3.Value));

            Assert(node3.Equals(myList.Last));
        }

        public void Rollins_AddBefore_int_Middle()
        {
            // arange
            ILinkedList<int> myList = getTheirs();
            LinkedListNode<int> node1 = myList.AddLast(1);
            LinkedListNode<int> node2 = myList.AddLast(2);
            int theValue = 3;

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<int> node3 = myList.AddBefore(node2, theValue);

            // assert
            Assert(3, myList.Count);
            Assert(node1.Equals(myList.First));

            Assert(node3.Equals(node1.Next));
            Assert(node1.Equals(node3.Previous));

            Assert(theValue.Equals(node3.Value));

            Assert(node2.Equals(node3.Next));
            Assert(node3.Equals(node2.Previous));

            Assert(node2.Equals(myList.Last));
        }

        public void Rollins_AddBefore_int_Start()
        {
            // arange
            ILinkedList<int> myList = getTheirs();
            LinkedListNode<int> node1 = myList.AddLast(1);
            LinkedListNode<int> node2 = myList.AddLast(2);
            int theValue = 3;

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<int> node3 = myList.AddBefore(node1, theValue);

            // assert
            Assert(3, myList.Count);
            Assert(node3.Equals(myList.First));

            Assert(node1.Equals(node3.Next));
            Assert(node3.Equals(node1.Previous));

            Assert(theValue.Equals(node3.Value));

            Assert(node2.Equals(node1.Next));
            Assert(node1.Equals(node2.Previous));

            Assert(node2.Equals(myList.Last));
        }

        public void Rollins_AddFirst_Empty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();
            int theValue = 1;

            Assert(0, myList.Count);
            Assert(myList.First == null);
            Assert(myList.Last == null);

            // act
            LinkedListNode<int> node1 = myList.AddFirst(theValue);

            // assert
            Assert(1, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(theValue.Equals(node1.Value));
            Assert(node1.Equals(myList.Last));
        }

        public void Rollins_AddLast_Empty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();
            int theValue = 1;

            Assert(0, myList.Count);
            Assert(myList.First == null);
            Assert(myList.Last == null);

            // act
            LinkedListNode<int> node1 = myList.AddLast(theValue);

            // assert
            Assert(1, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(theValue.Equals(node1.Value));
            Assert(node1.Equals(myList.Last));
        }

        public void Rollins_AddFirst_NonEmpty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();
            int theValue = 1;

            Assert(0, myList.Count);
            Assert(myList.First == null);
            Assert(myList.Last == null);

            // act
            LinkedListNode<int> node1 = myList.AddFirst(theValue);

            // assert
            Assert(1, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(theValue.Equals(node1.Value));
            Assert(node1.Equals(myList.Last));

            // act
            LinkedListNode<int> node2 = myList.AddFirst(theValue);

            // assert
            Assert(2, myList.Count);
            Assert(node2.Equals(myList.First));
            Assert(theValue.Equals(node2.Value));
            Assert(node1.Equals(myList.Last));
        }

        public void Rollins_AddLast_NonEmpty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();
            int theValue = 1;

            Assert(0, myList.Count);
            Assert(myList.First == null);
            Assert(myList.Last == null);

            // act
            LinkedListNode<int> node1 = myList.AddLast(theValue);

            // assert
            Assert(1, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(theValue.Equals(node1.Value));
            Assert(node1.Equals(myList.Last));

            // act
            LinkedListNode<int> node2 = myList.AddLast(theValue);

            // assert
            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(theValue.Equals(node2.Value));
            Assert(node2.Equals(myList.Last));
        }

        public void Rollins_Clear_EmptyList()
        {
            // arange
            ILinkedList<int> myList = getTheirs();
            int expectedCount = 0;

            // act
            myList.Clear();

            // assert
            Assert(expectedCount, myList.Count);
            Assert(myList.First == null);
            Assert(myList.Last == null);
        }

        public void Rollins_Clear_NonEmpty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();
            LinkedListNode<int> node1 = myList.AddLast(1);
            LinkedListNode<int> node2 = myList.AddLast(2);
            int expectedCount = 0;

            // act
            myList.Clear();

            // assert
            Assert(expectedCount, myList.Count);
            Assert(myList.First == null);
            Assert(myList.Last == null);
        }

        public void Rollins_Contains_NonEmpty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();

            // act
            for (int i = 0; i < 10; i++)
            {
                myList.AddLast(i);
            }

            // assert
            // first
            Assert(myList.Contains(0));
            // mid
            Assert(myList.Contains(4));
            // last
            Assert(myList.Contains(9));
        }

        public void Rollins_Contains_Empty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();

            // assert
            // first
            Assert(!myList.Contains(0));
            Assert(!myList.Contains(4));
            Assert(!myList.Contains(9));
        }

        public void Rollins_AddNodeFromDiffList()
        {
            // arange
            ILinkedList<int> myList1 = getTheirs();
            ILinkedList<int> myList2 = getTheirs();
            LinkedListNode<int> node1 = myList1.AddLast(1);
            LinkedListNode<int> node2 = myList1.AddLast(2);
            LinkedListNode<int> node3 = myList2.AddLast(3);
            LinkedListNode<int> node4 = myList2.AddLast(4);

            // act
            try
            {
                myList2.AddAfter(node1, node2);
                Assert(false);
            }
            catch (Exception)
            {
                Assert(true);
            }
        }

        public void Rollins_AddNodeAfterClear()
        {
            // arange
            ILinkedList<int> myList1 = getTheirs();
            LinkedListNode<int> node1 = myList1.AddLast(1);
            LinkedListNode<int> node2 = myList1.AddLast(2);
            myList1.Clear();

            // act
            try
            {
                LinkedListNode<int> node3 = myList1.AddAfter(node1, 3);
                Assert(false);
            }
            catch (Exception)
            {
                Assert(true);
            }
        }

        public void Rollins_CopyToNotBigEnough()
        {
            // arange
            ILinkedList<int> myList1 = getTheirs();
            LinkedListNode<int> node1 = myList1.AddLast(1);
            LinkedListNode<int> node2 = myList1.AddLast(2);
            myList1.Clear();

            // act
            try
            {
                int[] ar = new int[1];
                myList1.CopyTo(ar, 0);
                Assert(false);
            }
            catch (Exception)
            {
                Assert(true);
            }
        }

        public void Rollins_CopyToNotBigEnough2()
        {
            // arange
            ILinkedList<int> myList1 = getTheirs();
            LinkedListNode<int> node1 = myList1.AddLast(1);
            LinkedListNode<int> node2 = myList1.AddLast(2);
            myList1.Clear();

            // act
            try
            {
                int[] ar = new int[10];
                myList1.CopyTo(ar, 9);
                Assert(false);
            }
            catch (Exception)
            {
                Assert(true);
            }
        }

        public void Rollins_Enumterate()
        {
            List<int> verify = new List<int>();
            ILinkedList<int> toTest = getTheirs();
            for (int i = 0; i < Size; i++)
            {
                int num = Rand.Next();
                verify.Add(num);
                toTest.AddLast(num);
            }
            int index = 0;
            foreach (var i in toTest)
            {
                Assert(verify[index++], i);
            }
        }

        public void Rollins_Find_NonEmpty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();

            // act

            LinkedListNode<int> node1 = myList.AddLast(1);
            for (int i = 0; i < 10; i++)
            {
                myList.AddLast(i);
            }
            LinkedListNode<int> node2 = myList.AddLast(1);

            // assert
            // first
            Assert(myList.Find(1).Equals(node1));
            // last
            Assert(myList.FindLast(1).Equals(node2));
        }

        public void Rollins_Find_Empty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();

            // assert
            // first
            Assert(myList.Find(0) == null);
            Assert(myList.Find(100) == null);
            Assert(myList.Find(7) == null);
        }

        public void Rollins_Remove_NonEmpty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();

            // act

            LinkedListNode<int> node1 = myList.AddLast(1);
            for (int i = 0; i < 10; i++)
            {
                myList.AddLast(i);
            }
            LinkedListNode<int> node2 = myList.AddLast(1);

            // assert
            Assert(myList.Remove(3));
            Assert(!myList.Remove(3));
            Assert(myList.Remove(4));
            Assert(!myList.Remove(4));
        }

        public void Rollins_Remove_Empty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();

            // act

            // assert
            Assert(!myList.Remove(3));
            Assert(!myList.Remove(4));
        }

        public void Rollins_RemoveFirst_NonEmpty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();

            // act

            for (int i = 0; i < 10; i++)
            {
                myList.AddLast(i);
            }

            // assert
            myList.RemoveFirst();
            Assert(!myList.Contains(0));
        }

        public void Rollins_RemoveLast_NonEmpty()
        {
            // arange
            ILinkedList<int> myList = getTheirs();

            // act

            for (int i = 0; i < 10; i++)
            {
                myList.AddLast(i);
            }

            // assert
            myList.RemoveLast();
            Assert(!myList.Contains(9));
        }

        public void Rollins_AddAfter_NullValue_Middle()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            string addString = null;

            Assert(myList.Count.Equals(2));
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<string> node3 = myList.AddAfter(node1, addString);

            // assert
            Assert(myList.Count.Equals(3));
            Assert(node1.Equals(myList.First));

            Assert(node3.Equals(node1.Next));
            Assert(node1.Equals(node3.Previous));

            Assert(node3.Value == null);

            Assert(node2.Equals(node3.Next));
            Assert(node3.Equals(node2.Previous));

            Assert(node2.Equals(myList.Last));
        }

        public void Rollins_AddAfter_NullValue_End()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            string addString = null;

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<string> node3 = myList.AddAfter(node2, addString);

            // assert
            Assert(3, myList.Count);
            Assert(node1.Equals(myList.First));

            Assert(node3.Equals(node2.Next));
            Assert(node2.Equals(node3.Previous));

            Assert(node3.Equals(myList.Last));
            Assert(node3.Value == null);
            Assert(node3.Next == null);
        }

        public void Rollins_AddAfter_String_Middle()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            string addString = "String3";

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<string> node3 = myList.AddAfter(node1, addString);

            // assert
            Assert(3, myList.Count);
            Assert(node1.Equals(myList.First));

            Assert(node3.Equals(node1.Next));
            Assert(node1.Equals(node3.Previous));

            Assert(addString.Equals(node3.Value));

            Assert(node2.Equals(node3.Next));
            Assert(node3.Equals(node2.Previous));

            Assert(node2.Equals(myList.Last));
        }

        public void Rollins_AddAfter_String_End()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            string addString = "String3";

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<string> node3 = myList.AddAfter(node2, addString);

            // assert
            Assert(3, myList.Count);
            Assert(node1.Equals(myList.First));

            Assert(node3.Equals(node2.Next));
            Assert(node2.Equals(node3.Previous));

            Assert(node3.Equals(myList.Last));
            Assert(addString.Equals(node3.Value));
            Assert(node3.Next == null);
        }

        public void Rollins_AddBefore_NullValue_Middle()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            string addString = null;

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<string> node3 = myList.AddBefore(node2, addString);

            // assert
            Assert(3, myList.Count);
            Assert(node1.Equals(myList.First));

            Assert(node3.Equals(node1.Next));
            Assert(node1.Equals(node3.Previous));

            Assert(node3.Value == null);

            Assert(node2.Equals(node3.Next));
            Assert(node3.Equals(node2.Previous));

            Assert(node2.Equals(myList.Last));
        }

        public void Rollins_AddBefore_NullValue_Start()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            string addString = null;

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<string> node3 = myList.AddBefore(node1, addString);

            // assert
            Assert(3, myList.Count);
            Assert(node3.Equals(myList.First));
            Assert(node3.Previous == null);
            Assert(node3.Value == null);

            Assert(node1.Equals(node3.Next));
            Assert(node3.Equals(node1.Previous));
        }

        public void Rollins_AddBefore_String_Middle()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            string addString = "String3";

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<string> node3 = myList.AddBefore(node2, addString);

            // assert
            Assert(3, myList.Count);
            Assert(node1.Equals(myList.First));

            Assert(node3.Equals(node1.Next));
            Assert(node1.Equals(node3.Previous));

            Assert(addString.Equals(node3.Value));

            Assert(node2.Equals(node3.Next));
            Assert(node3.Equals(node2.Previous));

            Assert(node2.Equals(myList.Last));
        }

        public void Rollins_AddBefore_String_Start()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            string addString = "String3";

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<string> node3 = myList.AddBefore(node1, addString);

            // assert
            Assert(3, myList.Count);
            Assert(node3.Equals(myList.First));
            Assert(node3.Previous == null);
            Assert(addString.Equals(node3.Value));

            Assert(node1.Equals(node3.Next));
            Assert(node3.Equals(node1.Previous));
        }

        public void Rollins_AddFirst_NullValue_EmptyList()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            string addString = null;

            Assert(0, myList.Count);
            Assert(myList.First == null);
            Assert(myList.Last == null);

            // act
            LinkedListNode<string> node = myList.AddFirst(addString);

            // assert
            Assert(1, myList.Count);
            Assert(node.Previous == null);
            Assert(node.Value == null);
            Assert(node.Equals(myList.First));
            Assert(node.Equals(myList.Last));
            Assert(node.Next == null);
        }

        public void Rollins_AddFirst_NullValue()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            string addString = null;

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<string> node3 = myList.AddFirst(addString);

            // assert
            Assert(3, myList.Count);
            Assert(node3.Equals(myList.First));
            Assert(node3.Previous == null);
            Assert(node3.Value == null);

            Assert(node1.Equals(node3.Next));
            Assert(node3.Equals(node1.Previous));
        }

        public void Rollins_AddFirst_String()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            string addString = "String3";

            Assert(2, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node2.Equals(myList.Last));

            // act
            LinkedListNode<string> node3 = myList.AddFirst(addString);

            // assert
            Assert(3, myList.Count);
            Assert(node3.Equals(myList.First));
            Assert(node3.Previous == null);
            Assert(addString.Equals(node3.Value));

            Assert(node1.Equals(node3.Next));
            Assert(node3.Equals(node1.Previous));
        }

        public void Rollins_AddLast_NullValue_EmptyList()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            int expectedCount = 1;
            string addString = null;

            // act
            LinkedListNode<string> node = myList.AddLast(addString);

            // assert
            Assert(expectedCount, myList.Count);
            Assert(node.Equals(myList.First));
            Assert(node.Equals(myList.Last));
        }

        public void Rollins_AddLast_NullValue()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            int expectedCount = 3;
            string addString = null;

            // act
            LinkedListNode<string> node3 = myList.AddLast(addString);

            // assert
            Assert(expectedCount, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node3.Equals(myList.Last));
        }

        public void Rollins_AddLast_String()
        {
            // arange
            ILinkedList<string> myList = getTheirsStr();
            LinkedListNode<string> node1 = myList.AddLast("String1");
            LinkedListNode<string> node2 = myList.AddLast("String2");
            int expectedCount = 3;
            string addString = "String3";

            // act
            LinkedListNode<string> node3 = myList.AddLast(addString);

            // assert
            Assert(expectedCount, myList.Count);
            Assert(node1.Equals(myList.First));
            Assert(node3.Equals(myList.Last));
        }
        #endregion
    }
}
