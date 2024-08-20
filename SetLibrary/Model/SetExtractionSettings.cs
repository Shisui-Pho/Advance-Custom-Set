using System;
using System.Collections.Generic;
using System.Linq;
namespace SetLibrary
{
    public class SetExtractionSettings<T>
        where T : IComparable
    {
        public string ElementSeperator { get; private set; }
        public string FieldTerminator { get; private set; }
        public T PlaceHolder { get;private set; }
        public SetExtractionSettings(string _seperator)
        {
            ElementSeperator = _seperator;
            FieldTerminator = " ";
        }//ctor main
        public SetExtractionSettings(string _elementSperator, string _fieldTerminator, T placeHolder)
            : this(_elementSperator)
        {
            FieldTerminator = _fieldTerminator;
            PlaceHolder = placeHolder;
        }//namespace
    }//class
}//namespace
