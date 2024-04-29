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

        public SetExtractionSettings<string> Settings { get; private set; }

        public ISetTree<string> this[int index] 
        {
            get
            {
                if (index >= tree.Cardinality || index < 0)
                    throw new IndexOutOfRangeException();
                return this.tree[index];
            }//end getter
        }//End if
        public CSet()
        {
            Settings = new SetExtractionSettings<string>(",");
            tree = new CSetTree<string>(new System.Collections.Generic.List<string>(), Settings);
        }//ctor default
        public CSet(string elementString)
        {
            Settings = new SetExtractionSettings<string>(",");
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
            ISetTree<string> tree = SetExtraction.Extract(expression,Settings);
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
                string s = SetExtraction.Extract(Element, Settings).ToString();
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
        public ISet<string> MergeWith(ISet<string> set)
        {
            //Get the string representation of the sets
            string s1 = set.ToString();
            string s2 = this.ToString();

            //Now create the string representation of the new merged set
            string final = s1.Remove(s1.Length - 1) + "," + s2.Remove(0, 1);

            //Return a new instance of the set
            return new CSet(final);
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
