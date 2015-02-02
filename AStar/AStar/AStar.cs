using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    public static class AStar
    {
        
        public static string Process(Node start, Node finish)
        {
            //Console.WriteLine("Finding path from {0} to {1}", start.Name, finish.Name);

            List<Node> OpenList = new List<Node>();
            List<Node> ClosedList = new List<Node>();

            start.CSF = 1;
            start.H = start.DistanceTo(finish);
            start.TEC = start.CSF + start.H;

            OpenList.Add(start);

            while (OpenList.Count > 0)
            {
                Node Current = OpenList.Aggregate((curmin, x) => (curmin == null || (x.TEC) < curmin.TEC ? x : curmin));
                OpenList.Remove(Current);

                if (Current.Equals(finish))
                {
                    string path = GetPath(Current);
                    return path;
                    //Console.WriteLine(path);
                    //break;
                }

                foreach (Connection c in Current.Connections)
                {
                    //if (OpenList.Contains(c.ToNode))
                    //{
                    //    Node n = OpenList.Find(x => x == c.ToNode);

                    //}
                    Node addNode = c.ToNode;
                    if (OpenList.Contains(addNode))
                    {
                        if (Current.CSF + c.Weight < addNode.CSF ||
                            Current.TEC + addNode.H < addNode.TEC)
                        {
                            addNode.CSF = Current.CSF + c.Weight;
                            addNode.CF = Current;
                            addNode.H = addNode.DistanceTo(finish);
                            addNode.TEC = addNode.CSF + addNode.H;
                        }
                    }
                    else if (ClosedList.Contains(addNode))
                    {
                        if (Current.CSF + c.Weight < addNode.CSF ||
                            Current.TEC + addNode.H < addNode.TEC)
                        {
                            addNode.CSF = Current.CSF + c.Weight;
                            addNode.CF = Current;
                            addNode.H = addNode.DistanceTo(finish);
                            addNode.TEC = addNode.CSF + addNode.H;
                        }
                    }
                    else
                    {
                        addNode.CSF = Current.CSF + c.Weight;
                        addNode.CF = Current;
                        addNode.H = addNode.DistanceTo(finish);
                        addNode.TEC = addNode.CSF + addNode.H;

                        OpenList.Add(c.ToNode);

                    }




                }
                ClosedList.Add(Current);
            }
            return null;
        }

        public static string GetPath(Node a)
        {
            Stack<string> path = new Stack<string>();
            do
            {
                path.Push(a.Name);
                //Console.Write(a.Name + " - ");
                a = a.CF;
            }
            while (a != null) ;

            string retVal = "";
            foreach (string name in path)
            {
                retVal += name + ",";
            }
            return retVal.Substring(0, retVal.Length - 1);
        }
    }
}
