using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{

    public class Bucket
    {
        public object Key { get; private set; }
        public object Value { get; private set; }
        public int HashVal { get; private set; }

        public Bucket(object k, object v, int h)
        {
            this.Key = k;
            this.Value = v;
            this.HashVal = h;
        }
    }
    
    public class BlakeHashTable : IEnumerable<Bucket>
    {

        private Bucket[] _Buckets;
        public int Count { get; set; }
        private int TableSize;

        public BlakeHashTable()
        {
            Count = 0;
            TableSize = 2;
            this._Buckets = new Bucket[TableSize];
        }

        public Object this[Object key] {
            get { return Get(key); }
            set { Add(key, value, true); }
        }

        // MS says O(1) if there is space in the array and O(n) if the array needs to grow
        public void Add(Object key, Object value, bool overwrite = false)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key cannot be null.");
            }

            Bucket b = new Bucket(key, value, key.GetHashCode());

            int bucketLocation = GetBucketLocation(key);

            // expand the table size
            if (Count >= _Buckets.Length)
            {
                ExpandTheBuckets();
            }

            do
            {
                Bucket toCheck = _Buckets[bucketLocation];
                if (toCheck == null)
                {
                    _Buckets[bucketLocation] = b;
                    Count++;
                    return;
                }
                else if (toCheck.HashVal == b.HashVal && toCheck.Key == b.Key)
                {
                    if (overwrite)
                    {
                        _Buckets[bucketLocation] = b;
                        return;
                    }
                    else
                    {
                        throw new ArgumentException("An element with the same key already exists in the HashTable.");
                    }
                }
                else 
                {
                    bucketLocation = (++bucketLocation % _Buckets.Length);
                }
            } while (bucketLocation < _Buckets.Length);
        }

        private Object Get(Object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key cannot be null.");
            }

            int hashVal = key.GetHashCode();
            int bucketLocation = GetBucketLocation(key);

            do
            {
                Bucket toCheck = _Buckets[bucketLocation];
                if (toCheck == null)
                {
                    // skip
                }
                else if (toCheck.HashVal == hashVal && toCheck.Key == key)
                {
                    return toCheck;
                }
                else
                {
                    bucketLocation = (++bucketLocation % _Buckets.Length);
                }
            } while (bucketLocation < _Buckets.Length);
            return null;
        }


        // MS says O(1) but i dont know how...
        public void Remove(Object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key cannot be null.");
            }

            int hashVal = key.GetHashCode();
            int bucketLocation = GetBucketLocation(key);

            do
            {
                Bucket toCheck = _Buckets[bucketLocation];
                if (toCheck == null)
                {
                    // skip
                }
                else if (toCheck.HashVal == hashVal && toCheck.Key == key)
                {
                    _Buckets[bucketLocation] = null;
                    Count--;
                    return;
                }
                else
                {
                    bucketLocation = (++bucketLocation % _Buckets.Length);
                }
            } while (bucketLocation < _Buckets.Length);
        }

        private int GetBucketLocation(object o)
        {
            int keyHash = o.GetHashCode();
            int keyHashNoSign = (keyHash & 0x7FFFFFFF);
            int keyHashLoc = keyHashNoSign % _Buckets.Length;
            return keyHashLoc;
        }

        private void ExpandTheBuckets()
        {
            int newLength = _Buckets.Length * 2;
            Bucket[] newBuckets = new Bucket[newLength];
            for (int i = 0; i < _Buckets.Length;i++)
            {
                Bucket oldBucket = _Buckets[i];
                if (oldBucket != null)
                {
                    int keyHashNoSign = (oldBucket.HashVal & 0x7FFFFFFF);
                    int bucketLocation = keyHashNoSign % newLength;

                    do
                    {
                        Bucket toCheck = newBuckets[bucketLocation];
                        if (toCheck == null)
                        {
                            newBuckets[bucketLocation] = oldBucket;
                            break;
                        }
                        else if (toCheck.HashVal == oldBucket.HashVal && toCheck.Key == oldBucket.Key)
                        {
                            throw new ArgumentException("An element with the same key already exists in the HashTable.");
                        }
                        else
                        {
                            bucketLocation = (++bucketLocation % _Buckets.Length);
                        }
                    } while (bucketLocation < _Buckets.Length);

                }
            }

            _Buckets = newBuckets;
        }


        public IEnumerator<Bucket> GetEnumerator()
        {
            foreach (Bucket b in _Buckets)
            {
                if(b != null)
                {
                    yield return b;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
