//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using CSC160_GenericLinkedList;

//namespace GenericLinkedListTests
//{
//    [TestClass]
//    public class GenericLinkedListTests
//    {

//        private ILinkedList<String> GetList()
//        {
//            return new GenericLinkedList<string>();
//            //return new RealLinkedList<string>();
//        }

//        [TestMethod]
//        public void AddAfter_NullValue_EmptyList()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            string addString = null;

//            Assert.AreEqual(0, myList.Count);
//            Assert.IsNull(myList.First);
//            Assert.IsNull(myList.Last);

//            // act
//            LinkedListNode<string> node = myList.AddAfter(null, addString);

//            // assert
//            Assert.AreEqual(1, myList.Count);
//            Assert.IsNull(node.Previous);
//            Assert.IsNull(node.Value);
//            Assert.AreEqual(node, myList.First);
//            Assert.AreEqual(node, myList.Last);
//            Assert.IsNull(node.Next);
//        }

//        [TestMethod]
//        public void AddAfter_NullValue_Middle()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = null;

//            Assert.AreEqual(2, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node2, myList.Last);

//            // act
//            LinkedListNode<string> node3 = myList.AddAfter(node1, addString);

//            // assert
//            Assert.AreEqual(3, myList.Count);
//            Assert.AreEqual(node1, myList.First);

//            Assert.AreEqual(node3, node1.Next);
//            Assert.AreEqual(node1, node3.Previous);

//            Assert.IsNull(node3.Value);

//            Assert.AreEqual(node2, node3.Next);
//            Assert.AreEqual(node3, node2.Previous);

//            Assert.AreEqual(node2, myList.Last);
//        }

//        [TestMethod]
//        public void AddAfter_NullValue_End()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = null;

//            Assert.AreEqual(2, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node2, myList.Last);

//            // act
//            LinkedListNode<string> node3 = myList.AddAfter(node2, addString);

//            // assert
//            Assert.AreEqual(3, myList.Count);
//            Assert.AreEqual(node1, myList.First);

//            Assert.AreEqual(node3, node2.Next);
//            Assert.AreEqual(node2, node3.Previous);

//            Assert.AreEqual(node3, myList.Last);
//            Assert.IsNull(node3.Value);
//            Assert.IsNull(node3.Next);
//        }

//        [TestMethod]
//        public void AddAfter_String_EmptyList()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            string addString = "String3";

//            Assert.AreEqual(0, myList.Count);
//            Assert.IsNull(myList.First);
//            Assert.IsNull(myList.Last);

//            // act
//            LinkedListNode<string> node = myList.AddAfter(null, addString);

//            // assert
//            Assert.AreEqual(1, myList.Count);
//            Assert.IsNull(node.Previous);
//            Assert.AreEqual(addString, node.Value);
//            Assert.AreEqual(node, myList.First);
//            Assert.AreEqual(node, myList.Last);
//            Assert.IsNull(node.Next);
//        }

//        [TestMethod]
//        public void AddAfter_String_Middle()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = "String3";

//            Assert.AreEqual(2, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node2, myList.Last);

//            // act
//            LinkedListNode<string> node3 = myList.AddAfter(node1, addString);

//            // assert
//            Assert.AreEqual(3, myList.Count);
//            Assert.AreEqual(node1, myList.First);

//            Assert.AreEqual(node3, node1.Next);
//            Assert.AreEqual(node1, node3.Previous);

//            Assert.AreEqual(addString, node3.Value);

//            Assert.AreEqual(node2, node3.Next);
//            Assert.AreEqual(node3, node2.Previous);

//            Assert.AreEqual(node2, myList.Last);
//        }

//        [TestMethod]
//        public void AddAfter_String_End()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = "String3";

//            Assert.AreEqual(2, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node2, myList.Last);

//            // act
//            LinkedListNode<string> node3 = myList.AddAfter(node2, addString);

//            // assert
//            Assert.AreEqual(3, myList.Count);
//            Assert.AreEqual(node1, myList.First);

//            Assert.AreEqual(node3, node2.Next);
//            Assert.AreEqual(node2, node3.Previous);

//            Assert.AreEqual(node3, myList.Last);
//            Assert.AreEqual(addString, node3.Value);
//            Assert.IsNull(node3.Next);
//        }
//        [TestMethod]

//        public void AddBefore_NullValue_EmptyList()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            string addString = null;

//            Assert.AreEqual(0, myList.Count);
//            Assert.IsNull(myList.First);
//            Assert.IsNull(myList.Last);

//            // act
//            LinkedListNode<string> node = myList.AddBefore(null, addString);

//            // assert
//            Assert.AreEqual(1, myList.Count);
//            Assert.IsNull(node.Previous);
//            Assert.IsNull(node.Value);
//            Assert.AreEqual(node, myList.First);
//            Assert.AreEqual(node, myList.Last);
//            Assert.IsNull(node.Next);
//        }

//        [TestMethod]
//        public void AddBefore_NullValue_Middle()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = null;

//            Assert.AreEqual(2, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node2, myList.Last);

//            // act
//            LinkedListNode<string> node3 = myList.AddBefore(node2, addString);

//            // assert
//            Assert.AreEqual(3, myList.Count);
//            Assert.AreEqual(node1, myList.First);

//            Assert.AreEqual(node3, node1.Next);
//            Assert.AreEqual(node1, node3.Previous);

//            Assert.IsNull(node3.Value);

//            Assert.AreEqual(node2, node3.Next);
//            Assert.AreEqual(node3, node2.Previous);

//            Assert.AreEqual(node2, myList.Last);
//        }

//        [TestMethod]
//        public void AddBefore_NullValue_Start()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = null;

//            Assert.AreEqual(2, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node2, myList.Last);

//            // act
//            LinkedListNode<string> node3 = myList.AddBefore(node1, addString);

//            // assert
//            Assert.AreEqual(3, myList.Count);
//            Assert.AreEqual(node3, myList.First);
//            Assert.IsNull(node3.Previous);
//            Assert.IsNull(node3.Value);

//            Assert.AreEqual(node1, node3.Next);
//            Assert.AreEqual(node3, node1.Previous);
//        }

//        [TestMethod]
//        public void AddBefore_String_EmptyList()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            string addString = "String3";

//            Assert.AreEqual(0, myList.Count);
//            Assert.IsNull(myList.First);
//            Assert.IsNull(myList.Last);

//            // act
//            LinkedListNode<string> node = myList.AddBefore(null, addString);

//            // assert
//            Assert.AreEqual(1, myList.Count);
//            Assert.IsNull(node.Previous);
//            Assert.AreEqual(addString, node.Value);
//            Assert.AreEqual(node, myList.First);
//            Assert.AreEqual(node, myList.Last);
//            Assert.IsNull(node.Next);
//        }

//        [TestMethod]
//        public void AddBefore_String_Middle()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = "String3";

//            Assert.AreEqual(2, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node2, myList.Last);

//            // act
//            LinkedListNode<string> node3 = myList.AddBefore(node2, addString);

//            // assert
//            Assert.AreEqual(3, myList.Count);
//            Assert.AreEqual(node1, myList.First);

//            Assert.AreEqual(node3, node1.Next);
//            Assert.AreEqual(node1, node3.Previous);

//            Assert.AreEqual(addString, node3.Value);

//            Assert.AreEqual(node2, node3.Next);
//            Assert.AreEqual(node3, node2.Previous);

//            Assert.AreEqual(node2, myList.Last);
//        }

//        [TestMethod]
//        public void AddBefore_String_Start()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = "String3";

//            Assert.AreEqual(2, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node2, myList.Last);

//            // act
//            LinkedListNode<string> node3 = myList.AddBefore(node1, addString);

//            // assert
//            Assert.AreEqual(3, myList.Count);
//            Assert.AreEqual(node3, myList.First);
//            Assert.IsNull(node3.Previous);
//            Assert.AreEqual(addString, node3.Value);

//            Assert.AreEqual(node1, node3.Next);
//            Assert.AreEqual(node3, node1.Previous);
//        }

//        [TestMethod]
//        public void AddFirst_NullValue_EmptyList()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            string addString = null;

//            Assert.AreEqual(0, myList.Count);
//            Assert.IsNull(myList.First);
//            Assert.IsNull(myList.Last);

//            // act
//            LinkedListNode<string> node = myList.AddFirst(addString);

//            // assert
//            Assert.AreEqual(1, myList.Count);
//            Assert.IsNull(node.Previous);
//            Assert.IsNull(node.Value);
//            Assert.AreEqual(node, myList.First);
//            Assert.AreEqual(node, myList.Last);
//            Assert.IsNull(node.Next);
//        }

//        [TestMethod]
//        public void AddFirst_NullValue()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = null;

//            Assert.AreEqual(2, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node2, myList.Last);

//            // act
//            LinkedListNode<string> node3 = myList.AddFirst(addString);

//            // assert
//            Assert.AreEqual(3, myList.Count);
//            Assert.AreEqual(node3, myList.First);
//            Assert.IsNull(node3.Previous);
//            Assert.IsNull(node3.Value);

//            Assert.AreEqual(node1, node3.Next);
//            Assert.AreEqual(node3, node1.Previous);
//        }

//        [TestMethod]
//        public void AddFirst_String()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            string addString = "String3";

//            Assert.AreEqual(2, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node2, myList.Last);

//            // act
//            LinkedListNode<string> node3 = myList.AddFirst(addString);

//            // assert
//            Assert.AreEqual(3, myList.Count);
//            Assert.AreEqual(node3, myList.First);
//            Assert.IsNull(node3.Previous);
//            Assert.AreEqual(addString, node3.Value);

//            Assert.AreEqual(node1, node3.Next);
//            Assert.AreEqual(node3, node1.Previous);
//        }

//        [TestMethod]
//        public void AddLast_NullValue_EmptyList()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            int expectedCount = 1;
//            string addString = null;

//            // act
//            LinkedListNode<string> node = myList.AddLast(addString);

//            // assert
//            Assert.AreEqual(expectedCount, myList.Count);
//            Assert.AreEqual(node, myList.First);
//            Assert.AreEqual(node, myList.Last);
//        }

//        [TestMethod]
//        public void AddLast_NullValue()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            int expectedCount = 3;
//            string addString = null;

//            // act
//            LinkedListNode<string> node3 = myList.AddLast(addString);

//            // assert
//            Assert.AreEqual(expectedCount, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node3, myList.Last);
//        }

//        [TestMethod]
//        public void AddLast_String()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            int expectedCount = 3;
//            string addString = "String3";

//            // act
//            LinkedListNode<string> node3 = myList.AddLast(addString);

//            // assert
//            Assert.AreEqual(expectedCount, myList.Count);
//            Assert.AreEqual(node1, myList.First);
//            Assert.AreEqual(node3, myList.Last);
//        }

//        [TestMethod]
//        public void Clear_EmptyList()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            int expectedCount = 0;

//            // act
//            myList.Clear();

//            // assert
//            Assert.AreEqual(expectedCount, myList.Count);
//            Assert.IsNull(myList.First);
//            Assert.IsNull(myList.Last);
//        }

//        [TestMethod]
//        public void Clear_NonEmpty()
//        {
//            // arange
//            ILinkedList<string> myList = GetList();
//            LinkedListNode<string> node1 = myList.AddLast("String1");
//            LinkedListNode<string> node2 = myList.AddLast("String2");
//            int expectedCount = 0;

//            // act
//            myList.Clear();

//            // assert
//            Assert.AreEqual(expectedCount, myList.Count);
//            Assert.IsNull(myList.First);
//            Assert.IsNull(myList.Last);
//        }

//        //[TestMethod]
//        //public void Insert_StringAt0()
//        //{
//        //    // arange
//        //    ILinkedList<string> myList = GetList();
//        //    myList.Add("String1");
//        //    myList.Add("String2");
//        //    string addString = "added";
//        //    int addIndex = 0;

//        //    // act
//        //    myList.Insert(addString, addIndex);

//        //    // assert
//        //    Assert.AreEqual(addString, myList.Get(addIndex));
//        //}

//        //[TestMethod]
//        //public void Insert_StringAt1()
//        //{
//        //    // arange
//        //    ILinkedList<string> myList = GetList();
//        //    myList.Add("String1");
//        //    myList.Add("String2");
//        //    string addString = "added";
//        //    int addIndex = 1;

//        //    // act
//        //    myList.Insert(addString, addIndex);

//        //    // assert
//        //    Assert.AreEqual(addString, myList.Get(addIndex));
//        //}

//        //[TestMethod]
//        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
//        //public void Insert_StringAt15_TooBigIndex()
//        //{
//        //    // arange
//        //    ILinkedList<string> myList = GetList();
//        //    myList.Add("String1");
//        //    myList.Add("String2");
//        //    string addString = "added";
//        //    int addIndex = 15;

//        //    // act
//        //    myList.Insert(addString, addIndex);

//        //    // assert
//        //    //Assert.AreEqual(addString, myList.Get(addIndex));
//        //}

//        //[TestMethod]
//        //[ExpectedException(typeof(IndexOutOfRangeException))]
//        //public void Get_IndexTooLarge()
//        //{
//        //    // arange
//        //    ILinkedList<string> myList = GetList();
//        //    myList.Add("String1");
//        //    myList.Add("String2");
//        //    int index = 15;

//        //    // act
//        //    String retrieved = myList.Get(index);

//        //    // assert
//        //    //Assert.AreEqual(addString, myList.Get(addIndex));
//        //}

//        //[TestMethod]
//        //[ExpectedException(typeof(IndexOutOfRangeException))]
//        //public void Get_Index0()
//        //{
//        //    // arange
//        //    ILinkedList<string> myList = GetList();
//        //    int index = 0;

//        //    // act
//        //    String retrieved = myList.Get(index);

//        //    // assert
//        //    //Assert.AreEqual(addString, myList.Get(addIndex));
//        //}
//    }
//}
