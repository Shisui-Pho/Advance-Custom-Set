using SetLibrary.Generic;
using SetLibrary.Objects_Sets;
using System;
namespace Advanced_Sets
{
    public class Person : IObjectConverter<Person>, IComparable
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Person() { }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }//ctor

        public Person ToObject(string field, SetExtractionSettings<Person> settings)
        {
            string[] fields = field.Split(new string[] { settings.FieldTerminator }, StringSplitOptions.RemoveEmptyEntries);
            if (fields.Length > 2)
                throw new ArgumentException("Cannot convert to type of Person");
            return new Person(fields[0], fields[1]);
        }//ToObject

        public int CompareTo(object obj)
        {
            return this.FirstName.CompareTo(((Person)obj).FirstName);
        }//CompareTo
    }//class
}//namespace
#region Alternative but not working for all cases
/*
 ALT


        //public override bool Equals(object obj)
        //{
        //    return Equals(obj as Person);
        //}//Equals

        //public bool Equals(Person other)
        //{
        //    return other != null &&
        //           FirstName == other.FirstName &&
        //           LastName == other.LastName;
        //}//Equals

        //public override int GetHashCode()
        //{
        //    unchecked
        //    {
        //        int hash = 17;
        //        hash = hash * 23 + FirstName.GetHashCode();
        //        hash = hash * 23 + LastName.GetHashCode();
        //        return hash;
        //    }
        //}
        //public int CompareTo(Person other)
        //{
        //    if (other == null)
        //        return 1;

        //    int lastNameComparison = LastName.CompareTo(other.LastName);
        //    if (lastNameComparison != 0)
        //        return lastNameComparison;

        //    return FirstName.CompareTo(other.FirstName);
        //}//CompareTo

        //public int CompareTo(object obj)
        //{
        //    return this.CompareTo((Person)obj);
        //}//CompareTo
*/
#endregion