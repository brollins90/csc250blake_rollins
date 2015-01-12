using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC160_GenericLinkedList
{
    public interface ILinkedList<T> : IEnumerable<T>
    {
        int Count { get; }
        LinkedListNode<T> First { get; }
        LinkedListNode<T> Last { get; }
        void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode);
        LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value);
        void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode);
        LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value);
        void AddFirst(LinkedListNode<T> node);
        LinkedListNode<T> AddFirst(T value);
        void AddLast(LinkedListNode<T> node);
        LinkedListNode<T> AddLast(T value);
        void Clear();
        bool Contains(T value);
        void CopyTo(T[] array, int index);
        LinkedListNode<T> Find(T value);
        LinkedListNode<T> FindLast(T value);
        void Remove(LinkedListNode<T> node);
        bool Remove(T value);
        void RemoveFirst();
        void RemoveLast();
    }
}
