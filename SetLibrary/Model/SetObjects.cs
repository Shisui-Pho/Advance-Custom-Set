using SetLibrary.Generic;
using System;
namespace SetLibrary.Objects_Sets
{
    public class SetObjects<T> : BaseSet<T>, ISet<T>
        where T : IObjectConverter<T>, IComparable, IEquatable<T>
    {
        public SetObjects(T placeHolder) : base()
        {
            base.Settings = new SetExtractionSettings<T>(",", " ", placeHolder);
        }//ctor main
        public SetObjects(string setString, SetExtractionSettings<T> settings)
            : base(setString, settings)
        {
            if (settings.PlaceHolder == null)
                throw new ArgumentException("Place holder cannot be null");
        }//ctor 01
        public override bool Contains(T Element)
        {
            //First check the base elements
            foreach (T elem in base.tree)
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
            return new SetObjects<T>(final, Settings);
        }//MergeWith
    }//class
}//namespace