using System;
using System.Collections.Generic;
using System.Linq;
namespace SetLibrary.Generic
{
    public class SetExtractionSettings<T>
        where T : IComparable
    {
        public string Seperator { get; private set; }
        public SetExtractionSettings(string _seperator)
        {
            Seperator = _seperator;
        }//ctor main
    }//class
}//namespace
