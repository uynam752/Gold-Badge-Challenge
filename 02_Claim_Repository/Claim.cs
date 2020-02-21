using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim_Repository
{
    public enum TypeOfClaim { car = 1, home, theft }
    public class Claim
    {
        public string ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string ClaimDescrip { get; set; }
        public string ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
    public Claim() { }
    public Claim(string claimID, TypeOfClaim claimType, string claimDescrip, string claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
    {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescrip = claimDescrip;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
    }
    }

}
