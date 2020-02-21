using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim_Repo
{
    public enum TypeOfClaim { car = 1, home, theft }
    public class Claim1
    {
    private decimal _ClaimAmount;
        public string ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string ClaimDescrip { get; set; }
        public decimal ClaimAmount
        {
            get { return _ClaimAmount; } //set { }
        }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim1() { }
        public Claim1(string claimID, TypeOfClaim claimType, string claimDescrip, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescrip = claimDescrip;
            SetPrice(claimAmount);
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public void SetPrice(decimal amount)
        { //this method is being used despite it being irrelevant because it is public
          //i'm doing this in order to satifsy the rubic needing a "field"
            _ClaimAmount = amount;

        }
    }
}
