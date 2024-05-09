using System;
using System.Collections;
using System.Collections.Generic;


namespace SetLibrary.Collections
{
    public class SortedSubSets<T> : ISortedSubSets<T>
        where T : IComparable
    {
        //private datamembers
        private List<ISetTree<T>> _collection;

        public int Count => _collection.Count;

        Element<T> ISortedSetCollection<T>.this[int index] => FindElementByIndex(index);

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
        }//ctor 01
        public SortedSubSets(IEnumerable<ISetTree<T>> subsets) : this()
        {
            this.AddRange(subsets);
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

            ////First do a cardinality check which will be faster if trees are not the same length
            //bool foundPointOfInsertion = _collection[index].Cardinality > value.Cardinality;

            ////If false check other posibilities
            //while (foundPointOfInsertion && index >= 0)
            //{
            //    _collection[index + 1] = _collection[index];
            //    index--;
            //    if (index < 0)
            //        break;
            //    foundPointOfInsertion = _collection[index].Cardinality < value.Cardinality;
            //}//end while
            bool insertionPositionNotFound;// = default;
            do
            {
                int cardinalNew = value.Cardinality;
                int cardinalExisting = _collection[index].Cardinality;
                insertionPositionNotFound = cardinalExisting < cardinalNew;
                if (cardinalNew == cardinalExisting)
                    insertionPositionNotFound = NewElementBeforeExistingElement(value, _collection[index]);

                if (insertionPositionNotFound)
                    break;

                //Move the items
                _collection[index + 1] = _collection[index];
                
                index--;

            } while (insertionPositionNotFound && index >= 0);

            _collection[++index] = value;
        }//AddSort
        private bool NewElementBeforeExistingElement(ISetTree<T> newTree, ISetTree<T> existing)
        {
            //If the new tree has less subsets than the existsing one then the new one comes before the existsing one 
            if (newTree.NumberOfSubsets < existing.NumberOfSubsets)
                return true;

            if (newTree.NumberOfSubsets > existing.NumberOfSubsets)
                return false;

            //Here it means they have the same number of elements and subset subsets

            //-If both of them have no subsets
            if(newTree.NumberOfSubsets == 0 && existing.NumberOfSubsets == 0)
            {
                bool foundCondition = true;
                int i = 0;
                int cardinality = newTree.Cardinality;
                while (foundCondition && i < cardinality)
                {
                    int compareVal = existing.GetRootElementByIndex(i).CompareTo(newTree.GetRootElementByIndex(i));
                    if (compareVal < 0)
                        return true;
                    if (compareVal > 0)
                        return false;
                    i++;
                }//end while
                return false;
            }//end if no subsets


            //-Compare the nesting levels of the first elements in the subtrees
            int levelNew = newTree[0].NestedLevel, levelExisting = existing[0].NestedLevel;
            if (levelNew > levelExisting)
                return false;
            if (levelExisting > levelNew)
                return true;

            //Here were dealing with nested subset
            for(int i =0; i < newTree.Cardinality; i++)
            {
                return NewElementBeforeExistingElement(newTree.GetSubSetElementByIndex(i), existing.GetSubSetElementByIndex(i));
            }
            return false;
        }//NewElementBeforeExistingElement
        public Element<T> FindElementByIndex(int index)
        {
            int nestingLevel = 0, currentIndex = 0;
            return FindElement(_collection[0],ref currentIndex, index, nestingLevel);
            //return new Element<T>(val, nestingLevel, nestingLevel == 1);
        }//FindByIndex
        private Element<T> FindElement(ISetTree<T> currentTree, ref int currentIndex, int index, int nestinglevel)
        {
            Element<T> element = default(Element<T>);
             var a = element.ElementFound == true;
            nestinglevel++;
            //First start with the root elements
            foreach (var item in currentTree.GetRootElementsEnumarator())
            {
                if (currentIndex == index)
                {
                    element = new Element<T>(item, nestinglevel, nestinglevel == 1);
                    return element;
                }
                //increase the current index
                currentIndex++;
            }//end root elements foreach

            foreach (var item in currentTree.GetSubsetsEnumarator())
            {
                element = FindElement(item, ref currentIndex, index, nestinglevel);
                
                if (currentIndex >= index && element.ElementFound)
                    return element;
            }//end for each
            return element;
        }//FindElement
        public int IndexOf(ISetTree<T> val) 
        {
            string set = val.ToString();
            int index = 0;
            foreach (var item in this)
            {
                if (item.ToString() == set)
                    return index;
                index++;
            }
            return -1;
        }//end index
        public bool Remove(ISetTree<T> val)
        {
            return this._collection.Remove(val);
        }//Remove
        public void RemoveAt(int index) => _collection.RemoveAt(index);
        public IEnumerator<ISetTree<T>> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }//end enumarator
        public bool Contains(ISetTree<T> val)
        {
            return this._collection.Contains(val);
        }//Contains
        public void AddRange(IEnumerable<ISetTree<T>> coll)
        {
            foreach (var item in coll)
            {
                this.Add(item);
            }
        }//AddRange
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }//GetEnumerator
    }//namespace
}//namespace