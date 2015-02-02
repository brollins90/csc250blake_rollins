using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
        public static class PointFunctions
        {
            public static double DistanceTo(this Node n1, Node n2)
            {
                var a = (double)(n2.Location.X - n1.Location.X);
                var b = (double)(n2.Location.Y - n1.Location.Y);

                return Math.Sqrt(a * a + b * b);
            }
        }
    }
