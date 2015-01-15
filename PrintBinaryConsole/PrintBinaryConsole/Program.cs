using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintBinaryConsole
{
    class Program
    {
        // need to know the location of the spaces
        private static uint s1 = (uint.MinValue + 1 << 27);
        private static uint s2 = (uint.MinValue + 1 << 23);
        private static uint s3 = (uint.MinValue + 1 << 19);
        private static uint s4 = (uint.MinValue + 1 << 15);
        private static uint s5 = (uint.MinValue + 1 << 11);
        private static uint s6 = (uint.MinValue + 1 << 7);
        private static uint s7 = (uint.MinValue + 1 << 3);

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number between {0} and {1}", int.MinValue, int.MaxValue);
            int val = int.Parse(Console.ReadLine());
            PrintBinary(val);
            intToIP(val);

            Console.WriteLine("Done (Press enter to continue)");
            Console.ReadLine();
        }

        private static void PrintBinary(int val)
        {
            // create a uint with one bit on on the left
            uint i = uint.MinValue + 1 << 31;

            // until the pointer is 0
            while (i > 0)
            {
                // if the number and the pointer both have the same bit on
                if ((val & i) == 0)
                    Console.Write('0');
                else
                    Console.Write('1');

                // shift the pointer
                i = i >> 1;

                // check for a space
                if (!(((s1 & i) == 0) && ((s2 & i) == 0) && ((s3 & i) == 0) &&
                ((s4 & i) == 0) && ((s5 & i) == 0) && ((s6 & i) == 0) &&
                ((s7 & i) == 0)))
                    Console.Write(' ');
            }
            Console.Write("\n");
        }

        private static void intToIP(int val)
        {
            uint first = ((uint)val >> 24);
            uint second = (((uint)val << 8) >> 24);
            uint third = (((uint)val << 16) >> 24);
            uint fourth = (((uint)val << 24) >> 24);
            Console.WriteLine("{0}.{1}.{2}.{3}", first, second, third, fourth);
        }
    }
}
