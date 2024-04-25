using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetLibrary;
namespace SetLibrary
{
    public interface ISet<T>
    {
        /// <summary>
        /// Get the evaluated string representation of the set.
        /// Note : Duplicates will be removed
        /// </summary>
        string ElementString { get; }
        /// <summary>
        /// Gets the Cardinality of the evaluated set.
        /// </summary>
        int Cardinality { get; }
        ISetTree<T> this[int index] { get; }
        /// <summary>
        /// Adds a new element in the current set. If the element already exists it will not be added.
        /// </summary>
        /// <param name="Element">Element to be added</param>
        void AddElement(T Element);
        /// <summary>
        /// Adds a new tree as an element in the current set. If the element tree already exists it will not be added.
        /// This element could be a set or just an single element and will be on the first nesting level.
        /// </summary>
        /// <param name="tree"></param>
        void AddElement(ISetTree<T> tree);
        /// <summary>
        /// Adds a new tree as an element in the current set. If the tree already exists it will not be added.
        /// The tree will be on the first nesting level of the current set.
        /// </summary>
        /// <param name="tree">The tree to be removed</param>
        bool RemoveElement(ISetTree<T> tree);
        /// <summary>
        /// Adds a set as a subset of the current set. This set will be an element on the first nesting level of the current set.
        /// </summary>
        /// <param name="set"></param>
        void MergeSets(ISet<T> set);
        /// <summary>
        /// Removes an element in the current set. This element could be a set or just an single element.
        /// This element must be on the first nesting level.
        /// </summary>
        /// <param name="Element">The element tree to be removed</param>
        /// <returns>Returns a bool indicating if the element was found and removed or not</returns>
        bool RemoveElement(T Element);
        /// <summary>
        /// Removes an element in the current set. This element could be a set or just an single element.
        /// This element must be on the first nesting level.
        /// </summary>
        /// <param name="Element">The element to be search</param>
        /// <returns>Returns a bool indicating if the element was found and removed or not</returns>
        bool Contains(T Element);
        /// <summary>
        /// Checks if the element exists in the current set. This element will be on the first nesting level.
        /// </summary>
        /// <param name="tree">The </param>
        /// <returns>Returns true if the it is in the set</returns>
        bool Contains(ISetTree<T> tree);
        /// <summary>
        /// Checks if the current set is a subset of setB.
        /// </summary>
        /// <param name="tree">The set to check for.</param>
        /// <returns>True if the set is a subset.</returns>
        bool IsSubSetOf(ISet<T> setB);

    }//interface : ISet
}//namespace