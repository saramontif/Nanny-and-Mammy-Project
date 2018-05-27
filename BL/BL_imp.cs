using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DS;

using GoogleMapsApi;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi.Entities.Elevation.Request;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using GoogleMapsApi.StaticMaps;
using GoogleMapsApi.StaticMaps.Entities;

namespace BL
{
    public class BL_imp : IBL
    {
        public void AddChild(Child newchild)
        {
            //call DAL for action
            Idal mydal = FactoryDal.getDal();
            mydal.AddChild(newchild);
        }

        public void AddContract(Contract newcontract)
        {
            //check if nanny exist in DataSource
            //if (!(DataSource.Nannys.Exists(n => n.ID == newcontract.NunnyID)))
            //{
            //    throw new Exception("Nanny doesnt exist");
            //}
            //check if mother exist in DataSource
            //if (!DataSource.Mothers.Exists(n => n.ID == newcontract.MotherID))
            //{
            //    throw new Exception("Mother doesnt exist");
            //}
            ////check if child exist in DataSource
            //if (!DataSource.Childs.Exists(n => n.ChildID == newcontract.ChildID))
            //{
            //    throw new Exception("child doesnt exist");
            //}
            //check if the child adult enough
            Child child = GetChilds().Find(n => n.ChildID == newcontract.ChildID);
            if ((DateTime.Now.Month - child.DateOfBirth.Month) + 12 * (DateTime.Now.Year - child.DateOfBirth.Year) < 3)
            {
                throw new Exception("Child too young");
            }
            //check if the nanny not full
            Nanny nanny = GetNannys().Find(n => n.ID == newcontract.NunnyID);
            int numcontract = GetContract().FindAll(n => n.NunnyID == newcontract.NunnyID).Count;
            Contract existContract=GetContractByChild(child);
            if (existContract != null && existContract.NunnyID == newcontract.NunnyID)
                throw new Exception("this child already have a contract with this nanny");
            if (numcontract == nanny.MaxKids)
                throw new Exception("this nanny is full");
            if (newcontract.IsMorechilds)
            {
                newcontract.RateforMonth = (float)0.98 * (newcontract.RateforMonth);
                newcontract.RateforHour = (float)0.98 * (newcontract.RateforHour);
            }
            Idal mydal = FactoryDal.getDal();  //send to DAL
            mydal.AddContract(newcontract);
        }

        public void AddMother(Mother newmother)
        {
            Idal mydal = FactoryDal.getDal();  //send to layer layer DAL
            mydal.AddMother(newmother);
        }

        public void AddNanny(Nanny nanny)
        {
            //logical actions
            if ((DateTime.Now.Year - nanny.NannyD_of_B.Year) < 18)
            {
                throw new Exception("We do not work with nannies under the age of 18");
            }
            //call DAL for action
            Idal mydal = FactoryDal.getDal();
            mydal.AddNanny(nanny);
        }

        public bool IsAvailableNanny(Mother mother, Nanny nanny)
        {
            //for each day in week check if the hours good for the mother
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                if (day != DayOfWeek.Saturday)
                {
                    //key:start work hours, value: end work hours
                    if (nanny.AvailableTime[day].Key > mother.Workhours[day].Key && nanny.AvailableTime[day].Value < mother.Workhours[day].Value)
                    {
                        return false;
                    }
                }
            };
            return true;
        }

        public List<Nanny> AvailableNannys(Mother mother, Child child)
        {
            //return list of nannys that suits to mother by
            int childage= ((DateTime.Now - child.DateOfBirth).Days)/30;
            List<Nanny> availableNannys = GetNannys().FindAll(n => IsAvailableNanny(mother, n)&&(childage>n.MinimunmAge) && (childage<n.MaximumAge)).ToList();
            return availableNannys;
        }

        public List<Child> ChildsWithoutNannys()
        {
            //get over all childs and find all of them that dont have nannys(/contract)
            //for each child get over all contracts and add to list if didnt find one
            List<Child> childWithoutNanny = GetChilds().FindAll(n => !GetContract().Exists(x => x.ChildID==n.ChildID)).ToList();
            return childWithoutNanny;
        }

        public List<Contract> ContractWithCondition(Predicate<Contract>  mycondition)
        {
            //return all contracts that stand in the condition (bool)
            List<Contract> contractWithCondition = GetContract().FindAll(n=>mycondition(n)).ToList();
            return contractWithCondition;
        }

        public int NumContractWithCondition(Predicate<Contract> condition)
        {
            //return number of contract that stand in the condition
            //send to func that find all contract with condition
            List<Contract> contractWithCondition = ContractWithCondition(condition);
            return contractWithCondition.Count();
        }

        public Contract GetContractByChild(Child child)
        {
            // find contract with this child if exist
            Contract mycontract = GetContract().Find(n => child.ChildID==n.ChildID); 
            return mycontract;
        }

        public void DeleteChild(Child newchild)
        {
            Contract contract = GetContractByChild(newchild);
            if (contract!= null)
                DeleteContract(contract);  //delete the contract with this child, if exist
            Idal mydal = FactoryDal.getDal();
            mydal.DeleteChild(newchild);  //send to lower layer DAL
        }

        public void DeleteContract(Contract newcontract)
        {
            Idal mydal = FactoryDal.getDal();
            mydal.DeleteContract(newcontract);  //send to lower layer DAL        
        }

        public void DeleteMother(Mother newmother)
        {
            List<Child> ChildsByMother = GetChildsByMother(newmother);  //get all childs of this mother
            foreach(Child child in ChildsByMother)   //delete all childs (and their contracts)
            {
                DeleteChild(child);
            }
            Idal mydal = FactoryDal.getDal();
            mydal.DeleteMother(newmother);  //send to lower layer DAL  
        }

        public List<Contract> GetContractByNanny(Nanny nanny)
        {
            List<Contract> ContractByNanny = GetContract().FindAll(n => n.NunnyID == nanny.ID).ToList();
            return ContractByNanny;
        }

        public void DeleteNanny(Nanny Newnanny)
        {
            List<Contract> ContractOfNanny = GetContractByNanny(Newnanny);
            foreach (Contract contract in ContractOfNanny)   //delete all contracts of this nanny
            {
                DeleteContract(contract);
            }
            Idal mydal = FactoryDal.getDal();
            mydal.DeleteNanny(Newnanny);  //send to lower layer DAL 
        }

        public List<Nanny> DistanceNannys(Mother mother)//this function find all the nannys with distans of 1 KM from mammy
        {
            List<Nanny> distanceNannys = new List<Nanny>();
            foreach (Nanny nanny in GetNannys())
            {
                string motherAddress = mother.BabbySitterAdress.ToString();
                if (motherAddress == null || motherAddress=="")
                {
                    motherAddress = mother.address.ToString();
                }
                var walkingDirectionRequest = new DirectionsRequest
                {
                    TravelMode = TravelMode.Walking,                     
                    Origin = motherAddress,
                    Destination = nanny.address.ToString()
                };
                DirectionsResponse walkingDirections = GoogleMaps.Directions.Query(walkingDirectionRequest);
                Route route = walkingDirections.Routes.First();
                Leg leg = route.Legs.First();
                if (leg.Distance.Value<500)
                {
                    distanceNannys.Add(nanny);   
                }
            }
            return distanceNannys;
        }

        public List<BankAccount> GetBankBranchs()
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetBankBranchs();
        }

        public List<Child> GetChilds()
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetChilds();
        }

        public List<Child> GetChildsByMother(Mother mother)
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetChildsByMother(mother);
        }

        public List<Contract> GetContract()
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetContract();
        }

        public List<Mother> GetMothers()
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetMothers();
        }

        public List<Nanny> GetNannys()
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetNannys();
        }

        public Mother GetMotherByID(string ID)//Get Mother By ID
        {
            Mother mother = GetMothers().Find(x => x.ID == ID);
            return mother;
        }

        public Nanny GetNannyByID(string ID)//Get Nanny By ID  
        {
            Nanny nanny =GetNannys().Find(x => x.ID == ID);
            return nanny;
        }

        public int ContractDistance(Contract contract)//get distance by contract from mother to the nanny
        {
            string motherAddress = GetMotherByID(contract.MotherID).BabbySitterAdress.ToString();
            if (motherAddress == null || motherAddress=="")
            {
                motherAddress = GetMotherByID(contract.MotherID).address.ToString();
            }
            var walkingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = motherAddress,
                Destination = GetNannyByID(contract.NunnyID).address.ToString()
            };
            DirectionsResponse walkingDirections = GoogleMaps.Directions.Query(walkingDirectionRequest);
            Route route = walkingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

        public List<IGrouping<int, Contract>> GroupContractsByDistance()//Group the Contracts By Distance from mother to nanny
        {
            IEnumerable<IGrouping<int, Contract>> ContractsByDistance = from Contract contract in GetContract()
                                                                        group contract by (ContractDistance(contract));
        
            return ContractsByDistance.ToList();
        }

        public List<IGrouping<String, Nanny>> GroupNannysByAddress()//group the nannys by city
        {
            IEnumerable<IGrouping<String, Nanny>> NannysByAddress = from nanny in GetNannys()
                                                                          group nanny by (nanny.address.City);
            return NannysByAddress.ToList();
        }

        public List<IGrouping<String, Nanny>> GroupNannysByRangeChildAge()//group the nunny by range of ages
        {
            IEnumerable<IGrouping<String, Nanny>> NannysByRangeChildAge = from nanny in  GetNannys()
                                                           group nanny by (String)(nanny.MinimunmAge+"-"+nanny.MaximumAge);
            return NannysByRangeChildAge.ToList();
        }

        public List<Nanny> NannysWithTMT()//return all nannys that based on TMT
        {
            List<Nanny> NannysTMT = GetNannys().FindAll(n => n.IsBasedonTMTorEdu == true).ToList();
            return NannysTMT;
        }

        public void UpdateChild(Child newchild)
        {
            Idal mydal = FactoryDal.getDal();
            mydal.UpdateChild(newchild);
        }

        public void UpdateContract(Contract newcontract)
        {
            Idal mydal = FactoryDal.getDal();
            mydal.UpdateContract(newcontract);
        }

        public void UpdateMother(Mother newmother)
        {
            Idal mydal = FactoryDal.getDal();
            mydal.UpdateMother(newmother);
        }

        public void UpdateNanny(Nanny Newnanny)
        {
            Idal mydal = FactoryDal.getDal();
            mydal.UpdateNanny(Newnanny);
        }

        public Child GetChildByID(string id)
        {
            Child child = new Child();
            child=GetChilds().Find(x => x.ChildID == id);
            return child;
        }

        public Contract GetContractByID(int id)
        {
            Contract contract = GetContract().Find(x => x.NumberOfContract == id);
            return contract;
        }
    }
}
