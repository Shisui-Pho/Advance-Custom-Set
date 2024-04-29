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
        private readonly SetExtractionSettings<T> extractor;
        private readonly char seperator;
        private ISetTree<T> tree;
        public GenericSet(string setString, char seperator)
        {
            extractor = new SetExtractionSettings<T>(seperator);
            this.seperator = seperator;
            BuildSet(setString);
        }//ctor
        public GenericSet()
        {
            extractor = new SetExtractionSettings<T>(',');
            this.seperator = ',';
            this.tree = new CSetTree<T>(new System.Collections.Generic.List<T>());
        }//CTOR
        private void BuildSet(string expression)
        {
            if (!BracesEvaluation.AreBracesCorrect(expression))
                throw new ArgumentException("Braces are not matching");

            tree = extractor.Extract(expression);
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
            return new GenericSet<T>(expression, seperator);
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