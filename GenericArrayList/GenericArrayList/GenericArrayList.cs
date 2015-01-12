using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MakingLists
{
    /// <summary>
    /// My implementation of the IAlgoList interface
    /// Blake Rollins
    /// 2015-01-06
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GenericArrayList<T> : IAlgoList<T> where T : IComparable<T>
    {
        private T[] _array;
        private int _count;
        private int _capacity;
        private int _defaultSize;

        public GenericArrayList()
        {
            this._defaultSize = 10;
            this.Clear();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }

                _array[index] = value;
            }
        }

        public int Count
        {
            get { return this._count; }
        }

        public void Add(T item)
        {
            if (_count >= _capacity)
            {
                doubleTheBackingArray();
            }
            _array[_count++] = item;
        }

        public void Clear()
        {
            this._count = 0;
            this._capacity = this._defaultSize;
            _array = new T[this._capacity];
        }

        public bool Remove(T item)
        {
            int indexOfItem = -1;

            for (int i = 0; i < _count && indexOfItem == -1; i++)
            {
                if (_array[i].Equals(item))
                {
                    indexOfItem = i;
                }
            }

            if (indexOfItem != -1)
            {
                RemoveAt(indexOfItem);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < _count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _count--;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
            {
                throw new IndexOutOfRangeException();
            }

            if (_count >= _capacity)
            {
                doubleTheBackingArray();
            }

            for (int i = _count; i > index && i > 0; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[index] = item;
            _count++;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count;i++)
            {
                yield return _array[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void doubleTheBackingArray()
        {
            T[] newArray = new T[_capacity * 2];

            for (int i = 0; i < _capacity; i++)
            {
                newArray[i] = _array[i];
            }

            _capacity *= 2;
            _array = newArray;
        }

        public int Find(T value)
        {
            return BinarySearch(value, 0, Count - 1);
        }

        protected int BinarySearch(T value, int bottom, int top)
        {
            int difference = (top - bottom) / 2;
            int indexToCheck = difference + bottom;
            //Console.Write("looking for {0} between {1} and {2} ", value, bottom, top);

            T testValue = _array[indexToCheck];
            int compareValue = value.CompareTo(testValue);
            //Console.WriteLine("found {0} diff {1} index {2} comp {3}", testValue, difference, indexToCheck, compareValue);

            if (compareValue == 0)
            {
                //Console.WriteLine("Found at " + half);
                return indexToCheck;
            }
            else
            {
                if (top == bottom)
                {
                    return -1;
                }

                if (compareValue < 0)
                {
                    //Console.WriteLine("less than " + half);

                    if (difference == 0)
                    {
                        indexToCheck = bottom;
                    }
                    return BinarySearch(value, bottom, indexToCheck);
                }
                else // compareValue > 0
                {
                    //Console.WriteLine("greater than " + half);

                    if (difference == 0)
                    {
                        indexToCheck = top;
                    }
                    return BinarySearch(value, indexToCheck, top);
                }
            }

            if (difference <= 0)
            {

                return -1;
            }
        }
    }
}
