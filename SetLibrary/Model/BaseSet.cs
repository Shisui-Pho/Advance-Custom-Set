using SetLibrary.Generic;
using SetLibrary.Operations;
using System;
namespace SetLibrary
{
    public abstract class BaseSet<T> : ICSet<T>
        where T : IComparable
    {
        //Data members
        protected ISetTree<T> tree;

        //-This  data fields will keep track of the element string for updates
        private string _elementString;
        private bool _updated = false;

        //Properties
        public string ElementString => this.ToString();

        public int Cardinality => tree.Cardinality;

        public SetExtractionSettings<T> Settings { get; protected set; }

        public ISetTree<T> this[int index]
        {
            get
            {
                if (index >= tree.Cardinality || index < 0)
                    throw new IndexOutOfRangeException();
                return tree.GetElementAsSubsetByIndex(index);
            }//end getter
        }//end indexer

        public BaseSet():
            this(new SetExtractionSettings<T>(","))
        {
            _updated = false;
        }//ctor main
        protected BaseSet(SetExtractionSettings<T> settings)
        {
            this.Settings = settings;
            tree = new CSetTree<T>(new System.Collections.Generic.List<T>(), settings);
            _updated = false;
            this._elementString = this.tree.ToString();
        }//ctor 02
        public BaseSet(string setString, SetExtractionSettings<T> settings)
        {
            this.Settings = settings ?? throw new ArgumentException("Settings cannot be null");

            this.tree = BuildSetString(setString);

            //Update the element string
            _updated = false;
            this._elementString = this.tree.ToString();
        }//ctor 03
        public BaseSet(System.Collections.Generic.IEnumerable<T> collection, SetExtractionSettings<T> settings)
            : this(settings)
        {
            //Now add the elements in the collection
            foreach (var item in collection)
                this.AddElement(item);

            //Update the element string
            _updated = false;
            this._elementString = this.tree.ToString();
        }//ctor 04
        private ISetTree<T> BuildSetString(string expression)
        {
            if(!BracesEvaluation.AreBracesCorrect(expression))
                throw new ArgumentException("Braces are not matching");

            //At this point the set string braces are okay

            //Extract the set tree
            return SetExtraction.Extract(expression, this.Settings);
        }//BuildSetString
        public virtual bool Contains(ISetTree<T> tree)
        {
            return this.tree.IndexOf(tree.ToString()) >= 0;
        }//Contains
        public virtual bool IsSubSetOf(ICSet<T> setB, out SetType type)
        {
            //Assume that SetA is not a proper/sebset of B
            type = SetType.NotASubSet;

            //If set A has a higher cardinalty compared to set B then set A cannot be a subset of SetA
            if (this.Cardinality > setB.Cardinality)
                return false;
            //First start with the root elements and seee if they sre contained in the above set
            foreach (var element in this.tree.GetRootElementsEnumarator())
            {
                //If the setB does not contain an element in set A then A is not a subset of B
                if (!setB.Contains(element))
                    return false;
            }//end for each

            //Now look at the Subsets
            foreach (ISetTree<T> subset in tree.GetSubsetsEnumarator())
            {
                //If the setB does not contain the sub set then A cannot be a subset of B
                if (!setB.Contains(subset))
                    return false;
            }//end for each

            //At this point it means that all elemnts in this set are also in setB


            if (setB.Cardinality == this.Cardinality)
                type = SetType.SubSet & SetType.Same_Set;//This means that they are the same and subset.
            else
                type = SetType.ProperSet;
            return true;
        }//IsSubSetOf
        public bool IsElementOf(ICSet<T> setB)
        {
            return setB.Contains(this.tree);
        }//IsElementOf
        #region Adding and removing element on a set tree
        public virtual void AddElement(T Element)
        {
            this.tree.AddElement(Element);

            //Set the update to true
            _updated = true;
        }//AddElement

        public virtual void AddElement(ISetTree<T> tree)
        {
            this.tree.AddSubSetTree(tree);

            //Set the update to true
            _updated = true;
        }//AddElement
        public virtual bool RemoveElement(ISetTree<T> tree)
        {
            bool success = this.tree.RemoveElement(tree);
            if (success)
                _updated = true;

            return success;
        }//RemoveElement

        public virtual bool RemoveElement(T Element)
        {
            bool success = this.tree.RemoveElement(Element);
            if (success)
                _updated = true;

            return success;
        }//RemoveElement
        #endregion Adding and removing elements from a set tree
        public override string ToString()
        {
            if(_updated)
            {
                this._elementString = this.tree.ToString();
                _updated = false;
            }
            return _elementString;
        }//ToString
        public void AddSubsetAsString(string subset)
        {
            ISetTree<T> tree = BuildSetString(subset);
            this.tree.AddSubSetTree(tree);
            _updated = true;
        }//AddSubsetAsString
        public void Clear()
        {
            this.tree = CSetTree<T>.GetEmptyTree(this.Settings);
            _updated = true;
        }//Clear
        public Element<T> GetElementByIndex(int index)
        {
            return this.tree[index];
        }//GetElementByIndex
        #region Operator overloading
        public static ICSet<T> operator - (BaseSet<T> setA, ICSet<T> setB)
        {
            return setA.Difference(setB);
        }//set difference
        public static ICSet<T> operator + (BaseSet<T> setA, ICSet<T> setB)
        {
            return setA.MergeWith(setB);
        }//Set intersection
        #endregion


        #region Abstract method to be implemented by the inherited classes
        public abstract bool Contains(T Element);
        public abstract ICSet<T> MergeWith(ICSet<T> set);
        public abstract ICSet<T> Without(ICSet<T> setB);
        #endregion Abstract method to be implemented by the inherited classes
    }//class
}//namespace