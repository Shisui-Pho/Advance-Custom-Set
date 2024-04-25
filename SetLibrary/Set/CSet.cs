using System;
using SetLibrary.Generic;
namespace SetLibrary
{
    public class CSet : ISet<string>
    {
        public string ElementString { get; private set; }
        public int Cardinality { get; private set; }
        
        //This will save the elements  
        private ISetTree<string> tree;
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
            //The cardinality will be the Count of the first/root set
            this.Cardinality = tree.Cardinality;

            //Get the string representation of the set tree
            this.ElementString = ToSetString(tree);
            this.ElementString = ElementString.Replace(",", " , ").Replace("{", "{ ").Replace("}"," }");
        }//BuildSet
        //private string
        private string ToSetString(ISetTree<string> tree)
        {
            return tree.ToString();
        }//ToSetString
        public void AddElement(string element)
        {
            this.tree.AddElement(element);
        }//AddElement
        public bool RemoveElement(string element)
        {
            bool sucess = tree.RemoveElement(element);
            if (sucess)
            {
                ElementString = tree.ToString();
                this.Cardinality = tree.Cardinality;
            }
            return sucess;
        }//RemoveElement

        public void AddElement(ISetTree<string> tree)
        {
            throw new NotImplementedException();
        }

        public bool RemoveElement(ISet<string> tree)
        {
            throw new NotImplementedException();
        }

        public void AddElement(ISet<string> set)
        {
            throw new NotImplementedException();
        }

        public bool Contains(string Element)
        {
            throw new NotImplementedException();
        }

        public bool Contains(ISetTree<string> tree)
        {
            throw new NotImplementedException();
        }

        public bool IsSubSetOf(ISet<string> setB)
        {
            throw new NotImplementedException();
        }//

        public bool RemoveElement(ISetTree<string> tree)
        {
            throw new NotImplementedException();
        }
    }//class
}//namespace
