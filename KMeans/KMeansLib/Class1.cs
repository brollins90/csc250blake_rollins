using System;
using System.Collections.Generic;
using System.Linq;

namespace KMeansLib
{

    public class KMeaner
    {
        private static readonly Random Random = new Random();
        public List<Data> DataSet { get; set; }
        public List<Data> Centroids { get; set; }
        public List<Data> Samples { get; set; }

        public bool IsStillMoving { get; private set; }
        public int MaxSteps { get; set; }
        public int NumClusters { get; set; }
        public int StepNumber { get; private set; }

        private const double BIG_NUMBER = double.MaxValue;

        private KMeaner(List<Data> sampleData, int numClusters = 4, int maxSteps = 50)
        {
            DataSet = new List<Data>();
            Centroids = new List<Data>();
            Samples = sampleData;
            MaxSteps = maxSteps;
            NumClusters = numClusters;
            StepNumber = 0;
            IsStillMoving = true;

            if (Samples.Count < NumClusters - 1)
            {
                throw new Exception();
            }
            for (int i = 0; i < NumClusters; i++)
            {
                Centroids.Add(new Data(Samples[i]) {Cluster = i});
            }
        }

        public static KMeaner RandomKMeaner(int numSamples, int numClusters = 4, int maxSteps = 50, int xmin = 0, int xmax = 40, int ymin = 0, int ymax = 40)
        {
            List<Data> samples = new List<Data>();
            for (int i = 0; i < numSamples; i++)
            {
                samples.Add(new Data(Random.Next(xmin, xmax), Random.Next(ymin, ymax)));
            }

            KMeaner retVal = new KMeaner(samples, numClusters, maxSteps);

            return retVal;
        }

        public void Print()
        {

            for (int i = 0; i < NumClusters; i++)
            {
                Console.WriteLine("Cluster " + i + " includes:");
                foreach (Data dataPoint in DataSet) {
                    if (dataPoint.Cluster == i)
                    {
                        Console.WriteLine("     (" + dataPoint.X + ", " + dataPoint.Y + ")");
                    }
                }
                Console.WriteLine();
            }

            // print centroids
            Console.WriteLine("Centroids at:");
            for (int i = 0; i < NumClusters; i++)
            {
                Console.WriteLine("     (" + Centroids[i].X + ", " + Centroids[i].Y + ")");
            }
            Console.WriteLine();
        }

        public void KMeanCluster()
        {
            while (IsStillMoving)
            {
                StepOnce();
            }
        }


        public void StepOnce()
        {

            if (StepNumber < 1)
            {
                int sampleNumber = 0;
                // Add in new data, one at a time recalculating the centroid each time
                while (DataSet.Count() < Samples.Count)
                {
                    Data newData = new Data(Samples[sampleNumber]);
                    DataSet.Add(newData);
                    for (int i = 0; i < NumClusters; i++)
                    {
                        double totalX = 0;
                        double totalY = 0;
                        double totalInCluster = 0;
                        for (int j = 0; j < DataSet.Count(); j++)
                        {
                            if (DataSet[j].Cluster == i)
                            {
                                totalX += DataSet[j].X;
                                totalY += DataSet[j].Y;
                                totalInCluster++;
                            }
                        }
                        if (totalInCluster > 0)
                        {
                            Centroids[i].X = (totalX/totalInCluster);
                            Centroids[i].Y = (totalY/totalInCluster);
                            Centroids[i].Cluster = i;
                        }
                    }
                    sampleNumber++;
                }
            }
            else // not step 1
            {
                int cluster = 0;
                // Now, keep shifting centroids until equilibreum occurs
                if (IsStillMoving)
                {
                    // calculate the new centroids
                    for (int i = 0; i < NumClusters; i++)
                    {
                        double totalX = 0;
                        double totalY = 0;
                        double totalInCluster = 0;
                        for (int j = 0; j < DataSet.Count(); j++)
                        {
                            if (DataSet[j].Cluster == i)
                            {
                                totalX += DataSet[j].X;
                                totalY += DataSet[j].Y;
                                totalInCluster++;
                            }
                        }
                        if (totalInCluster > 0)
                        {
                            Centroids[i].X = (totalX / totalInCluster);
                            Centroids[i].Y = (totalY / totalInCluster);
                            Centroids[i].Cluster = i;
                        }
                    }

                    // assign all data to the new centroids
                    IsStillMoving = false;

                    for (int i = 0; i < DataSet.Count(); i++)
                    {
                        Data tempdata = DataSet[i];
                        double minimum = BIG_NUMBER;
                        for (int j = 0; j < NumClusters; j++)
                        {
                            double distance = FindDistance(tempdata, Centroids[j]);
                            if (distance < minimum)
                            {
                                minimum = distance;
                                cluster = j;
                            }
                        }
                        if (tempdata.Cluster != cluster)
                        {
                            tempdata.Cluster = cluster;
                            IsStillMoving = true;
                        }
                    }
                }
            }

            StepNumber++;
            if (StepNumber > MaxSteps)
            {
                IsStillMoving = false;
            }
            //Print();
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
