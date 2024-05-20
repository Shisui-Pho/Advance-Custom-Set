using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetLibrary.Collections
{
    public class SetCollection<T> : ISetCollection<T>
        where T : IComparable
    {
        //Parallel  arrays that will hold the sets and their names
        private List<ICSet<T>> _sets;
        private List<string> _setNames;
        private int _count_sets;

        //Properties
        public IEnumerable<ICSet<T>> EnumerateCollection => _sets;
        public int Count => _sets.Count;

        //Indexer
        public ICSet<T> this[int index]
        {
            get
            {
                if (index < 0 || index >= _setNames.Count)
                    throw new IndexOutOfRangeException();
                return _sets[index];
            }
        }//end indexer

        //Constructor
        public SetCollection()
        {
            Clear();
        }//ctor
        public void Add(ICSet<T> item)
        {
            if(_count_sets == 0)
            {
                char n = (char)65;
                _sets.Add(item);
                _setNames.Add(n.ToString());
                _count_sets++;
                return;
            }//end if
            //The naming will be ASCII characters from 65 - 90
            //If we reach 90, we start over again and use two letters(Just like excel)

            //Check the last name in the collection
            //-This was will stop us from repeating names
            string name = _setNames[_count_sets - 1];
            string newname = NextName(name);

            //Add the set and name in the || arrays/lists
            _sets.Add(item);
            _setNames.Add(newname);
            _count_sets++;
        }//Add
        private string NextName(string name)
        {
            int count_value = 0;
            for(int i = 0; i < name.Length; i++)
            {
                count_value += name[i];
            }//end for

            //Building the nextString
            string newname = "";
            //-Our Bound is 90
            while(count_value > 90)
            {

                //Try to get the value to be between 65(A) and 90(Z)
                count_value-= 25;
                //Add the letterA to the name
                newname += "A";
            }//end while

            //Move to the next character
            count_value++;
            if (count_value >= 90)
                newname += "A";//Start of the loop
            else
                newname += (char)count_value;//Next character
            return newname;
        }//EvaluateName
        public void Clear()
        {
            _sets = new List<ICSet<T>>();
            _count_sets = 0;
            _setNames = new List<string>();
        }//Clear

        public IEnumerator<Set> GetEnumerator()
        {
            //Return the struct of the set
            for (int i = 0; i < _count_sets; i++)
                yield return new Set(_setNames[i], _sets[i].ElementString, _sets[i].Cardinality);
        }//GetCollectionEnumerator

        public void Remove(ICSet<T> item)
        {
            int index = _sets.IndexOf(item);
            RemoveAt(index);
        }//Remove

        public void Remove(string name)
        {
            int index = _setNames.IndexOf(name);
            RemoveAt(index);
        }//Remove
        public void RemoveAt(int index)
        {
            if (index < 0)
                return;
            //Remove the element from the || arrays
            _sets.RemoveAt(index);
            _setNames.RemoveAt(index);
            _count_sets--;
        }//RemoveAt

        public void ResetNaming()
        {
            //Here we reset the naming of the sets
            List<ICSet<T>> copy = this._sets;

            //Clear the collection
            Clear();

            //Re-add the set collection
            foreach (var item in copy)
                this.Add(item);
        }//ResetNaming
    }//class
}//namespace