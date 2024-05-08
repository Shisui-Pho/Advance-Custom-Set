using System;
using System.Collections.Generic;
namespace SetLibrary.Collections
{
    public interface ISortedSubSets<T> : ISortedSetCollection<T>, IEnumerable<ISetTree<T>>
        where T : IComparable
    {
        /// <summary>
        /// Removes a tree inside the sorted list.
        /// </summary>
        /// <param name="val">The element to be removed</param>
        /// <returns>Bool to indicates if the element was removed or not</returns>
        bool Remove(ISetTree<T> val);
        /// <summary>
        /// Checks if a particular element is contained in the curernt collection.
        /// </summary>
        /// <param name="val">The element to be found</param>
        /// <returns></returns>
        bool Contains(ISetTree<T> val);
        /// <summary>
        /// Returns the index of a current tree in the set
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        int IndexOf(ISetTree<T> val);
        /// <summary>
        /// Adds tree in the collection in a sorted order.
        /// </summary>
        /// <param name="value">Value to be added of type <typeparamref name="T"/></param>
        void Add(ISetTree<T> value);
        /// <summary>
        /// Adds a range of trees in the collection in a sorted order.
        /// </summary>
        /// <param name="coll">The elements to be added.</param>
        void AddRange(IEnumerable<ISetTree<T>> coll);
        Element<T> FindElementByIndex(int index);

    }//ISortedSubSets
}//namespace
