using SetLibrary.Generic;
using System;
namespace SetLibrary
{
    public abstract class BaseSet<T>
        where T : IComparable
    {
        //Data members
        protected ISetTree<T> tree;

        //Properties
        public string ElementString => tree.ToString();

        public int Cardinality => tree.Cardinality;

        public SetExtractionSettings<T> Settings { get; protected set; }

        public ISetTree<T> this[int index]
        {
            get
            {
                if (index >= tree.Cardinality || index < 0)
                    throw new IndexOutOfRangeException();
                return tree[index];
            }//end getter
        }//end indexer
        public BaseSet()
        {
            Settings = new SetExtractionSettings<T>(",");
            tree = new CSetTree<T>(new System.Collections.Generic.List<T>(), Settings);
        }//ctor main
        public BaseSet(string setString, SetExtractionSettings<T> settings)
        {
            this.Settings = settings;
            BuildSetString(setString);
        }//ctor 02
        private void BuildSetString(string expression)
        {
            if(!BracesEvaluation.AreBracesCorrect(expression))
                throw new ArgumentException("Braces are not matching");

            //At this point the set string braces are okay

            //Extract the set tree
            this.tree = SetExtraction.Extract(expression, this.Settings);
        }//BuildSetString
        public virtual bool Contains(ISetTree<T> tree)
        {
            return this.tree.IndexOf(tree.ToString()) >= 0;
        }//Contains
        #region Addingd and removing element on a set tree
        public virtual void AddElement(T Element)
        {
            this.tree.AddElement(Element);
        }//AddElement

        public virtual void AddElement(ISetTree<T> tree)
        {
            this.tree.AddSubSetTree(tree);
        }//AddElement
        public virtual bool RemoveElement(ISetTree<T> tree)
        {
            return this.tree.RemoveElement(tree);
        }//RemoveElement

        public virtual bool RemoveElement(T Element)
        {
            return tree.RemoveElement(Element);
        }//RemoveElement
        #endregion Adding and removing elements from a set tree
        public override string ToString()
        {
            return ElementString;
        }//ToString

        #region Abstract method to be implemented by the inherited classes
        public abstract bool Contains(T Element);
        public abstract bool IsSubSetOf(ISet<T> setB);
        public abstract ISet<T> MergeWith(ISet<T> set);
        #endregion Abstract method to be implemented by the inherited classes
    }//class
}//namespace