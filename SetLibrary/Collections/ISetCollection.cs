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
        /// Checks weather the current set collection contains a set.
        /// </summary>
        /// <param name="item">The set to be searched.</param>
        /// <returns>True if the set is in the current collection.</returns>
        bool Contains(ICSet<T> item);
        /// <summary>
        /// Checks weather the current set collection contains the name of a given set.
        /// </summary>
        /// <param name="name">The name of the set.</param>
        /// <returns>True if the set is in the collection.</returns>
        bool Contains(string name);
        /// <summary>
        /// Finds a set by it's name in the current collection.
        /// </summary>
        /// <param name="name">The name of the set.</param>
        /// <returns>A set if it was found in the collection.</returns>
        ICSet<T> FindSetByName(string name);
        /// <summary>
        /// Get the set structure in the collection by index.
        /// </summary>
        /// <param name="index">The zero based index of the set</param>
        /// <returns>A structure of the set in the collection</returns>
        Set GetSetByIndex(int index);
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