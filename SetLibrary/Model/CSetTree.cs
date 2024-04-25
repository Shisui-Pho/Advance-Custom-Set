using System;
using System.Collections.Generic;

namespace Sets
{
    public class CSetTree : IComparable
    {
        public string RootElement { get; private set; }
        public List<CSetTree> SubSets { get; private set; }
        public int Cardinality { get; private set; }
        public CSetTree(string rootElement, int cardinality = 0)
        {
            SubSets = new List<CSetTree>();
            this.RootElement = rootElement;
            this.Cardinality = cardinality;
        }//ctor 01 
        public CSetTree(string rootElement,List<CSetTree> SubSets, int cardinality = 0)
            : this(rootElement,cardinality)
        {
            this.SubSets = SubSets;
        }//ctor 02
        public void AddSubSetTree(CSetTree tree)
        {
            if (IndexOfSet(tree.ToString()) >= 0)
                return;
            SubSets.Add(tree);
            Cardinality++;
            Sort();
        }//AddSubTree
        private void Sort()
        {
            this.SubSets.Sort();
        }//Sort

        public int CompareTo(object obj)
        {
            return string.Compare(this.RootElement, ((CSetTree)obj).RootElement);
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
                CSetTree newSubSet = TreeExtraction.Extract(element);

                //Now add the subtree as an element to this tree if it is unique
                if (!this.SubSets.Contains(newSubSet))
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

                CSetTree toremove = TreeExtraction.Extract(element);

                int index = IndexOfSet(toremove.ToString());
                if (index < 0)
                    return false;//Element string was not found

                //Remove the element/set
                this.SubSets.RemoveAt(index);

                //Decreament the cardinality
                Cardinality--;
                return true;
            }//And if subset

            return false;
        }//RemoveElement
        private int IndexOfSet(string element)
        {
            for (int i = 0; i < this.SubSets.Count; i++)
                if (this.SubSets[i].ToString() == element)
                    return i;
            return -1;
        }//IndexOfSet
        public override string ToString()
        {
            return CSetTree.ToSetString(this);
        }//ToString
        public static string ToSetString(CSetTree tree)
        {
            //Base case
            if (tree.SubSets.Count == 0)
            {
                return "{" + tree.RootElement + "}";
            }//end if
            string root = "{" + tree.RootElement;
            foreach (CSetTree subTree in tree.SubSets)
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