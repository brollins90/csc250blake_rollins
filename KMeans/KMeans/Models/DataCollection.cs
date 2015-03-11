using KMeansLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans.Models
{
    public class DataCollection
    {
        public DataCollection(KMeaner meaner)
        {
            DataPoints = new ObservableCollection<DataPoint>();



            //new DataRandomizer<DataPoint>(DataPoints, numPoints, Math.Min(1, numPoints/100));
        }

        public ObservableCollection<DataPoint> DataPoints { get; set; }
    }
}
