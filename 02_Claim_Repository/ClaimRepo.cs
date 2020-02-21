using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim_Repository
{
    public class ClaimRepo
    {
        public Queue<Claim> _claimQueue = new Queue<Claim>();

        public Queue<Claim> RetrieveAllClaims() //seeing/displaying all claims
        {
            return _claimQueue;
        }

        public void DeleteExistingClaim() //taking care of the next claim
        {
            _claimQueue.Dequeue();
        }
        
        public void AddNewClaim(Claim newClaim) //add new claims
        {
            _claimQueue.Enqueue(newClaim);
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
       





    }
}
