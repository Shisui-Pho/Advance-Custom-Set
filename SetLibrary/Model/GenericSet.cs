using System;
namespace SetLibrary.Generic
{
    public class GenericSet<T> :BaseSet<T> ,ISet<T> 
        where T : IComparable
    {
        public GenericSet():base()
        {
        }//ctor 01
        public GenericSet(SetExtractionSettings<T> settings)
            : base()
        {
            //Override the base collection
            base.Settings = settings;
        }//ctor 01
        public GenericSet(string setString,SetExtractionSettings<T> settings)
            :base(setString,settings)
        {
        }//CTOR
        public override ISet<T> MergeWith(ISet<T> set)
        {
            string s1 = set.ToString();
            string s2 = this.ToString();

            string expression = s1.Remove(s1.Length - 1) + "," + s2.Remove(0, 1);
            return new GenericSet<T>(expression, Settings);
        }//MergeWith

        public override bool Contains(T Element)
        {
            return this.tree.IndexOf(Element) >= 0;
        }//Contains
        public override bool IsSubSetOf(ISet<T> setB)
        {
            if (setB.Cardinality < this.Cardinality)
                return false;


            return true;
        }//IsSubSetOf
    }//
}//namespace