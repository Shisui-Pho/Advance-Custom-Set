﻿using SetLibrary.Generic;
using System;
namespace SetLibrary.Objects_Sets
{
    public class ObjectSet<T> : BaseSet<T>, ICSet<T>
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
        }//ctor 02
        public ObjectSet(T[] elements, SetExtractionSettings<T> settings) :
            base(elements, settings)
        {

        }//ctor 03
        public ObjectSet(System.Collections.Generic.IEnumerable<T> elements, SetExtractionSettings<T> settings):
            base(elements, settings)
        {
        }//ctor 04
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
        public override ICSet<T> MergeWith(ICSet<T> setB)
        {
            string s1 = this.ToString();
            string s2 = setB.ToString();

            string final = s1.Remove(s1.Length - 1) + Settings.ElementSeperator + s2.Remove(0, 1);
            return new ObjectSet<T>(final, Settings);
        }//MergeWith

        public override ICSet<T> Without(ICSet<T> setB)
        {
            return this - setB;
        }//Without
    }//class
}//namespace