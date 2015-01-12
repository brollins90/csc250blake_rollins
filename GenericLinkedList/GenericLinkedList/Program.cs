using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC160_GenericLinkedList;

namespace LinkedListDriver
{
    class Program
    {


        static ILinkedList<int> GetList()
        {
            return new GenericLinkedList<int>();
        }
        static ILinkedList<string> GetListStr()
        {
            return new GenericLinkedList<string>();
        }

        static void Main(string[] args)
        {
            TestLinkedList listTester = new TestLinkedList(GetList, GetListStr);
            listTester.RunAll();

            Console.WriteLine("ALL DONE!");
            string wait = Console.ReadLine();
        }
    }
}
