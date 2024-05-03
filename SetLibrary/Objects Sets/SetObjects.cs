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
            throw new NotImplementedException();
        }//Contains

        public override bool IsSubSetOf(ISet<T> setB, out SetType type)
        {
            throw new NotImplementedException();
        }

        public override ISet<T> MergeWith(ISet<T> set)
        {
            throw new NotImplementedException();
        }//MergeWith
    }//class
}//namespace