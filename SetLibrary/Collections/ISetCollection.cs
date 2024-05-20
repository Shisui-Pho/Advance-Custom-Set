using System;
using System.Collections.Generic;

namespace SetLibrary.Collections
{
    public interface ISetCollection<T>
        where T : IComparable
    {
        IEnumerable<ICSet<T>> EnumerateCollection { get; }
        ICSet<T> this[int index] { get; }
        int Count { get; }
        void Add(ICSet<T> item);
        void Remove(ICSet<T> item);
        void Remove(string name);
        void RemoveAt(int index);
        IEnumerator<Set> GetCollectionEnumerator();
        void ResetNaming();
        void Clear();
    }//interface
}//namespace