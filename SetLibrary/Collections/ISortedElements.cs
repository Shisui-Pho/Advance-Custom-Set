using System;
using System.Collections.Generic;
namespace SetLibrary.Collections
{
    public interface ISortedElements<T> : ISortedSetCollection<T>, IEnumerable<T>
    where T : IComparable
    {
        /// <summary>
        /// Removes an element inside the sorted list.
        /// </summary>
        /// <param name="val">The element to be removed</param>
        /// <returns>Bool to indicates if the element was removed or not</returns>
        bool Remove(T val);
        /// <summary>
        /// Checks if a particular element is contained in the curernt collection.
        /// </summary>
        /// <param name="val">The element to be found</param>
        /// <returns></returns>
        bool Contains(T val);
        /// <summary>
        /// Returns the index of a current element in the set
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        int IndexOf(T val);
        /// <summary>
        /// Adds an element in the collection in a sorted order.
        /// </summary>
        /// <param name="value">Value to be added of type <typeparamref name="T"/></param>
        void Add(T value);
        /// <summary>
        /// Adds a range of elements in the collection in a sorted order.
        /// </summary>
        /// <param name="coll">The elements to be added.</param>
        void AddRange(IEnumerable<T> coll);
    }//ISortedElements
}//namespace
