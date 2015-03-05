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

class ClientProxy : ICallbackContract, IDisposable
{
    Engine proxy;
    Dictionary<Failure, Action> subscribers = new Dictionary<Failure, Action>();

    public ClientProxy()
    {
        proxy = DuplexChannelFactory<Engine>.CreateChannel(
            this,
            new NetTcpBinding(),
            new EndpointAddress("net.tcp://localhost:1234"));
    }

    #region Subscription methods
    void Subscribe(Failure failure, Action action)
    {
        lock (subscribers)
        {
            if (subscribers.ContainsKey(failure))
            {
                subscribers[failure] += action;
            }
            else
            {
                subscribers.Add(failure, action);
                ThreadPool.QueueUserWorkItem(s => proxy.Subscribe(failure));
            }
        }
    }

    void Unsubscribe(Failure failure, Action action)
    {
        lock (subscribers)
        {
            if (subscribers.ContainsKey(failure))
            {
                subscribers[failure] -= action;

                if (subscribers[failure] == null)
                {
                    ThreadPool.QueueUserWorkItem(s => proxy.Unsubscribe(failure));
                }
            }
        }
    }
    #endregion

    #region Events
    public event Action LowAntifreeze
    {
        add
        {
            Subscribe(Failure.LowAntifreeze, value);
        }
        remove
        {
            Unsubscribe(Failure.LowAntifreeze, value);
        }
    }

    public event Action LowOil
    { 
        add 
        {
            Subscribe(Failure.LowOil, value);
        }
        remove
        {
            Unsubscribe(Failure.LowOil, value);
        }
    }

    public event Action Overheating
    {
        add
        {
            Subscribe(Failure.Overheating, value);
        }
        remove
        {
            Unsubscribe(Failure.Overheating, value);
        }
    }

    public event Action BadSparkPlug
    {
        add
        {
            Subscribe(Failure.BadSparkPlug, value);
        }
        remove
        {
            Unsubscribe(Failure.BadSparkPlug, value);
        }
    }

    public event Action CarbonBuildup
    {
        add
        {
            Subscribe(Failure.CarbonBuildup, value);
        }
        remove
        {
            Unsubscribe(Failure.CarbonBuildup, value);
        }
    }

    public event Action Seized
    {
        add
        {
            Subscribe(Failure.Seized, value);
        }
        remove
        {
            Unsubscribe(Failure.Seized, value);
        }
    }

    #endregion

    #region Interface methods
    void ICallbackContract.OnFailure(Failure failures)
    {
        Dictionary<Failure, Action> subs;
        lock (subscribers)
        {
            subs = new Dictionary<Failure, Action>(subscribers);
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
        ((IClientChannel)proxy).Dispose();
    }
    #endregion
}

[ServiceContract(CallbackContract = typeof(ICallbackContract))]
interface Engine
{
    [OperationContract]
    void Subscribe(Failure failures);

    [OperationContract]
    void Unsubscribe(Failure failures);
}

class Client
{
    static void Main(string[] args)
    {
        Console.WriteLine("Client");
        Thread.Sleep(1000);

        //for (int i = 0; i < 5; i++)
        //{
        //    TestThing tt = new TestThing();
        //    Thread t = new Thread(new ThreadStart(tt.Run));
        //    t.Start();
        //}
        var handler = new ClientProxy();
        
        handler.LowOil += () => Console.WriteLine("Oil is low");
        Console.Read();
        //handler.LowAntifreeze += () => Console.WriteLine("LowAntifreeze");

        //var handler2 = new MyCallbackHandler();
        //handler2.LowAntifreeze += () => Console.WriteLine("LowAntifreeze number two");
    }
    
}

#region Test stuff
class TestThing
{
    ClientProxy p = new ClientProxy();

    Random rand = new Random();
    Action lowAntiFreeze = delegate() { Console.WriteLine("LowAntiFreeze"); };
    Action lowOil = delegate() { Console.WriteLine("LowOil"); };
    Action overheating = delegate() { Console.WriteLine("Overheating"); };
    Action badSparkPlug = delegate() { Console.WriteLine("BadSparkPlug"); };
    Action carbonBuildup = delegate() { Console.WriteLine("CarbonBuildup"); };
    Action seized = delegate() { Console.WriteLine("Seized"); };
    
    public void Run()
    {
        Console.WriteLine("Starting Client");
        while (true)
        {
            Thread.Sleep(rand.Next(0, 5000) + 5000);
            if (rand.Next(2) == 1)
            {
                SubscribeTest((Failure)rand.Next(1, (int)Failure.CarbonBuildup));
            }
            else
            {
                UnsubscribeTest((Failure)rand.Next(1, (int)Failure.CarbonBuildup));
            }
        }
    }


    void SubscribeTest(Failure failure)
    {
        Console.WriteLine("sub: " + failure);

        if ((failure & Failure.LowAntifreeze) != 0)
            p.LowAntifreeze += lowAntiFreeze;
        if ((failure & Failure.LowOil) != 0)
            p.LowOil += lowOil;
        if ((failure & Failure.Overheating) != 0)
            p.Overheating += overheating;
        if ((failure & Failure.BadSparkPlug) != 0)
            p.BadSparkPlug += badSparkPlug;
        if ((failure & Failure.CarbonBuildup) != 0)
            p.CarbonBuildup += carbonBuildup;
        if ((failure & Failure.Seized) != 0)
            p.Seized += seized;
    }

    void UnsubscribeTest(Failure failure)
    {

        Console.WriteLine("unsub: " + failure);

        if ((failure & Failure.LowAntifreeze) != 0)
            p.LowAntifreeze -= lowAntiFreeze;
        if ((failure & Failure.LowOil) != 0)
            p.LowOil -= lowOil;
        if ((failure & Failure.Overheating) != 0)
            p.Overheating -= overheating;
        if ((failure & Failure.BadSparkPlug) != 0)
            p.BadSparkPlug -= badSparkPlug;
        if ((failure & Failure.CarbonBuildup) != 0)
            p.CarbonBuildup -= carbonBuildup;
        if ((failure & Failure.Seized) != 0)
            p.Seized -= seized;
    }
}
#endregion