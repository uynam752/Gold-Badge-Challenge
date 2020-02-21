using System;
using System.Collections.Generic;
using _02_Claim_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimRepoTest
{
    [TestClass]
    public class ClaimTest1
    {
        [TestMethod]
        public void CreateANewClaim()
        {
            Claim1 claims = new Claim1();
            ClaimRepo repository = new ClaimRepo();

            bool addResult = repository.ClaimIsValid(claims);

            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void RetrieveClaim()
        {
            Claim1 claims = new Claim1();
            ClaimRepo repository = new ClaimRepo();

            repository.AddNewClaim(claims);

            Queue<Claim1> claim = repository.RetrieveAllClaims();

            bool getClaim = claim.Contains(claims);
            Assert.IsTrue(getClaim);
        }

        private ClaimRepo _ClaimQueue;
        private Claim1 _claim;

        [TestInitialize]

        public void Arrange()
        {
            _ClaimQueue = new ClaimRepo();
            Queue<Claim1> Claims = new Queue<Claim1>
            {

            }
        }

        [TestMethod]
        public void DeleteOldClaim() { }
        {
            bool removeResult = _ClaimQueue.DeleteExistingClaim();
        
        }

    }
}
