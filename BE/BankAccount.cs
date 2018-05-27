using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //struct to represent BankAccount
    public struct BankAccount
    {
        //properties in BankAaccount
        public int BankNumber { get; set; }
        public String BankName { get; set; }
        public int BankBranch { get; set; }
        public string BankAdress { get; set; }
        //ToString returns string with the info about the account
        public override string ToString()
        {
            string result = "Bank Account details:\n";
            result += "---------------------\n";
            result += string.Format("Bank Number:{0}\n", BankNumber);
            result += string.Format("Bank Name:{0}\n", BankName);
            result += string.Format("Bank Branch:{0}\n", BankBranch);
            result += string.Format("Bank Adress:{0}\n", BankAdress);
            return result;
        }
    }
}
