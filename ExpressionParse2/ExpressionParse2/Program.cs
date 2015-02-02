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




            TestIt("5 * 2", 10);
            TestIt("5 + 5", 10);
            TestIt("5 / 5", 1);
            TestIt("5 + 2 * 3 - 4 + 6 / 2", 10);
            TestIt("5 * 2 * 3 * 4 * 6 * 2", 1440);
            TestIt("5 + 2 + 3 + 4 + 6 + 2", 22);
            TestIt("1 + 2 * 3 / 4 - 5", -2.5);
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

            double answer = Solve(Evaluate(s1));
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

            return postfix.Substring(0,postfix.Length-1);
        }

        private static Node Evaluate(string expression)
        {
            
            string[] parts = expression.Split(' ');
            // if only a number...
            if (parts.Length <= 1)
            {
                return new Node()
                {
                    Value = expression
                };
            }

            // else
            Tree newTree = new Tree();
            
            for (int i = 0; i < parts.Length; i++)
            {
                string thisPart = parts[i];
                Node n = Evaluate(thisPart);
                if (newTree.Top == null)
                {
                    newTree.Top = n;
                    newTree.Right = n;
                } else {
                    if (OpVal(n) == 2) { // add to top
                        newTree.Top.Parent = n;
                        n.Left = newTree.Top;
                        newTree.Top = n;
                        newTree.Right = n;
                    }
                    else if (OpVal(n) == 1)
                    { // swap right
                        if (OpVal(newTree.Top) == 1)
                        {
                            n.Left = newTree.Top;
                            n.Left.Parent = n;
                            newTree.Top = n;
                            newTree.Right = n;
                        } else {
                        if (newTree.Right.Parent != null) {
                            newTree.Right.Parent.Right = n;
                        }
                        else
                        {
                            n.Left = newTree.Top;
                            n.Left.Parent = n;
                            newTree.Top = n;
                        }
                        n.Left = newTree.Right;
                        n.Left.Parent = n;
                        newTree.Right = n;
                    }}
                    else // add to bottom
                    {
                        n.Parent = newTree.Right;
                        newTree.Right.Right = n;
                        newTree.Right = n;
                    }
                }
            }
            return newTree.Top;
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

        private static int OpVal(Node s)
        {
            return OpVal(s.Value);
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

        private class Tree
        {
            public Node Top { get; set; }
            public Node Right { get; set; }
        }

        class Node
        {
            public Node Parent;
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