using System;
namespace SetLibrary.Model
{
    /// <summary>
    /// This structure represents all root elements in the set including element in a subset in the root.
    /// </summary>
    /// <typeparam name="T"><typeparamref name="T"/></typeparam>
    public ref struct Element<T>
        where T : IComparable
    {
        /// <summary>
        /// Represents the element value in the set.
        /// </summary>
        public T Value { get; private set; }
        /// <summary>
        /// Let the user know if the element is in the root of the main set or not.
        /// </summary>
        public bool IsInRoot { get; private set; }
        /// <summary>
        /// Represents the level of nesting of the element within the main set.
        /// </summary>
        public int NestedLevel { get; private set; }
        //ctor main
        public Element(T value, bool isInRoot = true)
        {
            this.Value = value;
            this.IsInRoot = isInRoot;
            this.NestedLevel = 0;
        }//ctor main
        public Element(T value,int nestinglevel, bool isInRoot = true) 
            : this(value,isInRoot)
        {
            //Set the nesting level
            this.NestedLevel = nestinglevel;
        }//ctor main
    }//class
}//namespace
