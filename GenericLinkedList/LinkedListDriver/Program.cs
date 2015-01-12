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

        static GenericLinkedList<int> GetList()
        {
            return new GenericLinkedList<int>();
        }

        static void Main(string[] args)
        {
            LinkedListTester listTester = new LinkedListTester(GetList);
            listTester.RunAll();
        }
    }
}
