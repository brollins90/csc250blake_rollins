using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeansLib
{

    public class KMeaner
    {
        private static readonly Random Random = new Random();
        public List<Data> DataSet { get; set; }
        public List<Data> Centroids { get; set; }
        public List<Data> Samples { get; set; }
        public int NumClusters { get; set; }

        public KMeaner(int numClusters = 4)
        {
            DataSet = new List<Data>();
            Centroids = new List<Data>();
            Samples = new List<Data>();
            NumClusters = numClusters;
        }

        public static KMeaner RandomKMeaner(int numClusters, int numSamples, int xmin = -20, int xmax = 20, int ymin = -20, int ymax = 20)
        {
            KMeaner retVal = new KMeaner(numClusters);

            for (int i = 0; i < numSamples; i++)
            {
                retVal.Samples.Add(new Data(Random.Next(xmin, xmax), Random.Next(ymin, ymax)));
            }

            if (retVal.Samples.Count < numClusters - 1)
            {
                throw new Exception();
            }
            for (int i = 0; i < numClusters; i++)
            {
                retVal.Centroids.Add(retVal.Samples[i]);
                //centroids.Add(new Centroid(1.0, 1.0)); // lowest set
                //centroids.Add(new Centroid(5.0, 7.0)); // highest set
            }

            return retVal;
        }

        public void Print()
        {

            // print
            for (int i = 0; i < this.NumClusters; i++)
            {
                Console.WriteLine("Cluster " + i + " includes:");
                for (int j = 0; j < this.DataSet.Count; j++)
                {
                    if (this.DataSet[j].Cluster == i)
                    {
                        Console.WriteLine("     (" + this.DataSet[j].X + ", " + this.DataSet[j].Y + ")");
                    }
                } // j
                Console.WriteLine();
            } // i

            // print centroids
            Console.WriteLine("Centroids finalized at:");
            for (int i = 0; i < this.NumClusters; i++)
            {
                Console.WriteLine("     (" + this.Centroids[i].X + ", " + this.Centroids[i].Y + ")");
            }
            Console.WriteLine();
        }
    }

    public class Data
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

        public Data(Data d)
        {
            X = d.X;
            Y = d.Y;
        }
    }

    public static class KMeansProcess
    {
        public static void KMeanCluster(KMeaner meaner)
        {
            double bigNumber = Math.Pow(10, 10); // some big number that's sure to be larger than our data range.
            double minimum = bigNumber;
            int sampleNumber = 0;
            int cluster = 0;
            bool isStillMoving = true;
            int TOTAL_DATA = meaner.Samples.Count;

            // Add in new data, one at a time recalculating the centroid each time
            while (meaner.DataSet.Count() < TOTAL_DATA)
            {
                Data newData = new Data(meaner.Samples[sampleNumber]);
                meaner.DataSet.Add(newData);
                minimum = bigNumber;
                for (int i = 0; i < meaner.NumClusters; i++)
                {
                    double totalX = 0;
                    double totalY = 0;
                    double totalInCluster = 0;
                    for (int j = 0; j < meaner.DataSet.Count(); j++)
                    {
                        if (meaner.DataSet[j].Cluster == i)
                        {
                            totalX += meaner.DataSet[j].X;
                            totalY += meaner.DataSet[j].Y;
                            totalInCluster++;
                        }
                    }
                    if (totalInCluster > 0)
                    {
                        meaner.Centroids[i].X = (totalX/totalInCluster);
                        meaner.Centroids[i].Y = (totalY / totalInCluster);
                    }
                }
                sampleNumber++;
            }

            // Now, keep shifting centroids until equilibreum occurs
            while (isStillMoving)
            {
                // calculate the new centroids
                for (int i = 0; i < meaner.NumClusters; i++)
                {
                    double totalX = 0;
                    double totalY = 0;
                    double totalInCluster = 0;
                    for (int j = 0; j < meaner.DataSet.Count(); j++)
                    {
                        if (meaner.DataSet[j].Cluster == i)
                        {
                            totalX += meaner.DataSet[j].X;
                            totalY += meaner.DataSet[j].Y;
                            totalInCluster++;
                        }
                    }
                    if (totalInCluster > 0)
                    {
                        meaner.Centroids[i].X = (totalX / totalInCluster);
                        meaner.Centroids[i].Y = (totalY / totalInCluster);
                    }
                }

                // assign all data to the new centroids
                isStillMoving = false;

                for (int i = 0; i < meaner.DataSet.Count(); i++)
                {
                    Data tempdata = meaner.DataSet[i];
                    minimum = bigNumber;
                    for (int j = 0; j < meaner.NumClusters; j++)
                    {
                        double distance = FindDistance(tempdata, meaner.Centroids[j]);
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

        private static double FindDistance(Data data, Data centroid)
        {
            return Math.Sqrt(Math.Pow((centroid.Y - data.Y), 2) + Math.Pow((centroid.X - data.X), 2));
        }
    }
}
