using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{

    public class KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
    
    public class BlakeHashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {

        private class Bucket<TKey, TValue>
        {
            public TKey Key { get; private set; }
            public TValue Value { get; private set; }
            public int HashVal { get; private set; }

            public Bucket(TKey k, TValue v, int h)
            {
                this.Key = k;
                this.Value = v;
                this.HashVal = h;
            }
        }

        private Bucket<TKey,TValue>[] _Buckets;
        public int Count { get; set; }
        private int TableSize;

        public BlakeHashTable()
        {
            Count = 0;
            TableSize = 2;
            this._Buckets = new Bucket<TKey,TValue>[TableSize];
        }

        public TValue this[TKey key] {
            get { return Get(key); }
            set { Add(key, value, true); }
        }

        // MS says O(1) if there is space in the array and O(n) if the array needs to grow
        public void Add(TKey key, TValue value, bool overwrite = false)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key cannot be null.");
            }

            // expand the table size
            if (Count >= _Buckets.Length)
            {
                ExpandTheBuckets();
            }

            Bucket<TKey, TValue> b = new Bucket<TKey, TValue>(key, value, key.GetHashCode());

            int bucketLocation = GetBucketLocation(key);

            do
            {
                Bucket<TKey, TValue> toCheck = _Buckets[bucketLocation];
                if (toCheck == null)
                {
                    _Buckets[bucketLocation] = b;
                    Count++;
                    return;
                }
                else if (toCheck.HashVal.Equals(b.HashVal) && toCheck.Key.Equals(b.Key))
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

        private TValue Get(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key cannot be null.");
            }

            int hashVal = key.GetHashCode();
            int bucketLocation = GetBucketLocation(key);

            do
            {
                Bucket<TKey, TValue> toCheck = _Buckets[bucketLocation];
                if (toCheck == null)
                {
                    // skip
                }
                else if (toCheck.HashVal.Equals(hashVal) && toCheck.Key.Equals(key))
                {
                    return toCheck.Value;
                }
                else
                {
                    bucketLocation = (++bucketLocation % _Buckets.Length);
                }
            } while (bucketLocation < _Buckets.Length);
            return default(TValue);
        }


        // MS says O(1) but i dont know how...
        public void Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key cannot be null.");
            }

            int hashVal = key.GetHashCode();
            int bucketLocation = GetBucketLocation(key);

            do
            {
                Bucket<TKey, TValue> toCheck = _Buckets[bucketLocation];
                if (toCheck == null)
                {
                    // skip
                }
                else if (toCheck.HashVal.Equals(hashVal) && toCheck.Key.Equals(key))
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
            Bucket<TKey, TValue>[] newBuckets = new Bucket<TKey, TValue>[newLength];
            for (int i = 0; i < _Buckets.Length;i++)
            {
                Bucket<TKey, TValue> oldBucket = _Buckets[i];
                if (oldBucket != null)
                {
                    int keyHashNoSign = (oldBucket.HashVal & 0x7FFFFFFF);
                    int bucketLocation = keyHashNoSign % newLength;

                    do
                    {
                        Bucket<TKey, TValue> toCheck = newBuckets[bucketLocation];
                        if (toCheck == null)
                        {
                            newBuckets[bucketLocation] = oldBucket;
                            break;
                        }
                        else if (toCheck.HashVal.Equals(oldBucket.HashVal) && toCheck.Key.Equals(oldBucket.Key))
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


        public IEnumerator<KeyValuePair<TKey,TValue>> GetEnumerator()
        {
            foreach (Bucket<TKey, TValue> b in _Buckets)
            {
                if(b != null)
                {
                    yield return new KeyValuePair<TKey, TValue>() { Key = b.Key, Value = b.Value };
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
