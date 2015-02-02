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
        }

        private static void TestIt(string s1, double expected)
        {

            double answer = Solve(Evaluate(s1));
            Console.Write(s1 + " = " + answer + " (ex: " + expected + ")");
            if (answer == expected)
            {
                Console.WriteLine(" YAY");
            }
            else
            {
                Console.WriteLine(" BOO");
            }
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
                Node n = Evaluate(parts[i]);
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

        private static int OpVal(Node s)
        {
            if (s == null)
            {
                return -1;
            }
            else
                if (s.Value.Equals("+"))
                {
                    return 2;
                }
                else if (s.Value.Equals("-"))
                {
                    return 2;
                }
                else if (s.Value.Equals("*"))
                {
                    return 1;
                }
                else if (s.Value.Equals("/"))
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
        }

    }
}