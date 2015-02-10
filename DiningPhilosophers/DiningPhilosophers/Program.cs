using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Dine(6);
        }

        void Dine(int num)
        {
            Fork[] farks = new Fork[num];
            for (int i = 0; i < num; i++)
            {
                farks[i] = new Fork(i);
            }

            Person[] persons = new Person[num];
            for (int i = 0; i < num; i++)
            {
                int l = (i - 1 > 0) ? i - 1 : num - 1;
                int r = (i + 1 < num) ? i + 1 : 0;
                persons[i] = new Person(i, farks[l], farks[r]);
                Thread t = new Thread(persons[i].Eat);
                t.Start();
            }
        }
    }

    public class Fork
    {
        public int Id { get; set; }
        public bool Held { get; set; }

        public Fork(int id)
        {
            Id = id;
            Held = false;
        }
    }

    public class Person
    {
        static Random Rand = new Random();
        public int Id { get; set; }
        public Fork Left { get; set; }
        public Fork Right { get; set; }

        public Person(int id, Fork l, Fork r)
        {
            this.Id = id;
            this.Left = l;
            this.Right = r;
        }

        public void Eat()
        {
            while (true)
            {
                bool left = false;
                Monitor.TryEnter(Left, 1, ref left);
                try
                {
                    if (left)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Philosopher {0} took fork {1}", this.Id, Left.Id);

                        bool right = false;
                        Monitor.TryEnter(Right, 1, ref right);
                        try
                        {
                            if (right)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Philosopher {0} took fork {1}", this.Id, Right.Id);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Philosopher {0} ate", this.Id);
                                Thread.Sleep(500);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Philosopher {0} couldn't take fork {1}", this.Id, Right.Id);
                            }
                        }
                        finally
                        {
                            if (right)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Philosopher {0} dropped fork {1}", this.Id, Right.Id);
                                Monitor.Exit(Right);
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Philosopher {0} couldn't take fork {1}", this.Id, Left.Id);
                    }
                }
                finally
                {
                    if (left)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Philosopher {0} dropped fork {1}", this.Id, Left.Id);
                        Monitor.Exit(Left);
                    }
                }
                Thread.Sleep(Rand.Next(500,1000));
            }
        }
    }
}
