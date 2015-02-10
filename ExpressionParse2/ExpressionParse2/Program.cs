using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParse2
{
    class Program
    {
        // Blake Rollins
        // Parse a math expression into a tree and evaluate
        //
        // First time I failed at the recursion.  Once I decided to read a postfix string, the 
        // evaluate function was simple and clean.
        //

        static void Main(string[] args)
        {

            TestInfixToPostfix("1 + 2 * 3 - 4", "1 2 3 * + 4 -");
            TestInfixToPostfix("5 * 2", "5 2 *");
            TestInfixToPostfix("5 + 2", "5 2 +");
            TestInfixToPostfix("5 / 5", "5 5 /");
            TestInfixToPostfix("5 + 2 * 3 - 4 + 6 / 2", "5 2 3 * + 4 - 6 2 / +");
            TestInfixToPostfix("5 * 2 * 3 * 4 * 6 * 2", "5 2 * 3 * 4 * 6 * 2 *");
            TestInfixToPostfix("5 + 2 + 3 + 4 + 6 + 2", "5 2 + 3 + 4 + 6 + 2 +");
            TestInfixToPostfix("3 + 1 + 9 - 3 / 1 - 2 * 3 + 4 / 2 * 2 / 4", "3 1 + 9 + 3 1 / - 2 3 * - 4 2 / 2 * 4 / +");


            TestIt("5 * 2", 5 * 2);
            TestIt("5 + 5", 5 + 5);
            TestIt("5 / 5", 5 / 5);
            TestIt("5 + 2 * 3 - 4 + 6 / 2", 5 + 2 * 3 - 4 + 6 / 2);
            TestIt("5 * 2 * 3 * 4 * 6 * 2", 5 * 2 * 3 * 4 * 6 * 2);
            TestIt("5 + 2 + 3 + 4 + 6 + 2", 5 + 2 + 3 + 4 + 6 + 2);
            //TestIt("1 + 2 * 3 / 4 - 5", 1 + 2 * 3 / 4 - 5);
            TestIt("1 + 2 * 3", 1 + 2 * 3);
            TestIt("1 + 2 * 3", 1 + 2 * 3);
            TestIt("8 / 4 / 2", 8 / 4 / 2);
            TestIt("8 / 4 / 2 * 2", 8 / 4 / 2 * 2);
            TestIt("8 / 4 * 2 / 2", 8 / 4 * 2 / 2);
            TestIt("3 + 1 + 9 - 3 / 1 - 2 * 3 + 4 / 2 * 2 / 4", 3 + 1 + 9 - 3 / 1 - 2 * 3 + 4 / 2 * 2 / 4);
            TestIt("3 + 1 + 9 - 3 / 1", 3 + 1 + 9 - 3 / 1);
            TestIt("2 * 3 + 4 / 2 * 2 / 4", 2 * 3 + 4 / 2 * 2 / 4);
            TestIt("3 + 4 / 2 * 2 / 4", 3 + 4 / 2 * 2 / 4);
            TestIt("3 + 4 / 2 * 2", 3 + 4 / 2 * 2);
            TestIt("3 + 4 / 2", 3 + 4 / 2);
            TestIt("4 / 2 * 2 / 4", 4 / 2 * 2 / 4);


            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        private static void TestIt(string s1, double expected)
        {

            double answer = Solve(CreateTreeFromInfixExpression(s1));
            Console.Write(s1 + " = " + answer + " (ex: " + expected + ")");
            if (answer == expected)
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = t;
            }
            else
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");
                Console.ForegroundColor = t;
            }
        }

        private static void TestInfixToPostfix(string s1, string expected)
        {

            string actual = InfixToPostfix(s1);
            Console.Write(s1 + " => " + actual + " (ex: " + expected + ")");
            if (expected.Equals(actual))
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Pass");
                Console.ForegroundColor = t;
            }
            else
            {
                var t = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Fail");
                Console.ForegroundColor = t;
            }
        }

        private static Node CreateTreeFromInfixExpression(string expression)
        {
            string postfix = InfixToPostfix(expression);
            string[] parts = postfix.Split(' ');

            Stack<Node> stack = new Stack<Node>();

            for (int i = 0; i < parts.Length; i++)
            {
                string cur = parts[i];
                int opval = OpVal(cur);

                if (opval == 0) // here we have an operand
                {
                    stack.Push(new Node() { Value = cur });
                }
                else // operator
                {
                    stack.Push(new Node() { Value = cur, Right = stack.Pop(), Left = stack.Pop() });
                }
            }
            int asdfsadf = 4;

            return stack.Pop();
        }

        public static string InfixToPostfix(string infix)
        {
            Stack<string> stack = new Stack<string>();
            string postfix = "";


            string[] parts = infix.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                string cur = parts[i];
                int opval = OpVal(cur);

                if (opval == 0) // here we have an operand
                {
                    postfix += cur + " ";
                }
                else // here we have an operator
                {
                    if (stack.Count != 0)
                    {
                        while (stack.Count > 0 && opval >= OpVal(stack.Peek()))
                        {
                            postfix += stack.Pop() + " ";
                        }
                    }
                    stack.Push(cur);
                }
            }

            // put what is left in the stack on the output string
            while (stack.Count > 0)
            {
                postfix += stack.Pop() + " ";
            }

            return postfix.Substring(0, postfix.Length - 1);
        }

        private static int OpVal(string s)
        {
            if (s == null)
            {
                return -1;
            }
            else
                if (s.Equals("+"))
                {
                    return 2;
                }
                else if (s.Equals("-"))
                {
                    return 2;
                }
                else if (s.Equals("*"))
                {
                    return 1;
                }
                else if (s.Equals("/"))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
        }

        private static double Solve(Node top)
        {
            if (top.Left == null && top.Right == null)
            {
                return double.Parse(top.Value);
            }
            else if (top.Value.Equals("+"))
            {
                return Solve(top.Left) + Solve(top.Right);
            }
            else if (top.Value.Equals("-"))
            {
                return Solve(top.Left) - Solve(top.Right);
            }
            else if (top.Value.Equals("*"))
            {
                return Solve(top.Left) * Solve(top.Right);
            }
            else// if (top.Value.Equals("/"))
            {
                return Solve(top.Left) / Solve(top.Right);
            }
            // ....

        }

        class Node
        {
            public Node Left;
            public Node Right;
            public string Value;
            public Node() { }

            public override string ToString()
            {
                return this.Value;
            }
        }

    }
}