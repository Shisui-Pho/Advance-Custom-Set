using System;
using System.Collections.Generic;
namespace SetLibrary.Collections
{
    public interface ISortedSetCollection<T>
        where T : IComparable
    {
        /// <summary>
        /// Get the number of elements within the collection
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Get the element within the current set collection based on the index. Level of nesting will be determined.
        /// </summary>
        /// <param name="index">The xero based index of the element.</param>
        /// <returns>An element type ref structure.</returns>
        Element<T> this[int index] { get; }
        /// <summary>
        /// Removed an element in the currrent collection based on the index
        /// </summary>
        /// <param name="index">The zero based index of the element</param>
        void RemoveAt(int index);
        /// <summary>
        /// Finds an element in the set collection base on an index.
        /// </summary>
        /// <param name="index">Zero based index of the element.</param>
        /// <returns>An element structure with the information about that particular element.</returns>
        Element<T> FindElementByIndex(int index);
    }//class
}//namespace
