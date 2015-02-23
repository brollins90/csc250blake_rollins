using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[Flags]
enum Failure
{
    LowAntifreeze   = 0x1,
    LowOil          = 0x2,
    Overheating     = 0x4,
    BadSparkPlug    = 0x8,
    CarbonBuildup   = 0x10,
    Seized          = 0x20,
    Max             = 0x40
}

interface ICallbackContract
{
    [OperationContract]
    void OnFailure(Failure failures);
}

[ServiceBehavior(
    ConcurrencyMode = ConcurrencyMode.Reentrant,
    InstanceContextMode = InstanceContextMode.Single)]
[ServiceContract(CallbackContract = typeof(ICallbackContract))]
public class Engine
{
    object baton = new object();
    static Random rand = new Random();
    static Dictionary<ICallbackContract, Failure> subscriptions = new Dictionary<ICallbackContract, Failure>();

    public Engine()
    {
        Console.WriteLine("Create engine");
        Thread t = new Thread(Run);
        t.Start();
    }

    [OperationContract]
    void Subscribe(Failure failures)
    {
        Console.WriteLine("Subscribe: {0}", failures);
        ICallbackContract callback = OperationContext.Current.GetCallbackChannel<ICallbackContract>();

        lock (baton)
        {
            subscriptions[callback] =
                subscriptions.ContainsKey(callback) ?
                subscriptions[callback] | failures :
                failures;
        }
    }

    [OperationContract]
    void Unsubscribe(Failure failures)
    {
        Console.WriteLine("Unsubscribe: {0}", failures);
        ICallbackContract callback = OperationContext.Current.GetCallbackChannel<ICallbackContract>();

        lock (baton)
        {
            if (subscriptions.ContainsKey(callback))
            {
                subscriptions[callback] &= ~(failures);
            }
            else
            {
                throw new InvalidOperationException("Cannot find callback");
            }
        }
    }

    void FireFailures(Failure failures)
    {
        Console.WriteLine("FiringFailures: {0}", failures);

        Dictionary<ICallbackContract, Failure> subs;
        lock (baton)
        {
            subs = new Dictionary<ICallbackContract, Failure>(subscriptions);
        }

        foreach (var sub in subs)
        {
            //foreach (Failure f in Enum.GetValues(typeof(Failure)))
            //{
            //    if ((sub.Value & failures & f) == f)
            //    {
            //        sub.Key.OnFailure(f);
            //    }
            //}
            Failure message = sub.Value & failures;
            if (message != 0)
            {
                ThreadPool.QueueUserWorkItem(
                    delegate(object t)
                    {
                        ICallbackContract x = t as ICallbackContract;
                        try
                        {
                            sub.Key.OnFailure(message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Someone hung up. removing them");
                            lock (baton)
                            {
                                subscriptions.Remove(x);
                            }
                        }
                    },
                    sub);
            }
        }

    }

    Failure MakeRandomFailures()
    {
        //Failure retVal = Failure.None;
        //foreach (Failure f in Enum.GetValues(typeof(Failure)))
        //{
        //    int r = rand.Next(2);
        //    if (r == 1)
        //    {
        //        retVal |= f;
        //    }
        //}
        return (Failure)rand.Next(1, (int)Failure.Max);
    }

    public void Run()
    {
        while (true)
        {
            Thread.Sleep(2000);
            FireFailures(MakeRandomFailures());
        }
    }
}



class Server
{
    static void Main(string[] args)
    {
        Console.WriteLine("Server");
        var host = new ServiceHost(typeof(Engine));
        host.AddServiceEndpoint(typeof(Engine),
            new NetTcpBinding(),
            "net.tcp://localhost:1234");
        host.Open();
        Console.ReadLine();
    }
}
