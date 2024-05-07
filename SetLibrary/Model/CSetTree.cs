using SetLibrary.Collections;
using SetLibrary.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SetLibrary
{
    public class CSetTree<T> : ISetTree<T>
        where T : IComparable
    {
        //private data members to hold the data
        private SortedElements<T> lstRootElements;
        private SortedSubSets<T> lstSubsets;

        //Public data members to represent the internal data
        public string RootElement => string.Join(ExtractionSettings.ElementSeperator,this.lstRootElements);
        public int Cardinality => lstRootElements.Count + lstSubsets.Count;
        public int NumberOfSubsets => this.lstSubsets.Count;
        public bool IsInRoot { get; private set; }

        public SetExtractionSettings<T> ExtractionSettings { get; private set; }

        public Element<T> this[int index, int flag_for_now = 0]
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException();
                if (index < lstRootElements.Count)
                    return ((ISortedElements<T>)lstRootElements)[index];

                //Scale the index to match the subset zero based index
                index = index - lstRootElements.Count;
                return ((ISortedSubSets<T>)lstSubsets)[index];
            }//getter
        }//indexer

        public ISetTree<T> this[int index] 
        {
            get
            {
                //Error handling
                if (index >= Cardinality || index < 0)
                    throw new IndexOutOfRangeException();

                //If it is in the root
                if (index < lstRootElements.Count)
                    return new CSetTree<T>(lstRootElements[index], this.ExtractionSettings);//use the private constructor to build a new set of one element
                
                //Scale the index to macth the 
                index -= lstRootElements.Count;

                //Return the subset
                return (ISetTree<T>)this.lstSubsets[index];
            }//end getter
        }//INDEXER
        #region Constructures
        //This will be used to return 
        private CSetTree(T element, SetExtractionSettings<T> settings)
        {
            //Create the new list of sets
            this.lstRootElements = new SortedElements<T>();
            this.lstSubsets = new SortedSubSets<T>();
            //Add the element as a root of the set
            this.lstRootElements.Add(element);

           //Set the flag to true to indicate that it is in the root
            IsInRoot = true;

            //Set the extraction settings
            this.ExtractionSettings = settings;
        }//ctor private
        /// <summary>
        /// Creates a new instance of a Set tree with the settings set to default.
        /// </summary>
        /// <param name="rootElements">The root elements</param>
        public CSetTree(List<T> rootElements)
        {
            //Create a new list of subsets
            //Set the root to be the new list of roots
            this.lstRootElements = new SortedElements<T>(rootElements);
            this.lstSubsets = new SortedSubSets<T>();
            IsInRoot = false;
            ExtractionSettings = new SetExtractionSettings<T>(",");
        }//ctor 01    
        /// <summary>
        /// Creates a new instance of a Set tree with the settings for extraction.
        /// </summary>
        /// <param name="rootElements">The root elements</param>
        /// <param name="settings">The set extraction settings</param>
        public CSetTree(List<T> rootElements, SetExtractionSettings<T> settings): this(rootElements)
        {
            ExtractionSettings = settings;
        }//ctor 01 

        /// <summary>
        /// Creates a new instance of a Set tree with the settings for extraction set to default.
        /// </summary>
        /// <param name="rootElement">The root elements.</param>
        /// <param name="SubSets">The subsets</param>
        public CSetTree(List<T> rootElement,List<ISetTree<T>> SubSets)
            : this(rootElement)
        {
            //Use the set settings
            if(SubSets.Count > 0)
                this.ExtractionSettings = SubSets[0].ExtractionSettings;
            this.lstSubsets = new SortedSubSets<T>(SubSets);
            IsInRoot = false;
        }//ctor 03
        /// <summary>
        ///  Creates a new instance of a Set tree with the settings for extraction.
        /// </summary>
        /// <param name="rootElements">The root elements.</param>
        /// <param name="SubSets">The subsets</param>
        /// <param name="settings">The extraction settings</param>
        public CSetTree(List<T> rootElements,List<ISetTree<T>> SubSets, SetExtractionSettings<T> settings)
            : this(rootElements, SubSets)
        {
            this.ExtractionSettings = settings;
        }//ctor 04
        #endregion Constructers
        #region Adding and removing elements and subtrees
        public void AddSubSetTree(ISetTree<T> tree)
        {
            //First check if the set is already in the tree or not
            if (this.lstSubsets.IndexOf(tree) >= 0)
                return;

            //Add and sort the elements
            this.lstSubsets.Add(tree);
            //this.lstSubsets = this.lstSubsets.OrderBy(x => x.Cardinality).ToList();
        }//AddSubTree
        public bool RemoveElement(ISetTree<T> element)
        {
            return lstSubsets.Remove(element);
        }//RemoveElement
        public bool RemoveElement(T element)
        {
            //Remove from the list of root elements
            return lstRootElements.Remove(element);
        }//RemoveElement
        public void AddElement(T element)
        {
            //Add it in the root
            lstRootElements.Add(element);
        }//AddElement

        #endregion Adding and removing elements and subtrees
        #region IndexOf methods
        private int IndexOfSet(string element)
        {
            int index = 0;

            //First check in the root elements
            foreach (var item in lstRootElements)
            {
                if (item.ToString() == element)
                    return index;
                index++;
            }//eand for each

            //Then check in the subsets
            foreach (var item in lstSubsets)
            {
                if (item.ToString() == element)
                    return index;
                index++;
            }//end for each

            //If it was not found on the both the collection then it is not there
            return -1;
        }//IndexOfSet
        public int IndexOf(T element)
        {
            //Call the inside function
            return lstRootElements.IndexOf(element);
        }//IndexOf
        public int IndexOf(string element)
        {
            //Call the inside function
            return IndexOfSet(element);
        }//IndexOf
        public int IndexOf(ISetTree<T> subset)
        {
            return lstSubsets.IndexOf(subset) + lstRootElements.Count;
        }//IndexOf
        #endregion IndexOf methods
        #region Interface Implementations
        /// <summary>
        /// Enumarate through the subelements element of the current set
        /// </summary>
        /// <returns>A tree of type <typeparamref name="T"/> as an element from this tree</returns>
        public IEnumerable<ISetTree<T>> GetSubsetsEnumarator()
        {
            foreach (var item in this.lstSubsets)
            {
                yield return item;
            }//eend for each
        }//GetSubsetsEnumarator
        public IEnumerable<T> GetRootElementsEnumarator()
        {
            foreach (var item in lstRootElements)
            {
                yield return item;
            }
        }//GetRootElementsEnumarator
        public int CompareTo(object obj)
        {
            return string.Compare(this.RootElement, ((ISetTree<T>)obj).RootElement);
        }//CompareTo
        public override string ToString()
        {
            //Builf the tree
            return CSetTree<T>.ToSetString(this);
        }//ToString

        #endregion Interface Implementations
        /// <summary>
        /// Recuresive procedure to build a set string using a dept first retrieval/search
        /// </summary>
        /// <param name="tree">The set tree to be traversed</param>
        /// <returns>A string representation of the set tree.</returns>
        public static string ToSetString(ISetTree<T> tree)
        {
            //Base case
            if (tree.NumberOfSubsets == 0)
            {
                if (tree.RootElement == "")
                    return "{\u2205}";//An empty set
                return "{" + tree.RootElement + "}";
            }//end if
            
            //
            string root = "{" + tree.RootElement;
            foreach (ISetTree<T> subTree in tree.GetSubsetsEnumarator())
            {
                string nested = ToSetString(subTree);

                //If it is just clossing oppening braces
                //-E.g. If the set string was : {{{{{5}}}}}, 
                //-The end results will be {,{,{,{,{5}}}}}
                //That's why we have this check which will yield : {{{{{5}}}}}
                if (root != "{")
                    root += tree.ExtractionSettings.ElementSeperator + nested;
                else
                    root += nested;
            }//end
            
            //Return the root element of the current set to gether with it's subsets
            return root + "}";
        }//ToString
    }//CTRee
}//namespace