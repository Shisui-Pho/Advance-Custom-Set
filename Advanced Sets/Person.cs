using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace Advanced_Sets
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }//class
}//namespace
