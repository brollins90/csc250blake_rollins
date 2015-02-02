using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AStar
{
    public class Node
    {
        public Point Location { get; set; }
        public List<Connection> Connections { get; set; }

        public double CSF { get; set; }
        public double H { get; set; }
        public double TEC { get; set; }
        public Node CF { get; set; }


        public string Name { get; set; }

        public Node(string name)
        {
            this.Name = name;
            this.Connections = new List<Connection>();
        }

        public void AddConnection(Node n)
        {
            this.Connections.Add(new Connection(n, this));
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return this.Name.Equals((obj as Node).Name);
        }
    }
}
