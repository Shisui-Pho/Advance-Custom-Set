using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetLibrary.Model
{
    internal interface ISortedSetCollection<T> : IEnumerable<T>
        where T : IComparable
    {
        int Count { get; }
        Element<T> this[int index] { get; }
        void Add(T value);
        void AddRange(IEnumerable<T> coll);
        int IndexOf(T val);
        bool Remove(T val);
        void RemoveAt(int index);
        bool Contains(T val);
    }//class
}//namespace
