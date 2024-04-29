using System;
namespace SetLibrary.Generic
{
    public class GenericSet<T> :  ISet<T> 
        where T : IComparable
    {
        public string ElementString => this.tree.ToString();
        public int Cardinality => this.tree.Cardinality;

        public ISetTree<T> this[int index] 
        {
            get
            {
                if (index >= tree.Cardinality || index < 0)
                    throw new IndexOutOfRangeException();
                return this.tree[index];
            }//end getter
        }//end if

        //Data members for conversion
        public SetExtractionSettings<T> Settings { get; private set; }
        private ISetTree<T> tree;
        public GenericSet()
        {
            Settings = new SetExtractionSettings<T>(",");
            tree = new CSetTree<T>(new System.Collections.Generic.List<T>()); 
        }//ctor 01
        public GenericSet(string setString,SetExtractionSettings<T> settings)
        {
            this.Settings = settings;
            BuildSet(setString);
        }//CTOR
        public GenericSet(string setString, string seperator)
        {
            Settings = new SetExtractionSettings<T>(seperator);
            BuildSet(setString);
        }//ctor
        private void BuildSet(string expression)
        {
            if (!BracesEvaluation.AreBracesCorrect(expression))
                throw new ArgumentException("Braces are not matching");
            tree = SetExtraction.Extract(expression, Settings);
        }//BuildSet
        #region Adding and removing elements
        public void AddElement(T Element)
        {
            this.tree.AddElement(Element);
        }//AddElement

        public void AddElement(ISetTree<T> tree)
        {
            this.tree.AddSubSetTree(tree);
        }//AddElement

        public bool RemoveElement(ISetTree<T> tree)
        {
            return this.tree.RemoveElement(tree);
        }//RemoveElement
        public bool RemoveElement(T Element)
        {
            return this.tree.RemoveElement(Element);
        }//RemoveElement
        #endregion Adding and removing elements
        public ISet<T> MergeWith(ISet<T> set)
        {
            string s1 = set.ToString();
            string s2 = this.ToString();

            string expression = s1.Remove(s1.Length - 1) + "," + s2.Remove(0, 1);
            return new GenericSet<T>(expression, Settings);
        }//MergeWith

        public bool Contains(T Element)
        {
            return this.tree.IndexOf(Element) >= 0;
        }//Contains

        public bool Contains(ISetTree<T> tree)
        {
            return this.tree.IndexOf(tree.ToString()) >= 0;
        }//Contains
        public override string ToString()
        {
            return this.ElementString;
        }//ToString
        public bool IsSubSetOf(ISet<T> setB)
        {
            if (setB.Cardinality < this.Cardinality)
                return false;


            return true;
        }//IsSubSetOf
    }//
}//namespace