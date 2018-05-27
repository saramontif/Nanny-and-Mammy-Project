using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
    {
        void AddNanny(Nanny Newnanny);
        void DeleteNanny(Nanny Newnanny);
        void UpdateNanny(Nanny Newnanny);
        //
        void AddMother(Mother newmother);
        void DeleteMother(Mother newmother);
        void UpdateMother(Mother newmother);
        //
        void AddChild(Child newchild);
        void DeleteChild(Child newchild);
        void UpdateChild(Child newchild);
        //
        void AddContract(Contract newcontract);
        void DeleteContract(Contract newcontract);
        void UpdateContract(Contract newcontract);
        //
        List<Nanny> GetNannys();
        List<Mother> GetMothers();
        List<Child> GetChilds();
        List<Child> GetChildsByMother(Mother mother);
        List<Contract> GetContract();
        List<BankAccount> GetBankBranchs();
    }
}