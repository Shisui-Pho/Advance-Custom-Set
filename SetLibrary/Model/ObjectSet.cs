using SetLibrary.Generic;
using System;
namespace SetLibrary.Objects_Sets
{
    public class ObjectSet<T> : BaseSet<T>, ISet<T>
        where T : IObjectConverter<T>, IComparable, IEquatable<T>
    {
        public ObjectSet(T placeHolder) : base()
        {
            base.Settings = new SetExtractionSettings<T>(",", " ", placeHolder);
        }//ctor main
        public ObjectSet(string setString, SetExtractionSettings<T> settings)
            : base(setString, settings)
        {
            if (settings.PlaceHolder == null)
                throw new ArgumentException("Place holder cannot be null");
        }//ctor 01
        public override bool Contains(T Element)
        {
            //First check the base elements
            foreach (T elem in base.tree.GetRootElementsEnumarator())
            {
                if (elem.Equals(Element))
                    return true;
            }//end
            //Else it is not in the root
            return false;
        }//Contains
        public override ISet<T> MergeWith(ISet<T> setB)
        {
            string s1 = this.ToString();
            string s2 = setB.ToString();

            string final = s1.Remove(s1.Length - 1) + Settings.ElementSeperator + s2.Remove(0, 1);
            return new ObjectSet<T>(final, Settings);
        }//MergeWith

        public override ISet<T> Without(ISet<T> setB)
        {
            return this - setB;
        }//Without
    }//class
}//namespace