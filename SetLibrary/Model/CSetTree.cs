using SetLibrary.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SetLibrary
{
    public class CSetTree<T> : ISetTree<T>
        where T : IComparable
    {
        //private data members to hold the data
        private string _rootElement;
        private List<ISetTree<T>> lstSubsets;
        private List<T> lstRootElements;

        //Public data members to represent the internal data
        public string RootElement => string.Join(",",this.lstRootElements);
        public int Cardinality => lstRootElements.Count + lstSubsets.Count;
        public int NumberOfSubsets => this.lstSubsets.Count;
        /// <summary>
        /// An indexer that returns a "Set" of an element inside the SetTree.
        ///     If the the element is in the root, it will be returned in a "Set" format.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>A set of ISetTree<typeparamref name="T"/></returns>
        public ISetTree<T> this[int index] 
        {
            get
            {
                //Error handling
                if (index >= Cardinality || index < 0)
                    throw new IndexOutOfRangeException();

                //If it is in the root
                if (index < lstRootElements.Count)
                    return new CSetTree<T>(lstRootElements[index]);//use the private constructor to build a new set of one element
                
                //Scale the index to macth the 
                index -= lstRootElements.Count;

                //Return the subset
                return this.lstSubsets[index];
            }//end getter
        }//INDEXER

        //This will be used to return 
        private CSetTree(T element)
        {
            //Create the new list of sets
            this.lstRootElements = new List<T>();
            this.lstSubsets = new List<ISetTree<T>>();

            //Add the element as a root of the set
            this.lstRootElements.Add(element);
        }//ctor private
        public CSetTree(List<T> rootElement)
        {
            //Create a new list of subsets
            lstSubsets = new List<ISetTree<T>>();

            //Set the root to be the new list of roots
            this.lstRootElements = rootElement;
        }//ctor 01 
        public CSetTree(List<T> rootElement,List<ISetTree<T>> SubSets)
            : this(rootElement)
        {
            //Set the subsets
            this.lstSubsets = SubSets;
        }//ctor 02
        public int CompareTo(object obj)
        {
            return string.Compare(this.RootElement, ((ISetTree<T>)obj).RootElement);
        }//CompareTo
        public void AddSubSetTree(ISetTree<T> tree)
        {
            //First check if the set is already in the tree or not
            if (IndexOfSet(tree.ToString()) >= 0)
                return;

            //Add and sort the elements
            this.lstSubsets.Add(tree);
            this.lstSubsets = this.lstSubsets.OrderBy(x => x.Cardinality).ToList();
        }//AddSubTree
        private int IndexOfSet(string element)
        {
            //first check in the root elements
            for(int index = 0; index < this.Cardinality; index++)
            {
                ISetTree<T> item = this[index];
                if (index < lstRootElements.Count)//In the root element
                {
                    //We enclose the element with oppening and clossing brace since the indexer will return the item in a set format
                    if (item.ToString() == ("{" + element + "}"))
                        return index;
                }//end if in root element
                else if (item.ToString() == element) //Not in the root element
                    return index;
            }//end for
            
            //index not found
            return -1;
        }//IndexOfSet
        public int IndexOf(T element)
        {
            //Call the inside function
            return IndexOfSet(element.ToString());
        }//IndexOf
        public bool RemoveElement(ISetTree<T> element)
        {
            //Find the index of the element/subset in the tree
            int index = IndexOfSet(element.ToString());

            //If not found, then we cannot remove
            if (index < 0)
                return false;

            //This means that it is in the root elements
            if (index < lstRootElements.Count)
                this.lstRootElements.RemoveAt(index);
            else
                //It must be in the list of subsets
                this.lstSubsets.RemoveAt(index - lstRootElements.Count);
            return true;
        }//RemoveElement
        public bool RemoveElement(T element)
        {
            //Remove from the list of root elements
            return lstRootElements.Remove(element);
        }//RemoveElement
        public void AddElement(T element)
        {
            //Covert it into a string
            string elem = element.ToString();

            //Check if it is posible subset or not
            if (!this.lstRootElements.Contains(element) && !elem.Contains("}") && !elem.Contains("{"))
            {
                //Get the unique elements
                List<T> elements = GenericExtraction<T>.SortAndRemoveDuplicates(elem, ",");

                //Add to the lsist of root elements
                this.lstRootElements.AddRange(elements);
                this.lstRootElements.Sort();
            }//end if
            else
            {
                //Check for braces first
                if (!BracesEvaluation.AreBracesCorrect(elem))
                    throw new ArgumentException("The braces are not matching, please re-check them");

                ISetTree<T> tree = GenericExtraction<T>.Extract(elem, ",");
                this.AddSubSetTree(tree);
            }//end else
        }//AddElement
        public IEnumerable<ISetTree<T>> GetSubsetsEnumarator()
        {
            foreach (var item in this.lstSubsets)
            {
                yield return item;
            }//eend for each
        }//GetSubsetsEnumarator
        public override string ToString()
        {
            //Builf the tree
            return CSetTree<T>.ToSetString(this);
        }//ToString
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
                    root += "," + nested;
                else
                    root += nested;
            }//end
            
            //Return the root element of the current set to gether with it's subsets
            return root + "}";
        }//ToString
    }//CTRee
}//namespace