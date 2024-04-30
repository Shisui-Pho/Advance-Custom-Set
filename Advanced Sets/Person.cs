using System;
namespace Advanced_Sets
{
    public class Person : IEquatable<Person>, IComparable<Person>, IComparable
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }//ctor

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }//Equals

        public bool Equals(Person other)
        {
            return other != null &&
                   FirstName == other.FirstName &&
                   LastName == other.LastName;
        }//Equals

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + FirstName.GetHashCode();
                hash = hash * 23 + LastName.GetHashCode();
                return hash;
            }
        }
        public int CompareTo(Person other)
        {
            if (other == null)
                return 1;

            int lastNameComparison = LastName.CompareTo(other.LastName);
            if (lastNameComparison != 0)
                return lastNameComparison;

            return FirstName.CompareTo(other.FirstName);
        }//CompareTo

        public int CompareTo(object obj)
        {
            return this.CompareTo((Person)obj);
        }//CompareTo
    }//class
}//namespace
