using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
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
        Mother GetMotherByID(string ID);
        Nanny GetNannyByID(string ID);
        int ContractDistance(Contract contract);
        List<Contract> GetContract();
        List<BankAccount> GetBankBranchs();
        List<Contract> GetContractByNanny(Nanny nanny);
        Child GetChildByID(string id);
        List<Nanny> AvailableNannys(Mother mother, Child child);
        Contract GetContractByID(int id);
        bool IsAvailableNanny(Mother mother, Nanny nanny);
        List<Nanny> DistanceNannys(Mother mother);
        List<Child> ChildsWithoutNannys();
        List<Nanny> NannysWithTMT();
        List<Contract> ContractWithCondition(Predicate<Contract> mycondition);
        int NumContractWithCondition(Predicate<Contract> mycondition);
        List<IGrouping<String, Nanny>> GroupNannysByRangeChildAge();
        List<IGrouping<String, Nanny>> GroupNannysByAddress();
        List<IGrouping<int, Contract>> GroupContractsByDistance();
        Contract GetContractByChild(Child child);


    }
}
