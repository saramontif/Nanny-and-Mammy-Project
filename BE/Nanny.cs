using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny : Person
    {
        public DateTime NannyD_of_B { get; set; }
        public bool IsElevator { get; set; }
        public int YearsOfExperience { get; set; }
        public int MaxKids { get; set; }
        public int MinimunmAge { get; set; }
        public int MaximumAge { get; set; }
        public float RateforHour { get; set; }
        public float RateforMonth { get; set; }
        public Dictionary<DayOfWeek, KeyValuePair<int, int>> AvailableTime { get; set; }
        public bool IsBasedonTMTorEdu { get; set; }
        public string Recommendation { get; set; }
        public BankAccount NannyBank { get; set; }
        public int BankAccountNumber { get; set; }
        public override string ToString()
        {
            string result = "Nunny details:\n";
            result += "---------------------\n";
            result += base.ToString();
            result += string.Format("Date of birth: {0}\n", NannyD_of_B.ToShortDateString());
            result += string.Format("Years Of Experience: {0}\n", YearsOfExperience);
            result += string.Format("Number of maximum kids: {0}\n", MaxKids);
            result += string.Format("The minimum age of kids: {0}\n", MinimunmAge);
            result += string.Format("The maximum age of kids: {0}\n", MaximumAge);
            result += string.Format("Rate for Hour: {0}\n", RateforHour);
            result += string.Format("Rate for Month: {0}\n", RateforMonth);
            result += "Nunny's Available Time: \n";
            if (AvailableTime.Count != 0)
            {
                foreach (var item in AvailableTime)
                {
                    result += "day: " + item.Key + "   \t";
                    result += "hours " + ((((item.Value.Key) / 100) < 10) ? ("0") : (null)) + ((item.Value.Key) / 100);
                    result += ":" + ((((item.Value.Key) % 100) < 10) ? "0" : (null)) + (item.Value.Key) % 100 + " - ";
                    result += ((((item.Value.Value) / 100) < 10) ? ("0") : (null)) + (item.Value.Value) / 100;
                    result += ":" + ((((item.Value.Value) % 100) < 10) ? "0" : (null)) + (item.Value.Value) % 100 + '\n';
                }
            }
            result += string.Format("Is days off based on Tamat or Ministry of Education ?: {0}\n", IsBasedonTMTorEdu);
            result += string.Format("Is nanny have elevator? {0} \n", IsElevator);
            result += string.Format("Recommendation: {0}\n", Recommendation);
            result += string.Format("{0}\n", NannyBank.ToString());
            result += string.Format("Bank Account Number: {0}\n", BankAccountNumber);
            return result;
        }
    }
}
