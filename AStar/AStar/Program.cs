using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AStar
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Node> nodeList = new List<Node>();

            Node a = new Node("a")
            {
                Location = new Point()
                {
                    X = -19,
                    Y = 11
                }
            };
            nodeList.Add(a);

            Node b = new Node("b")
            {
                Location = new Point()
                {
                    X = -13,
                    Y = 13
                }
            };
            nodeList.Add(b);

            Node c = new Node("c")
            {
                Location = new Point()
                {
                    X = 4,
                    Y = 14
                }
            };
            nodeList.Add(c);

            Node d = new Node("d")
            {
                Location = new Point()
                {
                    X = -4,
                    Y = 12
                }
            };
            nodeList.Add(d);

            Node e = new Node("e")
            {
                Location = new Point()
                {
                    X = -8,
                    Y = 3
                }
            };
            nodeList.Add(e);

            Node f = new Node("f")
            {
                Location = new Point()
                {
                    X = -18,
                    Y = 1
                }
            };
            nodeList.Add(f);

            Node g = new Node("g")
            {
                Location = new Point()
                {
                    X = -12,
                    Y = -8
                }
            };
            nodeList.Add(g);

            Node h = new Node("h")
            {
                Location = new Point()
                {
                    X = 12,
                    Y = -9
                }
            };
            nodeList.Add(h);

            Node i = new Node("i")
            {
                Location = new Point()
                {
                    X = -18,
                    Y = -11
                }
            };
            nodeList.Add(i);

            Node j = new Node("j")
            {
                Location = new Point()
                {
                    X = -4,
                    Y = -11
                }
            };
            nodeList.Add(j);

            Node k = new Node("k")
            {
                Location = new Point()
                {
                    X = -12,
                    Y = -14
                }
            };
            nodeList.Add(k);

            Node l = new Node("l")
            {
                Location = new Point()
                {
                    X = 2,
                    Y = -18
                }
            };
            nodeList.Add(l);

            Node m = new Node("m")
            {
                Location = new Point()
                {
                    X = 18,
                    Y = -13
                }
            };
            nodeList.Add(m);

            Node n = new Node("n")
            {
                Location = new Point()
                {
                    X = 4,
                    Y = -9
                }
            };
            nodeList.Add(n);

            Node o = new Node("o")
            {
                Location = new Point()
                {
                    X = 22,
                    Y = 11
                }
            };
            nodeList.Add(o);

            Node p = new Node("p")
            {
                Location = new Point()
                {
                    X = 18,
                    Y = 3
                }
            };
            nodeList.Add(p);

            a.AddConnection(b);
            a.AddConnection(e);

            b.AddConnection(a);
            b.AddConnection(d);

            c.AddConnection(d);
            c.AddConnection(e);
            c.AddConnection(p);

            d.AddConnection(b);
            d.AddConnection(c);
            d.AddConnection(e);

            e.AddConnection(a);
            e.AddConnection(c);
            e.AddConnection(d);
            e.AddConnection(g);
            e.AddConnection(j);
            e.AddConnection(n);

            f.AddConnection(g);
            f.AddConnection(i);

            g.AddConnection(e);
            g.AddConnection(f);
            g.AddConnection(j);

            h.AddConnection(n);
            h.AddConnection(p);

            i.AddConnection(f);
            i.AddConnection(k);

            j.AddConnection(e);
            j.AddConnection(g);
            j.AddConnection(k);
            j.AddConnection(l);

            k.AddConnection(i);
            k.AddConnection(j);
            k.AddConnection(l);

            l.AddConnection(j);
            l.AddConnection(k);
            l.AddConnection(m);

            m.AddConnection(l);
            m.AddConnection(o);
            m.AddConnection(p);

            n.AddConnection(e);
            n.AddConnection(h);

            o.AddConnection(p);
            o.AddConnection(m);

            p.AddConnection(c);
            p.AddConnection(h);
            p.AddConnection(m);
            p.AddConnection(o);


            bool running = true;
            while (running)
            {
                Console.WriteLine("AStar console.");
                Console.WriteLine("Enter the start node letter");
                string start = "" + getNode();
                Console.WriteLine("Enter the end node letter");
                string end = "" + getNode();


                Console.WriteLine("Searching from Node {0} to Node {1}", start, end);
                Console.WriteLine("Found:");
                Console.WriteLine(AStar.Process(nodeList.Find(x => x.Name.Equals(start)), nodeList.Find(x => x.Name.Equals(end))));

                Console.WriteLine("");
                Console.WriteLine("");
            }


            //TestIt("a,b", a, b);
            //TestIt("a,b,d,c", a, c);
            //TestIt("a,b,d", a, d);
            //TestIt("a,e", a, e);
            //TestIt("a,e,g,f", a, f);
            //TestIt("a,e,g", a, g);
            //TestIt("a,e,n,h", a, h);
            //TestIt("a,e,j,k,i", a, i);
            //TestIt("a,e,j", a, j);
            //TestIt("a,e,j,k", a, k);
            //TestIt("a,e,j,l", a, l);
            //TestIt("a,e,j,l,m", a, m);
            //TestIt("a,e,n", a, n);
            //TestIt("a,b,d,c,p,o", a, o);
            //TestIt("a,b,d,c,p", a, p);

            //Console.WriteLine("Press a key to continue");
            //Console.ReadKey();
        }

        private static char getNode()
        {
            bool valid = false;
            while (!valid)
            {
                try
                {
                    string start = Console.ReadLine().Substring(0, 1);
                    
                    char oneChar = start.ToCharArray()[0];
                    if (oneChar >= 'a' && oneChar <= 'p')
                    {
                        return (oneChar);
                    }
                }
                catch (Exception) { }

                Console.WriteLine("input is not a valid node.  try again");
            }
            return '0';
        }


        static void TestIt(String expected, Node one, Node two)
        {
            Console.Write("Path from {0} to {1}: ",one.Name, two.Name);

            string actual = AStar.Process(one, two);

            Console.Write("({0})", actual);
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
        
    }
}
