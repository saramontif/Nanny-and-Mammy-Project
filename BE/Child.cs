using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //this class represent a child
    public class Child
    {
        //properties of child
        public string ChildID { get; set; }
        public string MotherID { get; set; }
        public string ChildName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSpacialNeeds { get; set; }

        //ToString, returns info about the childs
        public override string ToString()
        {
            string result = "";
            result += string.Format("Child ID: {0}\n", ChildID);
            result += string.Format("Mother ID: {0}\n", MotherID);
            result += string.Format("Child Name: {0}\n", ChildName);
            result += string.Format("Date Of Birth: {0}\n", DateOfBirth.ToShortDateString());
            result += string.Format("Is child with Spacial Needs? {0}\n", IsSpacialNeeds);
            return result;
        }
    }
}
