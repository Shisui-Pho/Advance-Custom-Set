using SetLibrary.Generic;
using System;
namespace SetLibrary.Objects_Sets
{
    public class SetObjects<T> : BaseSet<T>, ISet<T>
        where T : IObjectConverter<T>, IComparable
    {
        public override bool Contains(T Element)
        {
            throw new NotImplementedException();
        }//Contains
        public override bool IsSubSetOf(ISet<T> setB)
        {
            throw new NotImplementedException();
        }//IsSubSetOf
        public override ISet<T> MergeWith(ISet<T> set)
        {
            throw new NotImplementedException();
        }//MergeWith
    }//class
}//namespace