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


[ServiceContract(CallbackContract = typeof(ICallbackContract))]
interface Engine
{
    [OperationContract]
    void Subscribe(Failure failures);

    [OperationContract]
    void Unsubscribe(Failure failures);
}

class MyCallbackHandler : ICallbackContract, IDisposable
{
    static object baton = new object();
    static List<Thread> threads = new List<Thread>();
    static Dictionary<Failure, Action> failActions = new Dictionary<Failure, Action>();
    static Engine proxy;
    static Random rand = new Random();

    event Action OnLowAntiFreeze
    {
        add
        {
            lock(baton) 
            {
                if (failActions.ContainsKey(Failure.LowAntifreeze))
                {
                    failActions[Failure.LowAntifreeze] += value;
                }
                else
                {
                    failActions[Failure.LowAntifreeze] = value;
                    proxy.Subscribe(Failure.LowAntifreeze);
                }
            }
        }
        remove
        {
            lock (baton)
            {
                if (failActions.ContainsKey(Failure.LowAntifreeze))
                {
                    failActions[Failure.LowAntifreeze] -= value;

                    if (failActions[Failure.LowAntifreeze] == null)
                    {
                        failActions.Remove(Failure.LowAntifreeze);
                        proxy.Unsubscribe(Failure.LowAntifreeze);
                    }
                }
            }
        }
    }
    event Action OnLowOil
    {
        add
        {
            lock (baton)
            {
                if (failActions.ContainsKey(Failure.LowOil))
                {
                    failActions[Failure.LowOil] += value;
                }
                else
                {
                    failActions[Failure.LowOil] = value;
                    proxy.Subscribe(Failure.LowOil);
                }
            }
        }
        remove
        {
            lock (baton)
            {
                if (failActions.ContainsKey(Failure.LowOil))
                {
                    failActions[Failure.LowOil] -= value;

                    if (failActions[Failure.LowOil] == null)
                    {
                        failActions.Remove(Failure.LowOil);
                        proxy.Unsubscribe(Failure.LowOil);
                    }
                }
            }
        }
    }
    event Action OnOverheating
    {
        add
        {
            lock (baton)
            {
                if (failActions.ContainsKey(Failure.Overheating))
                {
                    failActions[Failure.Overheating] += value;
                }
                else
                {
                    failActions[Failure.Overheating] = value;
                    proxy.Subscribe(Failure.Overheating);
                }
            }
        }
        remove
        {
            lock (baton)
            {
                if (failActions.ContainsKey(Failure.Overheating))
                {
                    failActions[Failure.Overheating] -= value;

                    if (failActions[Failure.Overheating] == null)
                    {
                        failActions.Remove(Failure.Overheating);
                        proxy.Unsubscribe(Failure.Overheating);
                    }
                }
            }
        }
    }
    event Action OnBadSparkPlug
    {
        add
        {
            lock (baton)
            {
                if (failActions.ContainsKey(Failure.BadSparkPlug))
                {
                    failActions[Failure.BadSparkPlug] += value;
                }
                else
                {
                    failActions[Failure.BadSparkPlug] = value;
                    proxy.Subscribe(Failure.BadSparkPlug);
                }
            }
        }
        remove
        {
            lock (baton)
            {
                if (failActions.ContainsKey(Failure.BadSparkPlug))
                {
                    failActions[Failure.BadSparkPlug] -= value;

                    if (failActions[Failure.BadSparkPlug] == null)
                    {
                        failActions.Remove(Failure.BadSparkPlug);
                        proxy.Unsubscribe(Failure.BadSparkPlug);
                    }
                }
            }
        }
    }
    event Action OnCarbonBuildup
    {
        add
        {
            lock (baton)
            {
                if (failActions.ContainsKey(Failure.CarbonBuildup))
                {
                    failActions[Failure.CarbonBuildup] += value;
                }
                else
                {
                    failActions[Failure.CarbonBuildup] = value;
                    proxy.Subscribe(Failure.CarbonBuildup);
                }
            }
        }
        remove
        {
            lock (baton)
            {
                if (failActions.ContainsKey(Failure.CarbonBuildup))
                {
                    failActions[Failure.CarbonBuildup] -= value;

                    if (failActions[Failure.CarbonBuildup] == null)
                    {
                        failActions.Remove(Failure.CarbonBuildup);
                        proxy.Unsubscribe(Failure.CarbonBuildup);
                    }
                }
            }
        }
    }
    event Action OnSeized
    {
        add
        {
            lock (baton)
            {
                if (failActions.ContainsKey(Failure.Seized))
                {
                    failActions[Failure.Seized] += value;
                }
                else
                {
                    failActions[Failure.Seized] = value;
                    proxy.Subscribe(Failure.Seized);
                }
            }
        }
        remove
        {
            lock (baton)
            {
                if (failActions.ContainsKey(Failure.Seized))
                {
                    failActions[Failure.Seized] -= value;

                    if (failActions[Failure.Seized] == null)
                    {
                        failActions.Remove(Failure.Seized);
                        proxy.Unsubscribe(Failure.Seized);
                    }
                }
            }
        }
    }

    Action lowAntiFreeze;// = delegate() { Console.WriteLine("LowAntiFreeze"); };
    Action lowOil;// = delegate() { Console.WriteLine("LowOil"); };
    Action overheating;// = delegate() { Console.WriteLine("Overheating"); };
    Action badSparkPlug;// = delegate() { Console.WriteLine("BadSparkPlug"); };
    Action carbonBuildup;// = delegate() { Console.WriteLine("CarbonBuildup"); };
    Action seized;// = delegate() { Console.WriteLine("Seized"); };
        
    static void Main(string[] args)
    {
        Console.WriteLine("Client start");
        Thread.Sleep(1000);

        proxy = DuplexChannelFactory<Engine>.CreateChannel(
            new MyCallbackHandler(),
            new NetTcpBinding(),
            new EndpointAddress("net.tcp://localhost:1234"));
        Console.WriteLine("Connected");


        MyCallbackHandler c = new MyCallbackHandler();
        for (int i = 0; i < 5; i++)
        {
            Thread t = new Thread(c.Run);
            threads.Add(t);
            t.Start();
        }
        while (true) { }
    }

    public MyCallbackHandler()
    {
        lowAntiFreeze = delegate() { Console.WriteLine("LowAntiFreeze"); };
        lowOil = delegate() { Console.WriteLine("LowOil"); };
        overheating = delegate() { Console.WriteLine("Overheating"); };
        badSparkPlug = delegate() { Console.WriteLine("BadSparkPlug"); };
        carbonBuildup = delegate() { Console.WriteLine("CarbonBuildup"); };
        seized = delegate() { Console.WriteLine("Seized"); };
    }

    void Run()
    {
        Console.WriteLine("Starting Client");
        while (true)
        {
            Thread.Sleep(rand.Next(0, 5000) + 5000);
            if (rand.Next(2) == 1)
            {
                Subscribe((Failure)rand.Next(1, (int)Failure.CarbonBuildup));
            }
            else
            {
                Unsubscribe((Failure)rand.Next(1, (int)Failure.CarbonBuildup));
            }
        }
    }

    void Subscribe(Failure failure)
    {
        Console.WriteLine("sub: " + failure);
        
        if ((failure & Failure.LowAntifreeze) != 0)
            OnLowAntiFreeze += lowAntiFreeze;
        if ((failure & Failure.LowOil) != 0)
            OnLowOil += lowOil;
        if ((failure & Failure.Overheating) != 0)
            OnOverheating += overheating;
        if ((failure & Failure.BadSparkPlug) != 0)
            OnBadSparkPlug += badSparkPlug;
        if ((failure & Failure.CarbonBuildup) != 0)
            OnCarbonBuildup += carbonBuildup;
        if ((failure & Failure.Seized) != 0)
            OnSeized += seized;
    }

    void Unsubscribe(Failure failure)
    {

        Console.WriteLine("unsub: " + failure);
        
        if ((failure & Failure.LowAntifreeze) != 0)
            OnLowAntiFreeze -= lowAntiFreeze;
        if ((failure & Failure.LowOil) != 0)
            OnLowOil -= lowOil;
        if ((failure & Failure.Overheating) != 0)
            OnOverheating -= overheating;
        if ((failure & Failure.BadSparkPlug) != 0)
            OnBadSparkPlug -= badSparkPlug;
        if ((failure & Failure.CarbonBuildup) != 0)
            OnCarbonBuildup -= carbonBuildup;
        if ((failure & Failure.Seized) != 0)
            OnSeized -= seized;
    }
    void ICallbackContract.OnFailure(Failure failures)
    {
        Dictionary<Failure, Action> subs;
        lock (baton)
        {
            subs = new Dictionary<Failure, Action>(failActions);
        }
        foreach (var sub in subs)
        {
            foreach (Failure f in Enum.GetValues(typeof(Failure)))
            {
                if ((sub.Key & failures & f) == f)
                {
                    subs[f].Invoke();
                }
            }
        }
    }


    public void Dispose()
    {
        proxy.Unsubscribe(Failure.Max);
        ((IClientChannel)proxy).Close();
        foreach (var t in threads)
        {
            t.Abort();
        }
        failActions = null;
        baton = null;
    }
}

