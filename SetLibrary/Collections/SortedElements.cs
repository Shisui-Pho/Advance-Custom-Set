using System;
using System.Collections;
using System.Collections.Generic;
namespace SetLibrary
{
    internal class SortedElements<T> : IEnumerable<T> where T : IComparable
    { 
        //embeded lists
        private List<T> _collection;

        public int Count => _collection.Count;
        public T this[int index]
        {
            get
            {
                if (index >= _collection.Count || index < 0)
                    throw new IndexOutOfRangeException();
                return _collection[index];
            }
        }//end indexer
        public SortedElements()
        {
            _collection = new List<T>();
        }//ctor main
        public SortedElements(IEnumerable<T> collection)
        {
            _collection = new List<T>();
            AddRange(collection);
        }//ctor 2
        public virtual void Add(T value)
        {
            if (_collection.Count <= 0)
            {
                _collection.Add(value);
                return;
            }//end if collection is empty

            //Add an empty cell first at the end of the list

            _collection.Add(default(T));
            int index = _collection.Count - 2;

            int Comparer = value.CompareTo(_collection[index]);
            while (Comparer < 0 && index >= 0)
            {
                _collection[index + 1] = _collection[index];
                index--;
                if (index < 0)
                    break;
                T tt = _collection[index];
                Comparer = value.CompareTo(tt);
            }
            _collection[++index] = value;
        }//Add
        public void AddRange(IEnumerable<T> coll)
        {
            foreach (var item in coll)
                Add(item);
        }//AddRange
        public int IndexOf(T val) => this._collection.IndexOf(val);
        public bool Remove(T val) => _collection.Remove(val);
        public void RemoveAt(int index) => _collection.RemoveAt(index);
        public IEnumerator<T> GetEnumerator()
        {
            return this._collection.GetEnumerator();
        }//GetEnumerator
        public virtual bool Contains(T val) => this._collection.Contains(val);
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }//GetEnumerator
    }//class
}//namespace