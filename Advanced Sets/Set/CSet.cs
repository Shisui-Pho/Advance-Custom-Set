using System;
namespace Advanced_Sets.Set
{
    public class CSet
    {
        public string ElementString { get; private set; }
        public int Cardinality { get; private set; }
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
            CSetTree tree = TreeExtraction.Extract(expression);

            //The cardinality will be the Count of the first/root set
            this.Cardinality = tree.Cardinality;

            //Get the string representation of the set tree
            this.ElementString = ToSetString(tree);
        }//BuildSet
        //private string
        private string ToSetString(CSetTree tree)
        {
            //Base case
            if(tree.SubSets.Count == 0)
            {
                return "{"+tree.RootElement+"}";
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
        }//ToSetString
    }//class
}//namespace
