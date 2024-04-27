using System;
using SetLibrary.Generic;
namespace SetLibrary
{
    /// <summary>
    /// A set object for strings only
    /// </summary>
    public class CSet : ISet<string>
    {

        //This will save the elements  
        private ISetTree<string> tree;
        public string ElementString => tree.ToString();
        public int Cardinality => tree.Cardinality;

        public ISetTree<string> this[int index] 
        {
            get
            {
                if (index >= tree.Cardinality || index < 0)
                    throw new IndexOutOfRangeException();
                return this.tree[index];
            }//end getter
        }//End if
        public CSet(string elementString)
        {
            BuildSet(elementString);
        }//ctor main
        private void BuildSet(string expression)
        {
            if (!BracesEvaluation.AreBracesCorrect(expression))
            {
                throw new ArgumentException("Braces are not matching");
            }//end if

            //At this point the braces are correct

            //Extract the set tree
            ISetTree<string> tree = GenericExtraction<string>.Extract(expression, ",");
            this.tree = tree;
        }//BuildSet

        #region Removing and adding elements
        public void AddElement(string element)
        {
            this.tree.AddElement(element);
        }//AddElement
        public void AddElement(ISetTree<string> tree)
        {
            this.tree.AddSubSetTree(tree);
        }//AddElement
        public bool RemoveElement(string element)
        {
            return tree.RemoveElement(element);
        }//RemoveElement
        public bool RemoveElement(ISetTree<string> tree)
        {
            return this.tree.RemoveElement(tree);
        }//RemoveElement
        #endregion Removing and adding elements

        public bool Contains(string Element)
        {
            if(!Element.Contains("{") && !Element.Contains("}"))
            {
                //Check if that element is there or not
                return this.tree.RootElement.Contains(Element);
            }//end if clean string/To look at the root
            if (Element.StartsWith("{") || Element.EndsWith("}"))
            {
                string s = GenericExtraction<string>.Extract(Element, ",").ToString();
                return this.tree.IndexOf(s) >= 0;
            }//end if a subset
            return false;
        }//Contains
        public bool Contains(ISetTree<string> tree)
        {
            return this.tree.IndexOf(tree.ToString()) >= 0;
        }//Contains

        #region Set Operations
        public bool IsSubSetOf(ISet<string> setB)
        {
            throw new NotImplementedException();
        }//IsSubSetOf
        public ISet<string> MergeSets(ISet<string> set)
        {
            string s1 = set.ToString();
            string s2 = this.ToString();

            //Now create

            return default;
        }//MergeSets
        public ISet<string> Without(ISet<string> setB)
        {
            return default;
        }//Without
        #endregion Set operations
        public override string ToString()
        {
            return this.ElementString;
        }//ToString
    }//class
}//namespace
