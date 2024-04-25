using SetLibrary;
using System;
namespace Sets.Generic
{
    public class GenericSet<T> :  ISet<T> 
        where T : IComparable
    {
        public string ElementString { get; private set; }
        public int Cardinality { get; private set; }

        //Data members for conversion
        private readonly GenericExtraction<T> extractor;
        private readonly char seperator;
        public GenericSet(string setString, char seperator)
        {
            extractor = new GenericExtraction<T>(seperator);
            this.seperator = seperator;
            BuildSet(setString);
        }//ctor

        private void BuildSet(string expression)
        {
            ISetTree<T> tree = extractor.Extract(expression);


            //The cardinality will be the Count of the first/root set
            this.Cardinality = tree.Cardinality;

            //Get the string representation of the set tree
            this.ElementString = ToSetString(tree);
            this.ElementString = ElementString.Replace(seperator.ToString(), " " + seperator.ToString() + " ").Replace("{", "{ ").Replace("}", " }");

        }//BuildSet
        private string ToSetString(ISetTree<T> tree)
        {
            return tree.ToString();
        }

        public void AddElement(T Element)
        {
            throw new NotImplementedException();
        }

        public void AddElement(ISetTree<T> tree)
        {
            throw new NotImplementedException();
        }

        public bool RemoveElement(ISetTree<T> tree)
        {
            throw new NotImplementedException();
        }

        public void AddElement(ISet<T> set)
        {
            throw new NotImplementedException();
        }

        public bool RemoveElement(T Element)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T Element)
        {
            throw new NotImplementedException();
        }

        public bool Contains(ISetTree<T> tree)
        {
            throw new NotImplementedException();
        }

        public bool IsSubSetOf(ISet<T> setB)
        {
            throw new NotImplementedException();
        }
    }//
}//namespace
