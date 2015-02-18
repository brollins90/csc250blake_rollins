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
            Console.WriteLine("How many philosophers do you have?");
            int numPhilosophers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Ctrl-C to exit");
            Thread.Sleep(300);
            new Program().Dine(numPhilosophers);
        }

        void Dine(int num)
        {
            Fork[] forks = new Fork[num];
            for (int i = 0; i < num; i++)
            {
                forks[i] = new Fork(i);
            }

            Person[] persons = new Person[num];
            for (int i = 0; i < num; i++)
            {
                int l = (i - 1 > 0) ? i - 1 : num - 1;
                int r = (i + 1 < num) ? i + 1 : 0;
                persons[i] = new Person(i, forks[l], forks[r]);
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

        public bool TakeFork(Fork f)
        {
            bool retVal = false;

            Monitor.TryEnter(f, 1, ref retVal);

            if (retVal)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Philosopher {0} took fork {1}", this.Id, f.Id);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Philosopher {0} couldn't take fork {1}", this.Id, f.Id);
            }

            return retVal;
        }

        public void DropFork(Fork f, string reason)
        {
            if (Monitor.IsEntered(f))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Philosopher {0} dropped fork {1}, {2}", this.Id, f.Id, reason);
                Monitor.Exit(f);
            }
        }

        public void Eat()
        {
            while (true)
            {
                bool hasLeft = false;
                bool hasRight = false;
                hasLeft = TakeFork(Left);
                hasRight = TakeFork(Right);
                try
                {
                    if (hasLeft)
                    {
                        if (hasRight)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Philosopher {0} started eating", this.Id);
                            Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Philosopher {0} is done eating", this.Id);
                        }
                        else
                        {
                            DropFork(Left, "because he couldnt take right");
                        }
                    }
                }
                finally
                {
                    DropFork(Left, "because he is done");
                    DropFork(Right, "because he is done");
                }
                Thread.Sleep(Rand.Next(500, 1000));
            }
        }
    }
}
