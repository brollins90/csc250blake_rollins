using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMeansLib;

namespace KMeansConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            KMeaner meaner = KMeaner.RandomKMeaner(4,20);

            KMeansProcess.KMeanCluster(meaner);

            meaner.Print();

            Console.ReadKey();

        }
    }
}
