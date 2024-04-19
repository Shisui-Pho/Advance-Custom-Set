using System;
namespace Sets.Generic
{
    public class GenericSet<T> where T : IComparable
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
            CSetTree tree = extractor.Extract(expression);


            //The cardinality will be the Count of the first/root set
            this.Cardinality = tree.Cardinality;

            //Get the string representation of the set tree
            this.ElementString = ToSetString(tree);
            this.ElementString = ElementString.Replace(seperator.ToString(), " " + seperator.ToString() + " ").Replace("{", "{ ").Replace("}", " }");

        }//BuildSet
        private string ToSetString(CSetTree tree)
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
                    root += seperator.ToString() + nested;
                else
                    root += nested;
            }//end 
            return root + "}";
        }
    }//
}//namespace
