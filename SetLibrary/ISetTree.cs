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
        bool IsInRoot { get; }
        ISetTree<T> this[int index]{get;}
        IEnumerable<ISetTree<T>> GetSubsetsEnumarator();
        void AddSubSetTree(ISetTree<T> tree);
        void AddElement(T element);
        bool RemoveElement(T element);
        bool RemoveElement(ISetTree<T> element);
        int IndexOf(T element);
        int IndexOf(string element);
        string ToString();
    }//class
}//namespace
