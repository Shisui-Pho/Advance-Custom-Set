using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetLibrary
{
    public class FaildToExtractObjectException : Exception
    {
        string _msg;
        public override string Message => _msg;
        public FaildToExtractObjectException(string type, string msg) : base()
        {
            _msg = String.Format($"Failed to convert from string to {type}.");
        }
        public FaildToExtractObjectException(string message)
            : base(message)
        {
        }//

    }//class
}//namespace
