using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //this class represent contract
    public class Contract
    {
        //define some properties for this class
        //static number for private use of functions in this class, help to determine contract ID
        private static int serialCounter = 10000000;  
        private int contractId;
        public int NumberOfContract //property for contractID field
        {
            get { return contractId; }
            set
            {
                contractId = value;
            }
        }
    
        public Contract()
        {
            NumberOfContract = ++serialCounter;
        }
        public string NunnyID { get; set; }
        public string MotherID{ get; set; }
        public string ChildID { get; set; }
        public bool IsInterview { get; set; }
        public bool IsContract { get; set; }
        public float RateforHour { get; set; }
        public float RateforMonth { get; set; }
        public bool IsMorechilds { get; set; }
        public Dictionary<DayOfWeek, KeyValuePair<int, int>> WorkTime { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public float HoursOfContractMonth { get; set; }

        //ToString returns string with info about the contract
        public override string ToString()
        {
            string result = "";
            result += string.Format("Number Of Contract:{0}\n", NumberOfContract);
            result += string.Format("Nunny ID:{0}\n", NunnyID);
            result += string.Format("Mother ID:{0}\n", MotherID);
            result += string.Format("Child ID:{0}\n", ChildID);
            result += string.Format("Was there Interview?{0}\n", IsInterview);
            result += string.Format("Rate for Hour: {0}\n", RateforHour);
            result += string.Format("Rate for Month: {0}\n", RateforMonth);
            result += string.Format("Is there any more children in the nunny? {0}\n", IsMorechilds);
            result += "Work Time:\n";
            foreach (var item in WorkTime)  //loop over days in week
            {
                result += "day: " + item.Key + "   \t";
                result += "hours " + ((((item.Value.Key) / 100) < 10) ? ("0") : (null)) + ((item.Value.Key) / 100);
                result += ":" + ((((item.Value.Key) % 100) < 10) ? "0" : (null)) + (item.Value.Key) % 100 + " - ";
                result += ((((item.Value.Value) / 100) < 10) ? ("0") : (null)) + (item.Value.Value) / 100;
                result += ":" + ((((item.Value.Value) % 100) < 10) ? "0" : (null)) + (item.Value.Value) % 100 + '\n';
            }
            result += string.Format("Date of Start:{0}\n", DateStart.ToShortDateString());
            result += string.Format("Date of End: {0}\n", DateEnd.ToShortDateString());
            result += string.Format("Hours Of Contract: {0}\n", HoursOfContractMonth);
            return result;
        }
    }
}