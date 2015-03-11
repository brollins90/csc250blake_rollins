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
        private int _atStep = 0;
        public bool IsStillMoving { get; private set; }

        private KMeaner(int numClusters = 4)
        {
            DataSet = new List<Data>();
            Centroids = new List<Data>();
            Samples = new List<Data>();
            NumClusters = numClusters;
            IsStillMoving = true;
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

        public void KMeanCluster()
        {
            double bigNumber = Math.Pow(10, 10); // some big number that's sure to be larger than our data range.
            double minimum = bigNumber;
            int sampleNumber = 0;
            int cluster = 0;
            bool isStillMoving = true;
            int TOTAL_DATA = this.Samples.Count;

            // Add in new data, one at a time recalculating the centroid each time
            while (this.DataSet.Count() < TOTAL_DATA)
            {
                Data newData = new Data(this.Samples[sampleNumber]);
                this.DataSet.Add(newData);
                minimum = bigNumber;
                for (int i = 0; i < this.NumClusters; i++)
                {
                    double totalX = 0;
                    double totalY = 0;
                    double totalInCluster = 0;
                    for (int j = 0; j < this.DataSet.Count(); j++)
                    {
                        if (this.DataSet[j].Cluster == i)
                        {
                            totalX += this.DataSet[j].X;
                            totalY += this.DataSet[j].Y;
                            totalInCluster++;
                        }
                    }
                    if (totalInCluster > 0)
                    {
                        this.Centroids[i].X = (totalX / totalInCluster);
                        this.Centroids[i].Y = (totalY / totalInCluster);
                    }
                }
                sampleNumber++;
            }

            // Now, keep shifting centroids until equilibreum occurs
            while (isStillMoving)
            {
                // calculate the new centroids
                for (int i = 0; i < this.NumClusters; i++)
                {
                    double totalX = 0;
                    double totalY = 0;
                    double totalInCluster = 0;
                    for (int j = 0; j < this.DataSet.Count(); j++)
                    {
                        if (this.DataSet[j].Cluster == i)
                        {
                            totalX += this.DataSet[j].X;
                            totalY += this.DataSet[j].Y;
                            totalInCluster++;
                        }
                    }
                    if (totalInCluster > 0)
                    {
                        this.Centroids[i].X = (totalX / totalInCluster);
                        this.Centroids[i].Y = (totalY / totalInCluster);
                    }
                }

                // assign all data to the new centroids
                isStillMoving = false;

                for (int i = 0; i < this.DataSet.Count(); i++)
                {
                    Data tempdata = this.DataSet[i];
                    minimum = bigNumber;
                    for (int j = 0; j < this.NumClusters; j++)
                    {
                        double distance = FindDistance(tempdata, this.Centroids[j]);
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


        public void StepOnce()
        {
            //
            //
            //int cluster = 0;
            //bool isStillMoving = true;
            //int TOTAL_DATA = this.Samples.Count;

            if (_atStep < 1)
            {
                const double bigNumber = double.MaxValue;
                double minimum = bigNumber;
                int sampleNumber = 0;
                // Add in new data, one at a time recalculating the centroid each time
                while (this.DataSet.Count() < this.Samples.Count)
                {
                    Data newData = new Data(this.Samples[sampleNumber]);
                    this.DataSet.Add(newData);
                    minimum = bigNumber;
                    for (int i = 0; i < this.NumClusters; i++)
                    {
                        double totalX = 0;
                        double totalY = 0;
                        double totalInCluster = 0;
                        for (int j = 0; j < this.DataSet.Count(); j++)
                        {
                            if (this.DataSet[j].Cluster == i)
                            {
                                totalX += this.DataSet[j].X;
                                totalY += this.DataSet[j].Y;
                                totalInCluster++;
                            }
                        }
                        if (totalInCluster > 0)
                        {
                            this.Centroids[i].X = (totalX/totalInCluster);
                            this.Centroids[i].Y = (totalY/totalInCluster);
                        }
                    }
                    sampleNumber++;
                }
            }
            else // not step 1
            {
                const double bigNumber = double.MaxValue;
                double minimum = bigNumber;
                int cluster = 0;
                // Now, keep shifting centroids until equilibreum occurs
                if (IsStillMoving)
                {
                    // calculate the new centroids
                    for (int i = 0; i < this.NumClusters; i++)
                    {
                        double totalX = 0;
                        double totalY = 0;
                        double totalInCluster = 0;
                        for (int j = 0; j < this.DataSet.Count(); j++)
                        {
                            if (this.DataSet[j].Cluster == i)
                            {
                                totalX += this.DataSet[j].X;
                                totalY += this.DataSet[j].Y;
                                totalInCluster++;
                            }
                        }
                        if (totalInCluster > 0)
                        {
                            this.Centroids[i].X = (totalX / totalInCluster);
                            this.Centroids[i].Y = (totalY / totalInCluster);
                        }
                    }

                    // assign all data to the new centroids
                    IsStillMoving = false;

                    for (int i = 0; i < this.DataSet.Count(); i++)
                    {
                        Data tempdata = this.DataSet[i];
                        minimum = bigNumber;
                        for (int j = 0; j < this.NumClusters; j++)
                        {
                            double distance = FindDistance(tempdata, this.Centroids[j]);
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
                            IsStillMoving = true;
                        }
                    }
                }
            }

            _atStep++;
        }


        private static double FindDistance(Data data, Data centroid)
        {
            return Math.Sqrt(Math.Pow((centroid.Y - data.Y), 2) + Math.Pow((centroid.X - data.X), 2));
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


    
}
