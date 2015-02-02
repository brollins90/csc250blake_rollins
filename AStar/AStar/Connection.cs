using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    public class Connection
    {
        public Node ToNode { get; set; }
        public double Weight { get; set; }

        public string Name { get; set; }

        public Connection(Node to, Node from)
        {
            this.ToNode = to;
            this.Weight = from.DistanceTo(to);
            this.Name = from.Name + " -> " + to.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
