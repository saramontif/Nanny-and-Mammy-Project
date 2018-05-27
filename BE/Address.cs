using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //struct to represent Address
    public struct Address
    {
        //properties
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        //ToString
        public override string ToString()
        {
            if (City == null || City == "")
                return "";
            string result = " ";
            result += Street + " ";
            result += Number + ",";
            result += City + ",";
            result += Country;
            return result;

        }
    }
}
