using System;
using SetLibrary.Generic;
namespace SetLibrary
{
    /// <summary>
    /// A set object for strings only
    /// </summary>
    public class CSet : BaseSet<string> ,ISet<string>
    {
        public CSet() : base()
        {
        }//ctor default
        public CSet(string elementString)
            : base(elementString, new SetExtractionSettings<string>(","))
        { 
        }//ctor main
        public override bool Contains(string Element)
        {
            if(!Element.Contains("{") && !Element.Contains("}"))
            {
                //Check if that element is there or not
                return this.tree.RootElement.Contains(Element);
            }//end if clean string/To look at the root
            if (Element.StartsWith("{") && Element.EndsWith("}"))
            {
                string s = SetExtraction.Extract(Element, Settings).ToString();
                return this.tree.IndexOf(s) >= 0;
            }//end if a subset
            return false;
        }//Contains
        #region Set Operations
        public override ISet<string> MergeWith(ISet<string> set)
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
            return this - setB;
        }//Without
        #endregion Set operations
        public override string ToString()
        {
            return this.ElementString;
        }//ToString
    }//class
}//namespace