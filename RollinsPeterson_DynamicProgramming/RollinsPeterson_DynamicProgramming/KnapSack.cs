using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollinsPeterson_DynamicProgramming
{
    class KnapSack
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        private int MaxWeight;

        public KnapSack(int max)
        {
            MaxWeight = max;
        }

        public void Add(Item item, bool recurse = true)
        {
            if(item.Weight <= MaxWeight)
            {
                if(recurse)
                {
                    Dictionary<int, int> dict = new Dictionary<int, int>(dictionary);
                    foreach (var itemInPack in dict)
                    {
                        Add(new Item(itemInPack.Value + item.Value, itemInPack.Key + item.Weight), false);
                    }
                }
                if (dictionary.ContainsKey(item.Weight))
                {
                    int temp = dictionary[item.Weight];
                    if (item.Value > temp)
                    {
                        dictionary[item.Weight] = item.Value;
                    }
                }
                else
                {
                    dictionary[item.Weight] = item.Value;
                }
            }
        }

        public int GetMaxValue()
        {
            if(dictionary.Any())
            {
                return dictionary.Max(x => x.Value);
            }
            else
            {
                return -1;
            }
        }
    }
}
