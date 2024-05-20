using System;
using System.Collections.Generic;

namespace SetLibrary.Collections
{
    public interface ISetCollection<T>
        where T : IComparable
    {
        /// <summary>
        /// Gets the current set element in the collection.
        /// </summary>
        /// <param name="index">The index of the set in the collection.</param>
        /// <returns>A set object in the collection.</returns>
        ICSet<T> this[int index] { get; }
        /// <summary>
        /// Returns the number of sets in the collection.
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Adds a new set in the collection. A name will also be added for the set.
        /// </summary>
        /// <param name="item">The set to be added.</param>
        void Add(ICSet<T> item);
        /// <summary>
        /// Removes a set from the collection.
        /// </summary>
        /// <param name="item">The set to be removed.</param>
        void Remove(ICSet<T> item);
        /// <summary>
        /// Removes a set based on it's name in the collection.
        /// </summary>
        /// <param name="name">The letter based name of the set.</param>
        void Remove(string name);
        /// <summary>
        /// Removes a set and it's name on the collection based on an index.
        /// </summary>
        /// <param name="index">The zero based index of the set.</param>
        void RemoveAt(int index);
        /// <summary>
        /// Get an enumerator of the set structure of the sets in the collection.
        /// </summary>
        /// <returns>An enumerable collection of the set structure.</returns>
        IEnumerator<Set> GetEnumerator();
        /// <summary>
        /// Resets the naming(numbering) of sets in the current collection.
        /// </summary>
        void Reset();
        /// <summary>
        /// Clear the current collection.
        /// </summary>
        void Clear();
    }//interface
}//namespace