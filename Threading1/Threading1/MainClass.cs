using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading1
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(JammingMethod);
            Trace.WriteLine("ThreadState: " + t.ThreadState);
            t.Start();
            Trace.WriteLine("ThreadState: " + t.ThreadState);
            Thread.Sleep(100);
            Trace.WriteLine("ThreadState: " + t.ThreadState);
            Thread.Sleep(1000);
            Trace.WriteLine("ThreadState: " + t.ThreadState);
        }

        static void JammingMethod()
        {
            Thread.Sleep(1000);
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Threading1
//{
//    class MainClass
//    {
//        static void Main(string[] args)
//        {
//            Thread t = new Thread(Burning);
//            //t.IsBackground = false;
//            t.Start();
//            Thread.Sleep(100);
//            Trace.WriteLine("Interupting...");
//            Console.WriteLine("Thread state is {0}", t.ThreadState);
//            Debug.Assert(t.ThreadState == System.Threading.ThreadState.WaitSleepJoin);
//            t.Interrupt();
//            Trace.WriteLine("Join()ing...");
//            Console.WriteLine("Thread state is {0}", t.ThreadState);
//            t.Join();
//            Trace.WriteLine("Leaving main()...");
//        }

//        static void Burning()
//        {
//            Thread.Sleep(Timeout.Infinite);
//            //while (true)
//            //{

//            //}
//        }
//    }
//}



//namespace Threading1
//{
//    class MainClass
//    {
//        static void Main(string[] args)
//        {
//            Thread t = new Thread(Count);
//            t.Start();

//            while (true)
//            {
//                Console.ReadLine();
//                if (t.ThreadState == ThreadState.Running)
//                    t.Suspend();
//                else
//                    t.Resume();
//            }
//        }

//        static void Count()
//        {
//            for (uint i = 0; i < uint.MaxValue; i++)
//            {
//                Console.WriteLine(i);
//            }
//        }
//    }
//}

//namespace Threading1
//{
//    class BarberShop
//    {
//        const int BARB_NUM = 2;
//        const int CHAIR_NUM = 3;

//        static Semaphore barbers = new Semaphore(0, BARB_NUM);
//        static Semaphore customers = new Semaphore(0, CHAIR_NUM);
//        static Semaphore waitingRoom = new Semaphore(CHAIR_NUM, CHAIR_NUM);

//        static void Customer()
//        {
//            // try to get a chair
//            if (waitingRoom.WaitOne(1)) {
//                Console.WriteLine("Customer {0} is waiting on line", Thread.CurrentThread.Name);
//                customers.Release();

//                // wait for barber
//                barbers.WaitOne();
//                // leave the waiting room
//                waitingRoom.Release();
//                Console.WriteLine("Customer {0} is getting their hair cut", Thread.CurrentThread.Name);
//                Thread.Sleep(2000);            
//            }
//            else
//            {
//                Console.WriteLine("Customer {0} left because of no free seats", Thread.CurrentThread.Name);
//            }
//        }

//        static void Barber()
//        {
//            Console.WriteLine("Barber {0} got to work", Thread.CurrentThread.Name);
//            while (true)
//            {
//                // waiting for customer
//                Console.WriteLine("Barber {0} is sleeping", Thread.CurrentThread.Name);
//                customers.WaitOne();
//                // got one
//                Console.WriteLine("Barber {0} woke up", Thread.CurrentThread.Name);
//                barbers.Release();
//                Console.WriteLine("Barber {0} is cutting hair", Thread.CurrentThread.Name);
//                Thread.Sleep(2000);
//                Console.WriteLine("Barber {0} is done cutting hair", Thread.CurrentThread.Name);
//            }
//        }

//        static void Main(string[] args)
//        {

//            Thread barb1 = new Thread(Barber);
//            barb1.Name = "" + 1;
//            barb1.Start();
//            Thread barb2 = new Thread(Barber);
//            barb2.Name = "" + 2;
//            barb2.Start();

//            for (int i = 0; i < 10; i++)
//            {
//                Thread customer = new Thread(Customer);
//                customer.Name = "" + i;
//                customer.Start();
//            }

//            Console.ReadLine();
//        }
//    }
//}
