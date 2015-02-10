using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM1
{

    class Baggage
    {
        char[] array;
        int center;
        Stack<string> moves;

        public Baggage(int num)
        {
            array = new char[num * 4 + 2];
            center = array.Length / 2;
            for (int i = 1; i < num*2; i+=2)
            {
                array[center + i] = 'B';
                array[center + i + 1] = 'A';
            }
        }

        public void Process()
        {
            Console.WriteLine(this.ToString());

            makeSwap(4, -1);

            Console.WriteLine(this.ToString());



        }

        void makeSwap(int one, int two)
        {
            one += center;
            two += center;
            if (!array[two].Equals(default(char)))
            {
                throw new Exception();
            } 
            if (!array[two + 1].Equals(default(char)))
            {
                throw new Exception();
            }

            array[two] = array[one];
            array[two + 1] = array[one + 1];

            array[one] = default(char);
            array[one + 1] = default(char);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool found = false;
            foreach (var i in array)
            {
                if (i != default(char))
                {
                    found = true;
                }

                if (found)
                {
                    if (i == default(char))
                    {
                        sb.Append("_ ");
                    }
                    else
                    {
                        sb.Append(i + " ");
                    }
                }
            }
            return sb.ToString();
        }

    }
}
