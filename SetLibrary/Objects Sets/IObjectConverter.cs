using System;
using SetLibrary.Generic;
namespace SetLibrary.Objects_Sets
{
    /// <summary>
    /// This interface defines specifies the convertion of a string to an objects of type T which can be used in the set
    /// </summary>
    /// <typeparam name="T">Object type that must also implement IComparable</typeparam>
    public interface IObjectConverter<T>
        where T : IComparable
    {
        /// <summary>
        /// Converts a string object to a specified object
        /// </summary>
        /// <param name="field">The string representation of the the object.</param>
        /// <param name="settings">The extaction of the object</param>
        /// <returns>Returns the converted objects as type T.</returns>
        T ToObject(string field, SetExtractionSettings<T> settings);
    }//class
}//namespace
