using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParse
{
    class Program
    {
        // Blake Rollins
        // Parse a math expression into a stack and evaluate it
        //

        static void Main(string[] args)
        {

            TestIt("5 * 2", 10);
            TestIt("5 + 5", 10);
            TestIt("5 / 5", 1);
            TestIt("5 + 2 * 3 - 4 + 6 / 2", 10);
            TestIt("5 * 2 * 3 * 4 * 6 * 2", 1440);
            TestIt("5 + 2 + 3 + 4 + 6 + 2", 22);

        }

        private static void TestIt(string s1, int expected)
        {
            
            double answer = Evaluate(s1);
            Console.Write(s1 + " = " + answer);
            if (answer == expected)
            {
                Console.WriteLine(" YAY");
            }
            else
            {
                Console.WriteLine(" BOO");
            }
        }

        private static void PrintStack(Stack<string> stack)
        {
            foreach(string s in stack) {
                Console.Write(s + " ");
            }
            Console.WriteLine();
        }

        public static double Evaluate(string s)
        {
            Stack<string> theStack = new Stack<string>();

            string[] strings = s.Split(' ');
            int i = 0;
            // for each piece of the expression
            while (i < strings.Length)
            {
                // if it is * or / then perform the action before pushing
                string dis = strings[i];
                if (dis.Equals("*"))
                {
                    double left = double.Parse(theStack.Pop());
                    double right = double.Parse(strings[++i]);
                    theStack.Push("" + (left * right));
                }
                else if (dis.Equals("/"))
                {
                    double left = double.Parse(theStack.Pop());
                    double right = double.Parse(strings[++i]);
                    theStack.Push("" + (left / right));
                }
                    // else just push it
                else
                {
                    theStack.Push(dis);
                }
                i++;
                //PrintStack(theStack);
            }

            // Reverse the stack so we can start at the left again
            Stack<string> stackRev = new Stack<string>();
            while (theStack.Count > 0)
            {
                stackRev.Push(theStack.Pop());
            }
            theStack = stackRev;

            // for each piece of the expression
            while (theStack.Count > 1)
            {
                // do the math and push
                double right = double.Parse(theStack.Pop());
                string op = theStack.Pop();
                double left = double.Parse(theStack.Pop());

                if (op.Equals("+"))
                {
                    theStack.Push("" + (right + left));
                }
                else if (op.Equals("-"))
                {
                    theStack.Push("" + (right - left));
                }
                //PrintStack(theStack);
            }

            // return the final value
            return double.Parse(theStack.Pop());
        }
    }
}
