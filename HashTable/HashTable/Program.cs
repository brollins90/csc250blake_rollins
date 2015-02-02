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
            BlakeHashTable<string, int> bht = new BlakeHashTable<string, int>();

            bht.Add("one", 1);
            bht.Add("two", 2);
            PrintIt(bht);
            bht.Add("three", 3);
            bht.Add("four", 4);
            PrintIt(bht);
            bht.Remove("four");
            PrintIt(bht);

            bht["three"] = 3;
            bht["newIndex"] = 11;
            bht["asd"] = 11;
            //bht[null] = "newItem";
            bht["newIndex3"] = default(int);

            PrintIt(bht);



            BlakeHashTable<string, int> hasher = new BlakeHashTable<string, int>();

            hasher.Add("J", 1);
            hasher.Add("T", 2);
            try
            {
                hasher.Add("J", 3);
                Console.WriteLine("failed");
            }
            catch (Exception)
            { }

            foreach (var h in hasher) { Console.WriteLine(h.Key + " " + h.Value); }

            Console.WriteLine("\n" + hasher["J"] + "\n");

            hasher.Remove("J");
            hasher["T"] = 100;
            try { hasher["TJ"] = 100; }
            catch (Exception) { }

            foreach (var h in hasher) { Console.WriteLine(h.Key + " " + h.Value); }

            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        private static void PrintIt(BlakeHashTable<string, int> ht)
        {
            foreach (KeyValuePair<string, int> b in ht)
            {
                Console.WriteLine("Key - {0}, value - {1}", b.Key, b.Value);
            }
            Console.WriteLine();
        }
    }
}
