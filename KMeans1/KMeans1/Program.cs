using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans1
{
    class Program
    {
        private static readonly int NUM_CLUSTERS = 2;
        private static readonly int TOTAL_DATA = 7;

        private static readonly double[,] SAMPLES =

        new double[,]
        {
            {
                1.0,
                1.0
            },{
                1.5,
                2.0
            },{
                3.0,
                4.0
            },{
                5.0,
                7.0
            },{
                3.5,
                5.0
            },{
                4.5,
                5.0
            },{
                3.5,
                4.5
            }
        };

        private static List<Data> dataSet = new List<Data>();
        private static List<Centroid> centroids = new List<Centroid>();

        private static void Initialize()
        {
            Console.WriteLine("Centroids initialized at:");
            centroids.Add(new Centroid(1.0, 1.0)); // lowest set
            centroids.Add(new Centroid(5.0, 7.0)); // highest set
            Console.WriteLine("     (" + centroids[0].X + ", " + centroids[0].Y + ")");
            Console.WriteLine("     (" + centroids[1].X + ", " + centroids[1].Y + ")");
            Console.WriteLine();
        }

        private static void KMeanCluster()
        {
            double bigNumber = Math.Pow(10, 10);        // some big number that's sure to be larger than our data range.
            double minimum = bigNumber;
            double distance = 0;
            int sampleNumber = 0;
            int cluster = 0;
            bool isStillMoving = true;
            Data newData = null;

            // Add in new data, one at a time recalculating the centroid each time
            while (dataSet.Count() < TOTAL_DATA)
            {
                newData = new Data(SAMPLES[sampleNumber, 0], SAMPLES[sampleNumber, 1]);
                dataSet.Add(newData);
                minimum = bigNumber;
                for (int i = 0; i < NUM_CLUSTERS; i++)
                {
                    double totalX = 0;
                    double totalY = 0;
                    double totalInCluster = 0;
                    for (int j = 0; j < dataSet.Count(); j++)
                    {
                        if (dataSet[j].Cluster == i)
                        {
                            totalX += dataSet[j].X;
                            totalY += dataSet[j].Y;
                            totalInCluster++;
                        }
                    }
                    if (totalInCluster > 0)
                    {
                        centroids[i].X = (totalX / totalInCluster);
                        centroids[i].Y = (totalY / totalInCluster);
                    }
                }
                sampleNumber++;
            }

            // Now, keep shifting centroids until equilibreum occurs
            while (isStillMoving)
            {
                // calculate the new centroids
                for (int i = 0; i < NUM_CLUSTERS; i++)
                {
                    double totalX = 0;
                    double totalY = 0;
                    double totalInCluster = 0;
                    for (int j = 0; j < dataSet.Count(); j++)
                    {
                        if (dataSet[j].Cluster == i)
                        {
                            totalX += dataSet[j].X;
                            totalY += dataSet[j].Y;
                            totalInCluster++;
                        }
                    }
                    if (totalInCluster > 0)
                    {
                        centroids[i].X = (totalX / totalInCluster);
                        centroids[i].Y = (totalY / totalInCluster);
                    }
                }

                // assign all data to the new centroids
                isStillMoving = false;

                for (int i = 0; i < dataSet.Count(); i++)
                {
                    Data tempdata = dataSet[i];
                    minimum = bigNumber;
                    for (int j = 0; j < NUM_CLUSTERS; j++)
                    {
                        distance = dist(tempdata, centroids[j]);
                        if (distance < minimum)
                        {
                            minimum = distance;
                            cluster = j;
                        }
                    }
                    //tempdata.Cluster = cluster;
                    if (tempdata.Cluster != cluster)
                    {
                        tempdata.Cluster = cluster;
                        isStillMoving = true;
                    }
                }
            }
            return;
        }

        private static double dist(Data d, Centroid c)
        {
            return Math.Sqrt(Math.Pow((c.Y - d.Y), 2) + Math.Pow((c.X - d.X), 2));
        }

        private class Data
        {
            public double X { get; set; }
            public double Y { get; set; }
            public int Cluster { get; set; }

            public Data()
            {
                X = 0;
                Y = 0;
            }

            public Data(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        private class Centroid
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Centroid()
            {
                X = 0;
                Y = 0;
            }

            public Centroid(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        static void Main(string[] args)
        {
            Initialize();
            KMeanCluster();

            // print
            for (int i = 0; i < NUM_CLUSTERS; i++)
            {
                Console.WriteLine("Cluster " + i + " includes:");
                for (int j = 0; j < TOTAL_DATA; j++)
                {
                    if (dataSet[j].Cluster == i)
                    {
                        Console.WriteLine("     (" + dataSet[j].X + ", " + dataSet[j].Y + ")");
                    }
                } // j
                Console.WriteLine();
            } // i

            // print centroids
            Console.WriteLine("Centroids finalized at:");
            for (int i = 0; i < NUM_CLUSTERS; i++)
            {
                Console.WriteLine("     (" + centroids[i].X + ", " + centroids[i].Y + ")");
            }
            Console.WriteLine();
        }

    }
}
