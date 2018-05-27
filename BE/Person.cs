using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //this clas represent a person and contain basic information about person
    public class Person
    {
        //properties in person
        public String ID { get; set; }
        public String Lastname { get; set; }
        public String FirstName { get; set; }
        public String Tel { get; set; }
        public Address address { get; set; }

        //ToString returns string with info about person
        public override string ToString()
        {
            string result = "";
            result += string.Format("First Name: {0}\n", FirstName);
            result += string.Format("Last name: {0}\n", Lastname);
            result += string.Format("ID: {0}\n", ID);
            result += string.Format("Phone number: {0}\n", Tel);
            result += string.Format("Address: {0}\n", address.ToString());
          
            return result;
        }
    }
}