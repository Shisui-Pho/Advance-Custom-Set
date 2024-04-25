using SetLibrary;
using Sets.Generic;
using System;
using System.Collections.Generic;

namespace Sets
{
    public class CSetTree<T> : ISetTree<T>
        where T : IComparable
    {
        public string RootElement { get; private set; }
        private List<ISetTree<T>> lstSubsets;
        public int Cardinality { get; private set; }
        public int NumberOfSubsets => this.lstSubsets.Count;

        public ISetTree<T> this[int index] 
        {
            get
            {
                if (index >= NumberOfSubsets || index < 0)
                    throw new IndexOutOfRangeException();
                return this.lstSubsets[index];
            }//end getter
        }//INDEXER

        public CSetTree(string rootElement, int cardinality = 0)
        {
            lstSubsets = new List<ISetTree<T>>();
            this.RootElement = rootElement;
            this.Cardinality = cardinality;
        }//ctor 01 
        public CSetTree(string rootElement,List<ISetTree<T>> SubSets, int cardinality = 0)
            : this(rootElement,cardinality)
        {
            this.lstSubsets = SubSets;
        }//ctor 02
        public void AddSubSetTree(ISetTree<T> tree)
        {
            if (IndexOfSet(tree.ToString()) >= 0)
                return;
            lstSubsets.Add(tree);
            Cardinality++;
            Sort();
        }//AddSubTree
        private void Sort()
        {
            this.lstSubsets.Sort();
        }//Sort
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
                if (!this.lstSubsets.Contains(newSubSet))
                {
                    this.AddSubSetTree(newSubSet);
                    this.Cardinality++;
                }//Only add the new subset if it is unique
            }//end if
            else
            {
                //The element does not contain braces, which means that we can just add it in the root element
                this.RootElement = TreeExtraction.SortAndRemoveDuplicates(this.RootElement + "," + element, out int cardinality);
                if (cardinality != this.Cardinality)
                    this.Cardinality++;
            }//end else
        }//AddElement
        public bool RemoveElement(string element)
        {
            if (RootElement.Contains(element))
            {
                this.RootElement = this.RootElement.Remove(this.RootElement.IndexOf(element), element.Length);
                Cardinality--;
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

                //Decreament the cardinality
                Cardinality--;
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
            for(int i = 0; i< tree.NumberOfSubsets;i++) //( in tree.SubSets)
            {
                ISetTree<T> subTree = tree[i];
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