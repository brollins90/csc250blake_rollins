//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MakingLists
//{
//    public class AlgoLister<T> : IAlgoList<T>
//    {
//        private readonly List<T> _back = new List<T>();

//        public AlgoLister()
//        {
//            throw new NotImplementedException();
//        }
//        public AlgoLister(IEnumerable<T> input)
//        {
//            foreach (var i in input)
//            {
//                Add(i);
//            }
//            throw new NotImplementedException();
//        }

//        public IEnumerator<T> GetEnumerator()
//        {
//            return _back.GetEnumerator();
//            throw new NotImplementedException();
//        }
//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }
//        public T this[int index]
//        {
//            get { return _back[index]; }
//            set { _back[index] = value; }
//        }
//        public int Count { get { return _back.Count; } }
//        public void Add(T item)
//        {
//            _back.Add(item);
//            throw new NotImplementedException();
//        }
//        public void Clear()
//        {
//            _back.Clear();
//            throw new NotImplementedException();
//        }
//        public bool Remove(T item)
//        {
//            return _back.Remove(item);
//            throw new NotImplementedException();
//        }
//        public void RemoveAt(int index)
//        {
//            _back.RemoveAt(index);
//            throw new NotImplementedException();
//        }

//        public void Insert(int index, T item)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
