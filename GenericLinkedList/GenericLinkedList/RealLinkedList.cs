//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CSC160_GenericLinkedList
//{
//    public class RealLinkedList<T> : ILinkedList<T> where T : IComparable<T>
//    {
//        private System.Collections.Generic.LinkedList<T> _List;

//        public RealLinkedList()
//        {
//            _List = new System.Collections.Generic.LinkedList<T>();
//        }

//        public int Count
//        {
//            get { return _List.Count; }
//        }

//        public LinkedListNode<T> First
//        {
//            get { return _List.First; }
//        }

//        public LinkedListNode<T> Last
//        {
//            get { return _List.Last; }
//        }

//        public void AddAfter(System.coLinkedListNode<T> node, LinkedListNode<T> newNode)
//        {
//            _List.AddAfter(node, newNode);
//        }

//        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
//        {
//            throw new NotImplementedException();
//        }

//        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
//        {
//            throw new NotImplementedException();
//        }

//        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
//        {
//            throw new NotImplementedException();
//        }

//        public void AddFirst(LinkedListNode<T> node)
//        {
//            throw new NotImplementedException();
//        }

//        public LinkedListNode<T> AddFirst(T value)
//        {
//            throw new NotImplementedException();
//        }

//        public void AddLast(LinkedListNode<T> node)
//        {
//            throw new NotImplementedException();
//        }

//        public LinkedListNode<T> AddLast(T value)
//        {
//            throw new NotImplementedException();
//        }

//        public void Clear()
//        {
//            throw new NotImplementedException();
//        }

//        public bool Contains(T value)
//        {
//            throw new NotImplementedException();
//        }

//        public void CopyTo(T[] array, int index)
//        {
//            throw new NotImplementedException();
//        }

//        public LinkedListNode<T> Find(T value)
//        {
//            throw new NotImplementedException();
//        }

//        public LinkedListNode<T> FindLast(T value)
//        {
//            throw new NotImplementedException();
//        }

//        public void Remove(LinkedListNode<T> node)
//        {
//            throw new NotImplementedException();
//        }

//        public bool Remove(T value)
//        {
//            throw new NotImplementedException();
//        }

//        public void RemoveFirst()
//        {
//            throw new NotImplementedException();
//        }

//        public void RemoveLast()
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerator<T> GetEnumerator()
//        {
//            throw new NotImplementedException();
//        }

//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
