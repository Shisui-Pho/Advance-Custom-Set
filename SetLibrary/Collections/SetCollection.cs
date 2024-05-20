using System;
using System.Collections.Generic;
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

            //First get the last name in the array of names
            string name = _setNames[_count_sets - 1];

            //Now find the next name
            string newname = NextName(name);

            //Add the set and name in the || arrays/lists
            _sets.Add(item);
            _setNames.Add(newname);
            _count_sets++;
        }//Add
        private string NextName(string name)
        {
            //Stack that will hold the current characters of the name
            Stack<char> sValues = new Stack<char>();
            for (int i = 0; i < name.Length; i++)
            {
                //Add all characters to the statck
                sValues.Push(name[i]);
            }//edn for
            
            //variable to hold the newname following the current name
            string newname = "";

            //Get the last letter ascii value
            int current_char_ascii = sValues.Pop();

            if (sValues.Count == 0)//If we have one letter
            {
                //Move to the next character
                current_char_ascii++;
                if (current_char_ascii > 90)
                    return "AA";
                return ((char)current_char_ascii).ToString();
            }//end if we have a single character

            //The idea
            //--Here in the next lines of code we are considering names which are bigger that 'AA'
            //--So we first increament the last letter('A') to get the next name.ie. 'AA' --> 'AB'
            //--If we get a name 'AZ' and increament ('Z') we get '[' which is not correct, so the Idea is to round the new increament to
            //**              'A' and then Increament the next character ('A') thus 'AZ' --> 'BA'
            //--If we get to 'ZZ', note that if we increament 'Z' we get '[' but using the above approach we can get 'ZZ' --> '[A'
            //**                   which is not correct, so when we get that situation we make it <A's> with n+1 A's, ie. 'ZZ'--> 'AAA'
            //**                   After this then the algorithm continues....

            //Increament it to the next character
            current_char_ascii++; 

            //Check if we need to round to 'A' or not
            bool needs_rounding = (current_char_ascii > 90);

            //A stack that will hold the new character's in-order.
            Stack<char> sNewValues = new Stack<char>();
            do
            {
                //Rounding the character
                if(needs_rounding)
                {
                    //This means we're above Z
                    sNewValues.Push('A');//Push 'A' to the stack

                    //Pop the next character and round it (Rounding)
                    current_char_ascii = sValues.Pop();
                    current_char_ascii++; // Round the character by 1
                }//end if
                else
                {
                    //Else we don't need to do roundings
                    //-Just add the character as it is and pop the next character
                    sNewValues.Push((char)current_char_ascii);
                    current_char_ascii = sValues.Pop();
                }//end else

                //Check for rounding again
                needs_rounding = (current_char_ascii > 90);
            } while (sValues.Count > 0);
            //Add the last character

            //Check for rounding for the last character
            if (needs_rounding)
            {
                current_char_ascii++;
                needs_rounding = current_char_ascii > 90;//If we are greater than 90 after rounding
                if(!needs_rounding)
                    sNewValues.Push((char)++current_char_ascii);
                else
                {
                    //Start afresh with 'A...n+1'; 
                    int count = name.Length + 1;
                    sNewValues = new Stack<char>("".PadRight(count, 'A'));
                }//end else
            }//                
            else
                sNewValues.Push((char)current_char_ascii);

            while (sNewValues.Count > 0)
                newname += sNewValues.Pop();

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

        public void Reset()
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