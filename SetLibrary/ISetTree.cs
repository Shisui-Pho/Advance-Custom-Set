using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetLibrary
{
    public interface ISetTree<T> : IComparable
    {
        string RootElement { get; }
        int Cardinality { get; }
        int NumberOfSubsets { get; }
        ISetTree<T> this[int index]{get;}
        void AddSubSetTree(ISetTree<T> tree);
        void AddElement(string element);
        bool RemoveElement(string element);
        string ToString();
    }//class
}//namespace
