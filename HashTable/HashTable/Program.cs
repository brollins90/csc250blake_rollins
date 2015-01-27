using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            BlakeHashTable bht = new BlakeHashTable();

            bht.Add("one", "The");
            bht.Add("two", "quick");
            PrintIt(bht);
            bht.Add("three", "brown");
            bht.Add("four", "fox");
            PrintIt(bht);
            bht.Remove("four");
            PrintIt(bht);

            bht["three"] = "newItem";
            bht["newIndex"] = "newItem";
            bht[3] = "newItem";
            //bht[null] = "newItem";
            bht["newIndex3"] = null;

            PrintIt(bht);
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        private static void PrintIt(BlakeHashTable ht)
        {
            foreach (Bucket b in ht)
            {
                Console.WriteLine("Key - {0}, value - {1}", b.Key, b.Value);
            }
            Console.WriteLine();
        }
    }
}
