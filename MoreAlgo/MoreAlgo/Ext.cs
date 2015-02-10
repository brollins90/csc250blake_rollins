using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreAlgo
{
    public static class Ext
    {
        public static string CSVCollection<T>(this IEnumerable<T> col)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var t in col)
            {
                sb.Append(t.ToString());
                sb.Append(",");
            }

            string retval = sb.ToString();
            return retval.Trim().Substring(0, retval.Length - 1);
        }

        //public static IEnumerable<int> CopyAndRemove(this IEnumerable<int> list, int index)
        //{
        //    IEnumerable<int> ret = list.Where(x => x).r
        //}
    }
}
