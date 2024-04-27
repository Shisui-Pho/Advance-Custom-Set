using SetLibrary.Generic;
using System;
using System.Collections.Generic;

namespace SetLibrary
{
    public class CSetTree<T> : ISetTree<T>
        where T : IComparable
    {
        //private data members to hold the data
        private string _rootElement = "";
        private List<ISetTree<T>> lstSubsets;
        private List<T> lstRootElements;

        //Public data members to represent the internal data
        public string RootElement => string.Join(",",this.lstRootElements);
        public int Cardinality => lstRootElements.Count + lstSubsets.Count;
        public int NumberOfSubsets => this.lstSubsets.Count;
        public ISetTree<T> this[int index] 
        {
            get
            {
                if (index >= Cardinality || index < 0)
                    throw new IndexOutOfRangeException();

                if (index < lstRootElements.Count)
                    return new CSetTree<T>(lstRootElements[index]);//use the private constructor to build a new set of one element
                
                //Scale the index to macth the 
                index = index - lstRootElements.Count;
                //Return the subset
                return this.lstSubsets[index];
            }//end getter
        }//INDEXER
        private CSetTree(T element)
        {
            lstRootElements = new List<T>();
            lstSubsets = new List<ISetTree<T>>();
            lstRootElements.Add(element);
        }//ctor private
        public CSetTree(List<T> rootElement)
        {
            lstSubsets = new List<ISetTree<T>>();
            this.lstRootElements = rootElement;
        }//ctor 01 
        public CSetTree(List<T> rootElement,List<ISetTree<T>> SubSets)
            : this(rootElement)
        {
            this.lstSubsets = SubSets;
        }//ctor 02
        public void AddSubSetTree(ISetTree<T> tree)
        {
            if (IndexOfSet(tree.ToString()) >= 0)
                return;
            lstSubsets.Add(tree);
        }//AddSubTree
        public int CompareTo(object obj)
        {
            return string.Compare(this.RootElement, ((ISetTree<T>)obj).RootElement);
        }//CompareTo
        public void AddElement(string element)
        {
            //Check weather it is a single element or a subset
            if(element.Contains("{") || element.Contains("}"))//This means that this a subset
            {
                //Check for braces first
                if (!BracesEvaluation.AreBracesCorrect(element))
                    throw new ArgumentException("The braces are not matching, please re-check them");

                //then extract the tree
                ISetTree<T> newSubSet = GenericExtraction<T>.Extract(element, ","); //GenericExtraction<T>.Extract(element);

                //Now add the subtree as an element to this tree if it is unique
                if (IndexOfSet(newSubSet.ToString()) < 0)
                {
                    this.AddSubSetTree(newSubSet);
                }//Only add the new subset if it is unique
            }//end if
            else
            {
                //The element does not contain braces, which means that we can just add it in the root element
                List<T> ls = GenericExtraction<T>.SortAndRemoveDuplicates(element, ",");
                for (int i = 0; i < ls.Count; i++)
                    if (!lstRootElements.Contains(ls[i]))
                        lstRootElements.Add(ls[i]);
                //Sort the root elements
                lstRootElements.Sort();

                //Build the rootString
                _rootElement = string.Join(",", lstRootElements.ToArray());
            }//end else
        }//AddElement
        public bool RemoveElement(string element)
        {
            if (RootElement.Contains(element))
            {
                _rootElement = this.RootElement.Remove(this.RootElement.IndexOf(element), element.Length);
                return true;
            }//end if
            else if (element.StartsWith("{") && element.EndsWith("}"))
            {
                //First let's recreate the tree from the element string
                if (!BracesEvaluation.AreBracesCorrect(element))
                    return false;

                ISetTree<T> toremove = GenericExtraction<T>.Extract(element,",");

                int index = IndexOfSet(toremove.ToString());
                if (index < 0)
                    return false;//Element string was not found

                //Remove the element/set
                this.lstSubsets.RemoveAt(index);

                return true;
            }//And if subset

            return false;
        }//RemoveElement
        private int IndexOfSet(string element)
        {
            for (int i = 0; i < this.lstSubsets.Count; i++)
                if (this.lstSubsets[i].ToString() == element)
                    return i;
            return -1;
        }//IndexOfSet
        public int IndexOf(string element)
        {
            return IndexOfSet(element);
        }//IndexOf
        public bool RemoveElement(ISetTree<T> element)
        {
            int index = IndexOfSet(element.ToString());
            if (index < 0)
                return false;

            this.lstSubsets.RemoveAt(index);
            return true;
        }//RemoveElement
        public void AddElement(T element)
        {
            throw new NotImplementedException();
        }

        public void MergeSets(ISet<T> element)
        {
            
        }//AddElement

        public IEnumerable<ISetTree<T>> GetSubsetsEnumarator()
        {
            foreach (var item in this.lstSubsets)
            {
                yield return item;
            }
        }//
        public override string ToString()
        {
            return CSetTree<T>.ToSetString(this);
        }//ToString
        public static string ToSetString(ISetTree<T> tree)
        {
            //Base case
            if (tree.NumberOfSubsets == 0)
            {
                return "{" + tree.RootElement + "}";
            }//end if
            string root = "{" + tree.RootElement;
            foreach (ISetTree<T> subTree in tree.GetSubsetsEnumarator())
            {
                string nested = ToSetString(subTree);

                if (root != "{")
                    root += "," + nested;
                else
                    root += nested;
            }//end 
            return root + "}";
        }//ToString
    }//CTRee
}//namespace