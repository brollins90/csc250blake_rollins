//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace CSC160_GenericLinkedList
//{
//    public class LinkedListTester2
//    {
//        private const int Size = 1000;
//        private Random random = new Random();
//        private Type ListType { get; set; }
//        private int[] nums = { 1, 14, 523, 165, 73, 325, 73, 56, 2, 743, 0, 2345, 0, 0, 1, 14, 523 };
//        private int[] moreNums;

//        // constructor must be called with type parameter like:
//        // new LinkedListTester(typeof(MyLinkedList<>));
//        public LinkedListTester2(Type listType)
//        {
//            ListType = listType;
//            try
//            {
//                NewIntList();
//            }
//            catch (Exception)
//            {
//                Console.WriteLine("Could not initialize list, all tests failed. See LinkedListTestor constructor");
//                throw new ArgumentException("Could not initialize list, all tests failed. See LinkedListTestor constructor");
//            }

//            moreNums = new int[1000];
//            for (int i = 0; i < moreNums.Length; i++)
//            {
//                moreNums[i] = random.Next(100000) + 1;
//            }
//        }

//        public ILinkedList<int> NewIntList()
//        {
//            //return new GenericLinkedList<int>();
//            return (ILinkedList<int>)Activator.CreateInstance(ListType.MakeGenericType(typeof(int)));
//        }

//        #region Blake Rollins
//        public void Rollins_AddAfter_NullValue_Middle()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = null;

//            Assert(myList.Count.Equals(2));
//            Assert(node1.Equals(myList.First));
//            Assert(node2.Equals(myList.Last));

//            // act
//            LinkedListNode<string> node3 = myList.AddAfter(node1, addString);

//            // assert
//            Assert(myList.Count.Equals(3));
//            Assert(node1.Equals(myList.First));

//            Assert(node3.Equals(node1.Next));
//            Assert(node1.Equals(node3.Previous));

//            Assert(node3.Value == null);

//            Assert(node2.Equals(node3.Next));
//            Assert(node3.Equals(node2.Previous));

//            Assert(node2.Equals(myList.Last));
//        }

//        public void Rollins_AddAfter_NullValue_End()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = null;

//            Assert(2, myList.Count);
//            Assert(node1.Equals(myList.First));
//            Assert(node2.Equals(myList.Last));

//            // act
//            LinkedListNode<string> node3 = myList.AddAfter(node2, addString);

//            // assert
//            Assert(3, myList.Count);
//            Assert(node1.Equals(myList.First));

//            Assert(node3.Equals(node2.Next));
//            Assert(node2.Equals(node3.Previous));

//            Assert(node3.Equals(myList.Last));
//            Assert(node3.Value == null);
//            Assert(node3.Next == null);
//        }

//        public void Rollins_AddAfter_String_Middle()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = "String3";

//            Assert(2, myList.Count);
//            Assert(node1.Equals(myList.First));
//            Assert(node2.Equals(myList.Last));

//            // act
//            LinkedListNode<string> node3 = myList.AddAfter(node1, addString);

//            // assert
//            Assert(3, myList.Count);
//            Assert(node1.Equals(myList.First));

//            Assert(node3.Equals(node1.Next));
//            Assert(node1.Equals(node3.Previous));

//            Assert(addString.Equals(node3.Value));

//            Assert(node2.Equals(node3.Next));
//            Assert(node3.Equals(node2.Previous));

//            Assert(node2.Equals(myList.Last));
//        }

//        public void Rollins_AddAfter_String_End()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = "String3";

//            Assert(2, myList.Count);
//            Assert(node1.Equals(myList.First));
//            Assert(node2.Equals(myList.Last));

//            // act
//            LinkedListNode<string> node3 = myList.AddAfter(node2, addString);

//            // assert
//            Assert(3, myList.Count);
//            Assert(node1.Equals(myList.First));

//            Assert(node3.Equals(node2.Next));
//            Assert(node2.Equals(node3.Previous));

//            Assert(node3.Equals(myList.Last));
//            Assert(addString.Equals(node3.Value));
//            Assert(node3.Next == null);
//        }

//        public void Rollins_AddBefore_NullValue_Middle()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = null;

//            Assert(2, myList.Count);
//            Assert(node1.Equals(myList.First));
//            Assert(node2.Equals(myList.Last));

//            // act
//            LinkedListNode<string> node3 = myList.AddBefore(node2, addString);

//            // assert
//            Assert(3, myList.Count);
//            Assert(node1.Equals(myList.First));

//            Assert(node3.Equals(node1.Next));
//            Assert(node1.Equals(node3.Previous));

//            Assert(node3.Value == null);

//            Assert(node2.Equals(node3.Next));
//            Assert(node3.Equals(node2.Previous));

//            Assert(node2.Equals(myList.Last));
//        }

//        public void Rollins_AddBefore_NullValue_Start()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = null;

//            Assert(2, myList.Count);
//            Assert(node1.Equals(myList.First));
//            Assert(node2.Equals(myList.Last));

//            // act
//            LinkedListNode<string> node3 = myList.AddBefore(node1, addString);

//            // assert
//            Assert(3, myList.Count);
//            Assert(node3.Equals(myList.First));
//            Assert(node3.Previous == null);
//            Assert(node3.Value == null);

//            Assert(node1.Equals(node3.Next));
//            Assert(node3.Equals(node1.Previous));
//        }

//        public void Rollins_AddBefore_String_Middle()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = "String3";

//            Assert(2, myList.Count);
//            Assert(node1.Equals(myList.First));
//            Assert(node2.Equals(myList.Last));

//            // act
//            LinkedListNode<string> node3 = myList.AddBefore(node2, addString);

//            // assert
//            Assert(3, myList.Count);
//            Assert(node1.Equals(myList.First));

//            Assert(node3.Equals(node1.Next));
//            Assert(node1.Equals(node3.Previous));

//            Assert(addString.Equals(node3.Value));

//            Assert(node2.Equals(node3.Next));
//            Assert(node3.Equals(node2.Previous));

//            Assert(node2.Equals(myList.Last));
//        }

//        public void Rollins_AddBefore_String_Start()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = "String3";

//            Assert(2, myList.Count);
//            Assert(node1.Equals(myList.First));
//            Assert(node2.Equals(myList.Last));

//            // act
//            LinkedListNode<string> node3 = myList.AddBefore(node1, addString);

//            // assert
//            Assert(3, myList.Count);
//            Assert(node3.Equals(myList.First));
//            Assert(node3.Previous == null);
//            Assert(addString.Equals(node3.Value));

//            Assert(node1.Equals(node3.Next));
//            Assert(node3.Equals(node1.Previous));
//        }

//        public void Rollins_AddFirst_NullValue_EmptyList()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            string addString = null;

//            Assert(0, myList.Count);
//            Assert(myList.First == null);
//            Assert(myList.Last == null);

//            // act
//            LinkedListNode<string> node = myList.AddFirst(addString);

//            // assert
//            Assert(1, myList.Count);
//            Assert(node.Previous == null);
//            Assert(node.Value == null);
//            Assert(node.Equals(myList.First));
//            Assert(node.Equals(myList.Last));
//            Assert(node.Next == null);
//        }

//        public void Rollins_AddFirst_NullValue()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = null;

//            Assert(2, myList.Count);
//            Assert(node1.Equals(myList.First));
//            Assert(node2.Equals(myList.Last));

//            // act
//            LinkedListNode<string> node3 = myList.AddFirst(addString);

//            // assert
//            Assert(3, myList.Count);
//            Assert(node3.Equals(myList.First));
//            Assert(node3.Previous == null);
//            Assert(node3.Value == null);

//            Assert(node1.Equals(node3.Next));
//            Assert(node3.Equals(node1.Previous));
//        }

//        public void Rollins_AddFirst_String()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = "String3";

//            Assert(2, myList.Count);
//            Assert(node1.Equals(myList.First));
//            Assert(node2.Equals(myList.Last));

//            // act
//            LinkedListNode<string> node3 = myList.AddFirst(addString);

//            // assert
//            Assert(3, myList.Count);
//            Assert(node3.Equals(myList.First));
//            Assert(node3.Previous == null);
//            Assert(addString.Equals(node3.Value));

//            Assert(node1.Equals(node3.Next));
//            Assert(node3.Equals(node1.Previous));
//        }

//        public void Rollins_AddLast_NullValue_EmptyList()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            int expectedCount = 1;
//            string addString = null;

//            // act
//            LinkedListNode<string> node = myList.AddLast(addString);

//            // assert
//            Assert(expectedCount, myList.Count);
//            Assert(node.Equals(myList.First));
//            Assert(node.Equals(myList.Last));
//        }

//        public void Rollins_AddLast_NullValue()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            int expectedCount = 3;
//            string addString = null;

//            // act
//            LinkedListNode<string> node3 = myList.AddLast(addString);

//            // assert
//            Assert(expectedCount, myList.Count);
//            Assert(node1.Equals(myList.First));
//            Assert(node3.Equals(myList.Last));
//        }

//        public void Rollins_AddLast_String()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            int expectedCount = 3;
//            string addString = "String3";

//            // act
//            LinkedListNode<string> node3 = myList.AddLast(addString);

//            // assert
//            Assert(expectedCount, myList.Count);
//            Assert(node1.Equals(myList.First));
//            Assert(node3.Equals(myList.Last));
//        }

//        public void Rollins_Clear_EmptyList()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            int expectedCount = 0;

//            // act
//            myList.Clear();

//            // assert
//            Assert(expectedCount, myList.Count);
//            Assert(myList.First == null);
//            Assert(myList.Last == null);
//        }

//        public void Rollins_Clear_NonEmpty()
//        {
//            // arange
//            ILinkedList<string> myList = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            int expectedCount = 0;

//            // act
//            myList.Clear();

//            // assert
//            Assert(expectedCount, myList.Count);
//            Assert(myList.First == null);
//            Assert(myList.Last == null);
//        }

//        public void Rollins_AddNodeFromDiffList()
//        {
//            // arange
//            ILinkedList<string> myList1 = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            ILinkedList<string> myList2 = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList1.AddLast("String1");
//            LinkedListNode<string> node2 = myList1.AddLast("String2");
//            LinkedListNode<string> node3 = myList2.AddLast("String3");
//            LinkedListNode<string> node4 = myList2.AddLast("String4");

//            // act
//            try
//            {
//                myList2.AddAfter(node1, node2);
//                Assert(false);
//            }
//            catch (Exception)
//            {
//                Assert(true);
//            }
//        }

//        public void Rollins_AddNodeAfterClear()
//        {
//            // arange
//            ILinkedList<string> myList1 = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList1.AddLast("String1");
//            LinkedListNode<string> node2 = myList1.AddLast("String2");
//            myList1.Clear();

//            // act
//            try
//            {
//                LinkedListNode<string> node3 = myList1.AddAfter(node1, "String3");
//                Assert(false);
//            }
//            catch (Exception)
//            {
//                Assert(true);
//            }
//        }

//        public void Rollins_CopyToNotBigEnough()
//        {
//            // arange
//            ILinkedList<string> myList1 = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList1.AddLast("String1");
//            LinkedListNode<string> node2 = myList1.AddLast("String2");
//            myList1.Clear();

//            // act
//            try
//            {
//                string[] ar = new string[1];
//                myList1.CopyTo(ar, 0);
//                Assert(false);
//            }
//            catch (Exception)
//            {
//                Assert(true);
//            }
//        }

//        public void Rollins_CopyToNotBigEnough2()
//        {
//            // arange
//            ILinkedList<string> myList1 = (ILinkedList<string>)Activator.CreateInstance(ListType.MakeGenericType(typeof(string)));
//            LinkedListNode<string> node1 = myList1.AddLast("String1");
//            LinkedListNode<string> node2 = myList1.AddLast("String2");
//            myList1.Clear();

//            // act
//            try
//            {
//                string[] ar = new string[10];
//                myList1.CopyTo(ar, 9);
//                Assert(false);
//            }
//            catch (Exception)
//            {
//                Assert(true);
//            }
//        }

//        public void Rollins_Iterate()
//        {
//            List<int> verify = new List<int>();
//            ILinkedList<int> toTest = (ILinkedList<int>)Activator.CreateInstance(ListType.MakeGenericType(typeof(int)));
//            for (int i = 0; i < Size; i++)
//            {
//                int num = random.Next();
//                verify.Add(num);
//                toTest.AddLast(num);
//            }
//            int index = 0;
//            foreach (var i in toTest)
//            {
//                Assert(verify[index++], i);
//            }
//        }
//        #endregion

//        #region Tests from Shayne
//        public void Hunsaker_AddLast()
//        {
//            ILinkedList<int> intList = NewIntList();
//            for (int i = 0; i < nums.Length; i++)
//            {
//                Assert(intList.Count, i);
//                intList.AddLast(nums[i]);
//            }
//            int[] numsFromList = new int[nums.Length];
//            intList.CopyTo(numsFromList, 0);
//            for (int i = 0; i < nums.Length; i++)
//            {
//                Assert(nums[i], numsFromList[i]);
//            }
//        }

//        public void Hunsaker_AddFirst()
//        {
//            ILinkedList<int> intList = NewIntList();
//            for (int i = 0; i < nums.Length; i++)
//            {
//                Assert(intList.Count, i);
//                intList.AddFirst(nums[i]);
//            }
//            int[] numsFromList = new int[nums.Length];
//            intList.CopyTo(numsFromList, 0);
//            for (int i = 0; i < nums.Length; i++)
//            {
//                Assert(nums[nums.Length - (i + 1)], numsFromList[i]);
//            }
//        }

//        public void Hunsaker_FirstAndLast()
//        {
//            ILinkedList<int> intList = NewIntList();
//            intList.AddFirst(423);
//            Assert(intList.First == intList.Last);

//            intList.Clear();
//            intList.AddLast(423);
//            Assert(intList.First == intList.Last);
//        }

//        public void Hunsaker_AddBeforeFirst()
//        {
//            ILinkedList<int> intList = NewIntList();
//            intList.AddFirst(moreNums[0]);
//            for (int i = 1; i < moreNums.Length; i++)
//            {
//                Assert(intList.Count, i);
//                intList.AddBefore(intList.First, moreNums[i]);
//            }
//            int[] numsFromList = new int[moreNums.Length];
//            intList.CopyTo(numsFromList, 0);
//            for (int i = 0; i < moreNums.Length; i++)
//            {
//                Assert(moreNums[moreNums.Length - (i + 1)], numsFromList[i]);
//            }
//        }

//        public void Hunsaker_AddAfterFirst()
//        {
//            ILinkedList<int> intList = NewIntList();
//            intList.AddFirst(moreNums[0]);
//            for (int i = 1; i < moreNums.Length; i++)
//            {
//                Assert(intList.Count, i);
//                intList.AddAfter(intList.First, moreNums[i]);
//            }
//            int[] numsFromList = new int[moreNums.Length];
//            intList.CopyTo(numsFromList, 0);
//            for (int i = 0; i < moreNums.Length; i++)
//            {
//                Assert(moreNums[(moreNums.Length - i) % moreNums.Length], numsFromList[i]);
//            }
//        }

//        public void Hunsaker_AddBeforeLast()
//        {
//            ILinkedList<int> intList = NewIntList();
//            intList.AddFirst(moreNums[0]);
//            for (int i = 1; i < moreNums.Length; i++)
//            {
//                Assert(intList.Count, i);
//                intList.AddBefore(intList.Last, moreNums[i]);
//            }
//            int[] numsFromList = new int[moreNums.Length];
//            intList.CopyTo(numsFromList, 0);
//            for (int i = 0; i < moreNums.Length; i++)
//            {
//                Assert(moreNums[(i + 1) % moreNums.Length], numsFromList[i]);
//            }
//        }

//        public void Hunsaker_AddAfterLast()
//        {
//            ILinkedList<int> intList = NewIntList();
//            intList.AddFirst(moreNums[0]);
//            for (int i = 1; i < moreNums.Length; i++)
//            {
//                Assert(intList.Count, i);
//                intList.AddAfter(intList.Last, moreNums[i]);
//            }
//            int[] numsFromList = new int[moreNums.Length];
//            intList.CopyTo(numsFromList, 0);
//            for (int i = 0; i < moreNums.Length; i++)
//            {
//                Assert(moreNums[i], numsFromList[i]);
//            }
//        }

//        public void Hunsaker_RandomAdding()
//        {
//            for (int i = 0; i < 100; i++)
//            {
//                ILinkedList<int> intList = NewIntList();
//                LinkedList<int> microsoftList = new LinkedList<int>();

//                int firstNum = random.Next(10000);
//                if (random.Next(2) % 2 == 0)
//                {
//                    intList.AddFirst(firstNum);
//                    microsoftList.AddFirst(firstNum);
//                }
//                else
//                {
//                    intList.AddLast(firstNum);
//                    microsoftList.AddLast(firstNum);
//                }

//                for (int j = 0; j < 1000; j++)
//                {
//                    int nextNum = random.Next(10000);
//                    int nextChoice = random.Next(7);
//                    switch (nextChoice)
//                    {
//                        case 0:
//                            intList.AddLast(nextNum);
//                            microsoftList.AddLast(nextNum);
//                            break;
//                        case 1:
//                            intList.AddFirst(nextNum);
//                            microsoftList.AddFirst(nextNum);
//                            break;
//                        case 3:
//                            intList.AddAfter(intList.First, nextNum);
//                            microsoftList.AddAfter(microsoftList.First, nextNum);
//                            break;
//                        case 4:
//                            intList.AddBefore(intList.First, nextNum);
//                            microsoftList.AddBefore(microsoftList.First, nextNum);
//                            break;
//                        case 5:
//                            intList.AddAfter(intList.Last, nextNum);
//                            microsoftList.AddAfter(microsoftList.Last, nextNum);
//                            break;
//                        case 6:
//                            intList.AddBefore(intList.Last, nextNum);
//                            microsoftList.AddBefore(microsoftList.Last, nextNum);
//                            break;
//                    }
//                }

//                int[] numsFromList = new int[1000];
//                int[] numsFromMicrosoft = new int[1000];
//                intList.CopyTo(numsFromList, 0);
//                microsoftList.CopyTo(numsFromMicrosoft, 0);
//                for (int k = 0; k < moreNums.Length; k++)
//                {
//                    Assert(numsFromList[k], numsFromMicrosoft[k]);
//                }

//                IEnumerator<int> listEnum = intList.GetEnumerator();
//                IEnumerator<int> microEnum = microsoftList.GetEnumerator();
//                while (microEnum.MoveNext())
//                {
//                    listEnum.MoveNext();
//                    Assert(microEnum.Current, listEnum.Current);
//                }
//                Assert(microEnum.Current == listEnum.Current);
//                Assert(microEnum.MoveNext() == listEnum.MoveNext());

//            }
//        }

//        public void Hunsaker_AddRemoveAddRemove()
//        {
//            ILinkedList<int> intList = NewIntList();
//            LinkedList<int> microsoftList = new LinkedList<int>();

//            for (int i = 1; i < 50; i++)
//            {
//                intList.AddFirst(i);
//                microsoftList.AddFirst(i);
//                intList.RemoveFirst();
//                microsoftList.RemoveFirst();
//                intList.AddFirst(i);
//                microsoftList.AddFirst(i);
//                intList.RemoveLast();
//                microsoftList.RemoveLast();
//                intList.AddLast(i);
//                microsoftList.AddLast(i);
//                intList.RemoveFirst();
//                microsoftList.RemoveFirst();
//                intList.AddLast(i);
//                microsoftList.AddLast(i);
//                intList.RemoveLast();
//                microsoftList.RemoveLast();

//                if (i % 15 == 0)
//                {
//                    intList.Clear();
//                    microsoftList.Clear();
//                }

//                intList.AddFirst(i);
//                microsoftList.AddFirst(i);
//                intList.Remove(i);
//                microsoftList.Remove(i);

//                for (int j = 0; j < 5; j++)
//                {
//                    intList.AddFirst(i + j);
//                    microsoftList.AddFirst(i + j);
//                    intList.AddLast(i + j);
//                    microsoftList.AddLast(i + j);
//                }
//                Assert(intList.Count, microsoftList.Count);
//            }

//            int[] numsFromList = new int[1000];
//            int[] numsFromMicrosoft = new int[1000];
//            intList.CopyTo(numsFromList, 0);
//            microsoftList.CopyTo(numsFromMicrosoft, 0);
//            for (int k = 0; k < moreNums.Length; k++)
//            {
//                Assert(numsFromList[k], numsFromMicrosoft[k]);
//            }

//            IEnumerator<int> listEnum = intList.GetEnumerator();
//            IEnumerator<int> microEnum = microsoftList.GetEnumerator();
//            while (microEnum.MoveNext())
//            {
//                listEnum.MoveNext();
//                Assert(microEnum.Current, listEnum.Current);
//            }
//            Assert(microEnum.Current == listEnum.Current);
//            Assert(microEnum.MoveNext() == listEnum.MoveNext());
//        }

//        public void Hunsaker_Contains()
//        {
//            ILinkedList<int> intList = NewIntList();
//            LinkedList<int> microsoftList = new LinkedList<int>();

//            foreach (int num in nums)
//            {
//                intList.AddFirst(num);
//                microsoftList.AddFirst(num);
//            }

//            for (int i = 0; i < nums.Length; i++)
//            {
//                int num = i % 2 == 0 ? nums[i] : nums[i] * 5;
//                bool listContains = intList.Contains(num);
//                bool microsoftContains = microsoftList.Contains(num);
//                Assert(listContains == microsoftContains);
//            }

//            foreach (int num in moreNums)
//            {
//                intList.AddFirst(num);
//                microsoftList.AddFirst(num);
//            }

//            for (int i = 0; i < nums.Length; i++)
//            {
//                int num = random.Next() % 2 == 0 ? nums[i] : nums[i] * -1;
//                bool listContains = intList.Contains(num);
//                bool microsoftContains = microsoftList.Contains(num);
//                Assert(listContains == microsoftContains);
//            }
//        }

//        public void Hunsaker_Find()
//        {
//            ILinkedList<int> intList = NewIntList();
//            LinkedList<int> microsoftList = new LinkedList<int>();

//            foreach (int num in nums)
//            {
//                intList.AddFirst(num);
//                microsoftList.AddFirst(num);
//            }

//            for (int i = 0; i < nums.Length; i++)
//            {
//                int num = i % 2 == 0 ? nums[i] : nums[i] * 5;
//                int? listFound = intList.Find(num) == null ? null : (int?)intList.Find(num).Value;
//                int? microsoftFound = microsoftList.Find(num) == null ? null : (int?)microsoftList.Find(num).Value;
//                Assert(listFound == microsoftFound);
//            }

//            foreach (int num in moreNums)
//            {
//                intList.AddFirst(num);
//                microsoftList.AddFirst(num);
//            }

//            for (int i = 0; i < nums.Length; i++)
//            {
//                int num = random.Next() % 2 == 0 ? nums[i] : nums[i] * -1;
//                int? listFound = intList.Find(num) == null ? null : (int?)intList.Find(num).Value;
//                int? microsoftFound = microsoftList.Find(num) == null ? null : (int?)microsoftList.Find(num).Value;
//                Assert(listFound == microsoftFound);
//            }
//        }

//        public void Hunsaker_FindLast()
//        {
//            ILinkedList<int> intList = NewIntList();
//            LinkedList<int> microsoftList = new LinkedList<int>();

//            foreach (int num in nums)
//            {
//                intList.AddFirst(num);
//                microsoftList.AddFirst(num);
//            }

//            for (int i = 0; i < nums.Length; i++)
//            {
//                int num = i % 2 == 0 ? nums[i] : nums[i] * 5;
//                int? listFound = intList.FindLast(num) == null ? null : (int?)intList.Find(num).Value;
//                int? microsoftFound = microsoftList.FindLast(num) == null ? null : (int?)microsoftList.Find(num).Value;
//                Assert(listFound == microsoftFound);
//            }

//            foreach (int num in moreNums)
//            {
//                intList.AddFirst(num);
//                microsoftList.AddFirst(num);
//            }

//            for (int i = 0; i < nums.Length; i++)
//            {
//                int num = random.Next() % 2 == 0 ? nums[i] : nums[i] * -1;
//                int? listFound = intList.FindLast(num) == null ? null : (int?)intList.Find(num).Value;
//                int? microsoftFound = microsoftList.FindLast(num) == null ? null : (int?)microsoftList.Find(num).Value;
//                Assert(listFound == microsoftFound);
//            }

//            foreach (int num in nums)
//            {
//                intList.AddFirst(num);
//                microsoftList.AddFirst(num);
//            }

//            foreach (int num in nums)
//            {
//                intList.AddFirst(num);
//                microsoftList.AddFirst(num);
//            }

//            foreach (int num in nums)
//            {
//                intList.AddFirst(num);
//                microsoftList.AddFirst(num);
//            }

//            for (int i = 0; i < nums.Length; i++)
//            {
//                int num = i % 2 == 0 ? nums[i] : nums[i] * 5;
//                int? listFound = intList.FindLast(num) == null ? null : (int?)intList.Find(num).Value;
//                int? microsoftFound = microsoftList.FindLast(num) == null ? null : (int?)microsoftList.Find(num).Value;
//                Assert(listFound == microsoftFound);
//            }
//        }

//        public void Hunsaker_Objects()
//        {
//            ILinkedList<Random> randomList = (ILinkedList<Random>)Activator.CreateInstance(ListType.MakeGenericType(typeof(Random)));
//            LinkedList<Random> micrsoftRandom = new LinkedList<Random>();

//            List<Random> someRands = new List<Random>();

//            for (int i = 0; i < 500; i++)
//            {
//                Random rand = new Random();
//                randomList.AddFirst(rand);
//                micrsoftRandom.AddFirst(rand);
//                if (i % 5 == 0)
//                {
//                    someRands.Add(rand);
//                }
//            }

//            foreach (Random rand in someRands)
//            {
//                Assert(randomList.Contains(rand) == micrsoftRandom.Contains(rand));
//                Assert(randomList.Find(rand).Value == micrsoftRandom.Find(rand).Value);
//                Assert(randomList.FindLast(rand).Value == micrsoftRandom.FindLast(rand).Value);
//                Assert(randomList.Remove(rand) == micrsoftRandom.Remove(rand));
//                Assert(randomList.Count, micrsoftRandom.Count);
//            }

//        }

//        public void Hunsaker_ObjectsIncludingNullValues()
//        {
//            ILinkedList<Random> randomList = (ILinkedList<Random>)Activator.CreateInstance(ListType.MakeGenericType(typeof(Random)));
//            LinkedList<Random> micrsoftRandom = new LinkedList<Random>();

//            List<Random> someRands = new List<Random>();

//            for (int i = 0; i < 500; i++)
//            {
//                Random rand = new Random();
//                randomList.AddFirst(rand);
//                micrsoftRandom.AddFirst(rand);
//                if (i % 5 == 0)
//                {
//                    someRands.Add(rand);
//                }
//                if (i % 100 == 0)
//                {
//                    someRands.Add(null);
//                    randomList.Find(rand).Value = null;
//                    micrsoftRandom.Find(rand).Value = null;
//                }
//            }

//            foreach (Random rand in someRands)
//            {
//                Assert(randomList.Contains(rand) == micrsoftRandom.Contains(rand));
//                Assert(micrsoftRandom.Find(rand) == null ? true : randomList.Find(rand).Value == micrsoftRandom.Find(rand).Value);
//                Assert(micrsoftRandom.Find(rand) == null ? true : randomList.FindLast(rand).Value == micrsoftRandom.FindLast(rand).Value);
//                Assert(randomList.Remove(rand) == micrsoftRandom.Remove(rand));
//                Assert(randomList.Count, micrsoftRandom.Count);
//            }
//        }
//        #endregion

//        private void Assert(int should, int actual)
//        {
//            if (should != actual)
//            {
//                Console.WriteLine(should + " != " + actual);
//                throw new Exception();
//            }
//        }
//        private void Assert(bool should)
//        {
//            if (!should)
//            {
//                throw new Exception();
//            }
//        }
//        //private void Assert_AreEqual(Object expected, Object actual,
//        //[CallerMemberName] string callingMethod = null,
//        //[CallerLineNumber] int callingFileLineNumber = 0)
//        //{
//        //    if (!expected.Equals(actual))
//        //    {
//        //        string message = "Objects were not equal.";
//        //        throw new Exception(string.Format("{0} at line {1} ({2})", message, callingFileLineNumber, callingMethod));
//        //    }
//        //}
//        //private void Assert_Fail(
//        //[CallerMemberName] string callingMethod = null,
//        //[CallerLineNumber] int callingFileLineNumber = 0)
//        //{
//        //        string message = "Should have failed by now.";
//        //        throw new Exception(string.Format("{0} at line {1} ({2})", message, callingFileLineNumber, callingMethod));
//        //}
//        //private void Assert_IsNull(Object one,
//        //[CallerMemberName] string callingMethod = null,
//        //[CallerLineNumber] int callingFileLineNumber = 0)
//        //{
//        //    if (one != null)
//        //    {
//        //        string message = "Object should be null.";
//        //        throw new Exception(string.Format("{0} at line {1} ({2})", message, callingFileLineNumber, callingMethod));
//        //    }
//        //}

//        public void RunAll()
//        {
//            List<Tuple<string, Action>> funcs = new List<Tuple<string, Action>>();
//            #region Shayne Hunsaker
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Add First", Hunsaker_AddFirst));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Add Last", Hunsaker_AddLast));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: First and Last", Hunsaker_FirstAndLast));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Add Before First", Hunsaker_AddBeforeFirst));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Add After First", Hunsaker_AddAfterFirst));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Add Before Last", Hunsaker_AddBeforeLast));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Add After Last", Hunsaker_AddAfterLast));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Random Adding", Hunsaker_RandomAdding));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Add Remove Add Remove...", Hunsaker_AddRemoveAddRemove));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Contains", Hunsaker_Contains));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Find", Hunsaker_Find));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: FindLast", Hunsaker_FindLast));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Objects", Hunsaker_Objects));
//            funcs.Add(new Tuple<string, Action>("Hunsaker: Objects Including Null Values", Hunsaker_ObjectsIncludingNullValues));
//            #endregion

//            #region Blake Rollins
//            funcs.Add(new Tuple<string, Action>("Rollins: AddAfter_NullValue_Middle", Rollins_AddAfter_NullValue_Middle));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddAfter_NullValue_End", Rollins_AddAfter_NullValue_End));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddAfter_String_Middle", Rollins_AddAfter_String_Middle));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddAfter_String_End", Rollins_AddAfter_String_End));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddBefore_NullValue_Middle", Rollins_AddBefore_NullValue_Middle));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddBefore_NullValue_Start", Rollins_AddBefore_NullValue_Start));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddBefore_String_Middle", Rollins_AddBefore_String_Middle));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddBefore_String_Start", Rollins_AddBefore_String_Start));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddFirst_NullValue_EmptyList", Rollins_AddFirst_NullValue_EmptyList));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddFirst_NullValue", Rollins_AddFirst_NullValue));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddFirst_String", Rollins_AddFirst_String));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddLast_NullValue_EmptyList", Rollins_AddLast_NullValue_EmptyList));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddLast_NullValue", Rollins_AddLast_NullValue));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddLast_String", Rollins_AddLast_String));
//            funcs.Add(new Tuple<string, Action>("Rollins: Clear_EmptyList", Rollins_Clear_EmptyList));
//            funcs.Add(new Tuple<string, Action>("Rollins: Clear_NonEmpty", Rollins_Clear_NonEmpty));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddNodeFromDiffList", Rollins_AddNodeFromDiffList));
//            funcs.Add(new Tuple<string, Action>("Rollins: AddNodeAfterClear", Rollins_AddNodeAfterClear));
//            funcs.Add(new Tuple<string, Action>("Rollins: CopyToNotBigEnough", Rollins_CopyToNotBigEnough));
//            funcs.Add(new Tuple<string, Action>("Rollins: CopyToNotBigEnough2", Rollins_CopyToNotBigEnough2));
//            funcs.Add(new Tuple<string, Action>("Rollins: Iterate", Rollins_Iterate));
//            #endregion

//            foreach (var action in funcs)
//            {
//                try
//                {
//                    Console.Write("Running " + action.Item1 + " ");
//                    action.Item2();
//                    var t = Console.ForegroundColor;
//                    Console.ForegroundColor = ConsoleColor.DarkGreen;
//                    Console.WriteLine("Pass");
//                    Console.ForegroundColor = t;
//                }
//                catch (Exception e)
//                {
//                    var t = Console.ForegroundColor;
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine("Fail - {0}", e.Message);
//                    Console.ForegroundColor = t;
//                }
//            }
//        }
//    }
//}
