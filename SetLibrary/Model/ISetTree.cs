﻿using SetLibrary.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetLibrary
{
    public interface ISetTree<T> : IComparable
        where T : IComparable
    {
        /// <summary>
        /// String representation of the root elements.
        /// </summary>
        string RootElement { get; }
        /// <summary>
        /// Cardinality of the current set.
        /// </summary>
        int Cardinality { get; }
        /// <summary>
        /// Number of nested subset in the root of the current set.
        /// </summary>
        int NumberOfSubsets { get; }
        /// <summary>
        /// Determine if an element is in the root or not.
        /// </summary>
        bool IsInRoot { get; }
        /// <summary>
        /// Set extraction settings.
        /// </summary>
        SetExtractionSettings<T> ExtractionSettings { get;}
        /// <summary>
        /// Gets the set representation of an element in the current set.
        /// </summary>
        /// <param name="index">The zero based index inside the set.</param>
        /// <returns>An element in a set format.</returns>
        ISetTree<T> this[int index]{get;}
        Element<T> this[int index, int flag_for_now = 0] { get; }
        /// <summary>
        /// Returns an enumerator that iterates through the subsets. 
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the subsets</returns>
        IEnumerable<ISetTree<T>> GetSubsetsEnumarator();
        /// <summary>
        /// Returns an enumerator that iterates through the root elements. 
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the root elements</returns>
        IEnumerable<T> GetRootElementsEnumarator();
        /// <summary>
        /// Adds a subset inside the current set.
        /// </summary>
        /// <param name="tree">The tree represenstation of the subset.</param>
        void AddSubSetTree(ISetTree<T> tree);
        /// <summary>
        /// Adds a single element in the root elements of the current set.
        /// </summary>
        /// <param name="element">The element to be added.</param>
        void AddElement(T element);
        /// <summary>
        /// Removes an element in the root of the current set.
        /// </summary>
        /// <param name="element">An element to be removed</param>
        /// <returns>A boolean to indicate whether an element was removed or not.</returns>
        bool RemoveElement(T element);
        /// <summary>
        /// Remove a subset in the current set.
        /// </summary>
        /// <param name="element">The element to be removed</param>
        /// <returns>A boolean to indicate whether an element was removed or not.</returns>
        bool RemoveElement(ISetTree<T> element);
        /// <summary>
        /// Gets the index of the element in the root.
        /// </summary>
        /// <param name="element">Element to be searched.</param>
        /// <returns>A zero based index of the element within the root.</returns>
        int IndexOf(T element);
        /// <summary>
        /// Gets the index of the element in the set, could be oon the root or a subset.
        /// </summary>
        /// <param name="element">A string representation of the element.</param>
        /// <returns>A zero based index of the element within the set.</returns>
        int IndexOf(string element);
        /// <summary>
        /// Gets the index of the subset in the nested in the current set.
        /// </summary>
        /// <param name="subset"></param>
        /// <returns>A zero based index of the element within the set.</returns>
        int IndexOf(ISetTree<T> subset);
        /// <summary>
        /// Get the string representation of the current set tree.
        /// </summary>
        /// <returns>A string representing the set.</returns>
        string ToString();
    }//class
}//namespace
