using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public class Dal_imp : Idal
    {
          bool ExistNanny(Nanny FindNanny)
        {
            if (DataSource.Nannys == null)
                return false;
            else
                return DataSource.Nannys.Exists(n => n.ID == FindNanny.ID);
        }
        public void AddNanny(Nanny Newnanny)
        {
            if (ExistNanny(Newnanny))
            {
                throw new Exception("ERROR nunny is allready exist!! Please check your ID.");
            }
            DataSource.Nannys.Add(Newnanny.NannyDeepClone());
        }
        public void DeleteNanny(Nanny Newnanny)
        {
            Nanny Delete = null;
            Delete = DataSource.Nannys.Find(item => item.ID == Newnanny.ID);
            DataSource.Nannys.Remove(Delete);
        }
        public void UpdateNanny(Nanny Newnanny)
        {
            if (!ExistNanny(Newnanny))
            {
                throw new Exception("ERROR nunny doesnt exist!! Please check your ID.");
            }
            else
            {
                DeleteNanny(Newnanny);
                AddNanny(Newnanny);
            }
        }
        //----------------------------------------------//
        bool ExistMother(Mother newmother)
        {
            return DataSource.Mothers.Exists(n => n.ID == newmother.ID);
        }
        public void AddMother(Mother newmother)
        {
            if (ExistMother(newmother))
            {
                throw new Exception("ERROR mother is allready exist!! Please check your ID.");
            }
            DataSource.Mothers.Add(newmother.MotherDeepClone());
        }
        public void DeleteMother(Mother newmother)
        {
            Mother Delete = null;
            Delete = DataSource.Mothers.Find(item => item.ID == newmother.ID);
            DataSource.Mothers.Remove(Delete);
        }
        public void UpdateMother(Mother newmother)
        {
            if (!ExistMother(newmother))
            {
                throw new Exception("ERROR Mother doesnt exist!! Please check your ID.");
            }
            else
            {
                DeleteMother(newmother);
                AddMother(newmother);
            }
        }
        //-------------------------------------------//
        bool ExistChild(Child newchild)
        {
            return DataSource.Childs.Exists(n => n.ChildID == newchild.ChildID);
        }
        public void AddChild(Child newchild)
        {
            if (ExistChild(newchild))
            {
                throw new Exception("ERROR Child is allready exist!! Please check child ID.");
            }
            DataSource.Childs.Add(newchild.ChildDeepClone());
        }
        public void DeleteChild(Child newchild)
        {
            Child Delete = null;
            Delete = DataSource.Childs.Find(item => item.ChildID == newchild.ChildID);
            DataSource.Childs.Remove(Delete);
        }
        public void UpdateChild(Child newchild)
        {
            if (!ExistChild(newchild))
            {
                throw new Exception("ERROR Child doesnt exist!! Please check Child ID.");
            }
            else
            {
                DeleteChild(newchild);
                AddChild(newchild);
            }
        }
        //-----------------------------------------------//
        bool ExistContract(Contract newContract)
        {
            return DataSource.Contracts.Exists(n => n.NumberOfContract == newContract.NumberOfContract);
        }
        public void AddContract(Contract newcontract)
        {
            if (ExistContract(newcontract))
            {
                throw new Exception("ERROR Contract is allready exist!! Please check Number Of Contract.");
            }
            DataSource.Contracts.Add(newcontract.ContractDeepClone());
        }
        public void DeleteContract(Contract newcontract)
        {
            Contract Delete = null;
            Delete = DataSource.Contracts.Find(item => item.NumberOfContract == newcontract.NumberOfContract);
            DataSource.Contracts.Remove(Delete);
        }
        public void UpdateContract(Contract newcontract)
        {
            if (!ExistContract(newcontract))
            {
                //throw new Exception("ERROR Contract doesnt exist!! Please check Number Of Contract.");
            }
            else
            {
                DeleteContract(newcontract);
                AddContract(newcontract);
            }
        }
        //------------------------------------------//
        public List<Nanny> GetNannys()
        {
            return DS.DataSource.Nannys.Select(item => item.NannyDeepClone()).ToList();
        }
        public List<Mother> GetMothers()
        {
            return DS.DataSource.Mothers.Select(item => item.MotherDeepClone()).ToList();
        }
        public List<Child> GetChilds()
        {
            return DS.DataSource.Childs.Select(item => item.ChildDeepClone()).ToList();
        }
        public List<Child> GetChildsByMother(Mother mother)
        {
            IEnumerable<Child> query = (from item in DS.DataSource.Childs
                                        where item.MotherID == mother.ID
                                        select item.ChildDeepClone());
            return query.ToList();
        }
        public List<Contract> GetContract()
        {
            return DS.DataSource.Contracts.Select(item => item.ContractDeepClone()).ToList();
        }
        public List<BankAccount> GetBankBranchs()
        {
            List<BankAccount> BankBranchs = new List<BankAccount>();
            BankAccount b = new BankAccount
            {
                BankAdress = "jerusalem",
                BankBranch = 123,
                BankName = "mercantil",
                BankNumber = 19
            };
            BankBranchs.Add(b);
            return BankBranchs;
        }
    }
}