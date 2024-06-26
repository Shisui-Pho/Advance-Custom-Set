﻿using System;
namespace SetLibrary.Generic
{
    public class GenericSet<T> :BaseSet<T> ,ICSet<T> 
        where T : IComparable
    {
        public GenericSet():base()
        {
        }//ctor default
        public GenericSet(SetExtractionSettings<T> settings)
            : base(settings)
        {
            //Override the base collection
            base.Settings = settings;
        }//ctor 02
        public GenericSet(string setString,SetExtractionSettings<T> settings)
            :base(setString,settings)
        {
        }//ctor 03
        public GenericSet(T[] elements, SetExtractionSettings<T> settings)
            : base(elements,settings)
        {
        }//ctor 01
        public GenericSet(System.Collections.Generic.IEnumerable<T> elemets,SetExtractionSettings<T> settings) :
            base(elemets, settings)
        {

        }//ctor 04
        public override ICSet<T> MergeWith(ICSet<T> set)
        {
            string s1 = set.ToString();
            string s2 = this.ToString();

            string expression = s1.Remove(s1.Length - 1) + Settings.ElementSeperator + s2.Remove(0, 1);
            return new GenericSet<T>(expression, Settings);
        }//MergeWith

        public override bool Contains(T Element)
        {
            return this.tree.IndexOf(Element) >= 0;
        }//Contains

        public override ICSet<T> Without(ICSet<T> setB)
        {
            return this - setB;
        }//Without
    }//class
}//namespace