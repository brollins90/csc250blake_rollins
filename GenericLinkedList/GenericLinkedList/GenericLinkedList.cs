using System;
using System.Text;

namespace CSC160_GenericLinkedList
{
    public class GenericLinkedList<T> : ILinkedList<T>
    {

        public LinkedListNode<T> First { get; private set; }

        public LinkedListNode<T> Last { get; private set; }

        public int Count { get; set; }

        private void AddOnly(LinkedListNode<T> node)
        {
            if (First == null && Last == null && Count == 0)
            {
                First = node;
                Last = node;
                node.Previous = null;
                node.Next = null;
                node.List = this;
                Count++;
            }
            else
            {
                throw new InvalidOperationException("Can not add this as the only node when other nodes exist");
            }
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            if (node.List != this)
            {
                throw new Exception("The node does not belong to this list");
            }
            
            if (newNode == null)
            {
                throw new ArgumentNullException("newNode");
            }

            newNode.Next = node.Next;
            newNode.Previous = node;

            // was last node
            if (node.Next == null)
            {
                Last = newNode;
            }
            else
            {
                node.Next.Previous = newNode;
            }

            node.Next = newNode;
            newNode.List = this;
            Count++;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            AddAfter(node, newNode);
            return newNode;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            if (node.List != this)
            {
                throw new Exception("The node does not belong to this list");
            }

            if (newNode == null)
            {
                throw new ArgumentNullException("newNode");
            }

            newNode.Previous = null;
            newNode.Next = node;

            // was first node
            if (node.Previous == null)
            {
                First = newNode;
            }
            else
            {
                node.Previous.Next = newNode;
            }
            newNode.Previous = node.Previous;
            node.Previous = newNode;
            newNode.List = this;
            Count++;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            AddBefore(node, newNode);
            return newNode;
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            if (First == null)
            {
                AddOnly(node);
            }
            else
            {
                node.Next = First;
                First.Previous = node;
                First = node;
                node.Previous = null;
                node.List = this;
                Count++;
            }
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            AddFirst(newNode);
            return newNode;
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Last == null)
            {
                AddOnly(node);
            }
            else
            {
                node.Previous = Last;
                Last.Next = node;
                Last = node;
                Last.Next = null;
                node.List = this;
                Count++;
            }
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            AddLast(newNode);
            return newNode;
        }

        public void Clear()
        {
            LinkedListNode<T> current = First;
            while (current != null)
            {
                LinkedListNode<T> next = current.Next;

                current.Value = default(T);
                current.List = null;
                current.Previous = null;
                current.Next = null;
                current = next;
            }
            First = null;
            Last = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            return (Find(value) != null);
        }

        public void CopyTo(T[] array, int index)
        {
            if (Count + index > array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            int i = 0;
            foreach (T t in this)
            {
                array[index + i++] = t;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> current = First;
            if (current == null)
            {
                return null;
            }

            while (current != null)
            {
                if (current.Value == null)
                {
                    if (value == null)
                    {
                        return current;
                    }
                }
                else if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public LinkedListNode<T> FindLast(T value)
        {
            LinkedListNode<T> current = Last;
            if (current == null)
            {
                return null;
            }

            while (current != null)
            {
                if (current.Value == null)
                {
                    if (value == null)
                    {
                        return current;
                    }
                }
                else if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Previous;
            }
            return null;
        }

        public void Remove(LinkedListNode<T> node)
        {
            if (node != null)
            {
                // first node
                if (node.Previous == null)
                {
                    First = node.Next;
                    // This was the only node
                    if (First == null)
                    {
                        Clear();
                        return;
                    }
                    First.Previous = null;
                }
                else
                {
                    node.Previous.Next = node.Next;
                }

                // last node
                if (node.Next == null)
                {
                    Last = node.Previous;
                    Last.Next = null;
                }
                else
                {
                    node.Next.Previous = node.Previous;
                }
                node.Next = null;
                node.Previous = null;
                node.List = null;
                Count--;
            }
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> toRemove = Find(value);
            if (toRemove != null)
            {
                Remove(toRemove);
                return true;
            }
            return false;
        }

        public void RemoveFirst()
        {
            Remove(First);
        }

        void ILinkedList<T>.RemoveLast()
        {
            Remove(Last);
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> cur = First;
            while (cur != null)
            {
                T retVal = cur.Value;
                cur = cur.Next;
                yield return retVal;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return string.Format("Count = {0}", Count);
        }
    }
}
