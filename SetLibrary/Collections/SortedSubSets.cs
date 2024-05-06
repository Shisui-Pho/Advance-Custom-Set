using System;
using System.Collections;
using System.Collections.Generic;


namespace SetLibrary.Collections
{
    internal class SortedSubSets<T> : IEnumerable<ISetTree<T>>
        where T : IComparable
    {
        private List<ISetTree<T>> _collection;
        public int Count => _collection.Count;
        public ISetTree<T> this[int index]
        {
            get
            {
                if (index < 0 || index >= _collection.Count)
                    throw new IndexOutOfRangeException();

                return _collection[index];
            }
        }//indexer
        public SortedSubSets()
        {
            this._collection = new List<ISetTree<T>>();
        }//ctor 02
        public SortedSubSets(IEnumerable<ISetTree<T>> subsets) : base()
        {
            foreach (var item in subsets)
            {
                Add(item);
            }//end for each
        }//ctor 02
        public void Add(ISetTree<T> value)
        {
            if (_collection.Count <= 0)
            {
                _collection.Add(value);
                return;
            }//end if collection is empty

            //Add an empty cell first at the end of the list

            _collection.Add(default(ISetTree<T>));

            int index = _collection.Count - 2;
            bool Comparer = _collection[index].Cardinality > value.Cardinality;
            while (Comparer && index >= 0)
            {
                _collection[index + 1] = _collection[index];
                index--;
                if (index < 0)
                    break;
                Comparer = _collection[index].Cardinality < value.Cardinality;
            }//end while
            _collection[++index] = value;
        }//AddSort
        public void RemoveAt(int index) => _collection.RemoveAt(index);
        public IEnumerator<ISetTree<T>> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }//
    }//namespace
}//namespace