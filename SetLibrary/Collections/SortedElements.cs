using System;
using System.Collections;
using System.Collections.Generic;
namespace SetLibrary.Collections
{
    public delegate int Compare<T>/*<in T>*/(T val);
    public class SortedElements<T> : ISortedElements<T>
        where T : IComparable
    { 
        //embeded lists
        private List<T> _collection;
        public int Count => _collection.Count;
        Element<T> ISortedSetCollection<T>.this[int index] 
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                T val = _collection[index];
                return new Element<T>(val);
            }//getter
        }//end indexer
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
        public void Add(T value)
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
        public bool Contains(T val) => this._collection.Contains(val);
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }//GetEnumerator

        public Element<T> FindElementByIndex(int index)
        {
            if (index > _collection.Count || index < 0)
                throw new IndexOutOfRangeException();
            var a = this._collection[index];

            Element<T> elem = new Element<T>(a, 0, true);
            return elem;
        }//FindElementByIndex
        public T Find(Predicate<T> predicate)
        {
            T val = default;
            int count = _collection.Count;
            for (int i = 0; i < count; i++)
                if (predicate(_collection[i]))
                    return _collection[i];
            return val;
        }//Find
        public T Find<Key>(Key key, string propertyName)
        {
            int left = 0;
            int right = this.Count;
            int mid = (left + right) / 2;
            bool isFound = false;
            T val = default;
            while (!isFound && left <= right)
            {
                int comparer = Compare(_collection[mid], key, propertyName);
                if (comparer < 0)
                    left = mid;
                else if (comparer > 0)
                    right = mid;
                else
                {
                    val = _collection[mid];
                    isFound = true;
                }
                mid = (left + right) / 2;
            }//end while

            return val;
        }//Find
        public T Find(Compare<T> compare)
        {
            int left = 0;
            int right = _collection.Count;
            int mid = (left + right) / 2;
            bool isFound = false;
            T val = default;
            while(!isFound && left <= right)
            {
                int compareValue = compare(_collection[mid]);
                if (compareValue < 0)
                    left = mid;
                else if (compareValue > 0)
                    right = mid;
                else
                {
                    isFound = true;
                    val = _collection[mid];
                }//end else
                mid = (left + right) / 2;
            }//end while

            return val;
        }//Find
        private object GetProperty(T item, string propName)
        {
            return item.GetType().GetProperty(propName).GetValue(item, null);
        } //GetProperty
        private int Compare<Key>(T x, Key key, string compareField)
        {
            IComparable propX = (IComparable)GetProperty(x, compareField);
            return propX.CompareTo(key);
        } //Compare
    }//class
}//namespace