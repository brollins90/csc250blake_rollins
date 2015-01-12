using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingLists
{
	public interface IAlgoList<T> : IEnumerable<T>
	{
		/// <summary>
		/// Gets or sets the element at the specified index
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set</param>
		/// <returns>The element at the specified index</returns>
		T this[int index] { get; set; }
		/// <summary>
		/// Gets the number of elements contained in the collection
		/// </summary>
		int Count { get; }
		/// <summary>
		/// Adds an item to the collection
		/// </summary>
		/// <param name="item">The object to added</param>
		void Add(T item);

		void Insert(int index, T item);
		/// <summary>
		/// Removes all items from the collection
		/// </summary>
		void Clear();
		/// <summary>
		/// Removes the first occurrence of the specified object from the collection
		/// </summary>
		/// <param name="item">item to be removed from collection</param>
		/// <returns>true if item was successfuly removed</returns>
		bool Remove(T item);
		/// <summary>
		/// Removes the item at the specified index
		/// </summary>
		/// <param name="index">The zero-based index of the item to remove</param>
		void RemoveAt(int index);
	}
}
