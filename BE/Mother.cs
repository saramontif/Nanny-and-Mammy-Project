using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //class mother inherits from person and add uniqe info for mother
    public class Mother : Person
    {
        //properties
        public String HomePhone { get; set; }
        public Address BabbySitterAdress { get; set; }

        //dictionary, the key-day of the week, the value-contain key and value for start, end hours
        public Dictionary<DayOfWeek, KeyValuePair<int, int>> Workhours { get; set; }  
        public bool MonthPayment{ get; set; }

        //ToString returns string with info about mother
        public override string ToString()
        {
            string result = base.ToString();
            result += (HomePhone != null) ? "Phone of home: " + HomePhone + '\n' : "";
            result += (BabbySitterAdress.Street != (" ") &&  BabbySitterAdress.Street != null) ? ("Required place: " + BabbySitterAdress.ToString() + "\n" ): "";
            result += "Required Work hours:\n";
            foreach (var item in Workhours)
            {
                result += "day: " + item.Key + "   \t";
                result += "hours " + ((((item.Value.Key) / 100) < 10) ? ("0") : (null)) + ((item.Value.Key) / 100);
                result += ":" + ((((item.Value.Key) % 100) < 10) ? "0" : (null)) + (item.Value.Key) % 100 + " - ";
                result += ((((item.Value.Value) / 100) < 10) ? ("0") : (null)) + (item.Value.Value) / 100;
                result += ":" + ((((item.Value.Value) % 100) < 10) ? "0" : (null)) + (item.Value.Value) % 100 + '\n';
            }
            result += "Is Weekly payment? " + MonthPayment;
            return result;
        }
    }
}
