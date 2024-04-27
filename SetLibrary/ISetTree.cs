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
        IEnumerable<ISetTree<T>> GetSubsetsEnumarator();
        void AddSubSetTree(ISetTree<T> tree);
        void AddElement(string element);
        void AddElement(T element);
        bool RemoveElement(string element);
        bool RemoveElement(ISetTree<T> element);
        int IndexOf(string element);
        string ToString();
    }//class
}//namespace
