using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim_Repo
{
    public class ClaimRepo //this is what the developers (us) will see and manipulate
    {
        public Queue<Claim1> _claimRepo = new Queue<Claim1>();

        public Queue<Claim1> RetrieveAllClaims() //seeing/displaying all claims
        {
            return _claimRepo;
        }
                                        //take a look at the string Claim1
        public void DeleteExistingClaim(string claimID) //taking care of the next claim
        {
            _claimRepo.Dequeue();
        }

        public void AddNewClaim(Claim1 newClaim) //add new claims
        {
            _claimRepo.Enqueue(newClaim);
        }

        public bool ClaimIsValid(Claim1 claim) //this returns a bool to tell the validity of the claim
        {
            TimeSpan dateRange = claim.DateOfClaim.Subtract(claim.DateOfIncident);
            if (dateRange.Days <= 30)
            {
                return true;
            }
            return false;
        }

        public Claim1 ViewNextClaim() //this gives us a look at our next claim
        {
            return _claimRepo.Peek();
        }




















    }
}
