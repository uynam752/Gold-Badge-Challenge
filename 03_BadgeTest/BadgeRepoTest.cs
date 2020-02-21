using System;
using System.Collections.Generic;
using _03_BadgeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgeTest
{
    [TestClass]
    public class BadgeRepoTest
    {
        [TestMethod]
        public void CreateNewBadge()
        {
            Badge badgeID = new Badge();
            BadgeRepo repository = new BadgeRepo();

            bool addResult = repository.AddNewBadgeToDictionary(badgeID);

            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void RetrieveNewBadge()
        {
            Badge badge = new Badge();
            badge.BadgeID = 5;
            BadgeRepo repository = new BadgeRepo();

            repository.AddNewBadgeToDictionary(badge);

            var badgeIDs = repository.DisplayAllBadges();

            bool badgeHasDoor = badgeIDs.ContainsKey(badge.BadgeID);
            Assert.IsTrue(badgeHasDoor);
        }

        private BadgeRepo _repo;
        private Badge _badge;

        [TestInitialize]

        public void Arrange()
        {
            _repo = new BadgeRepo();
            List<string> Doors = new List<string>
            {
                "A1", "A4", "A5", "A7", "B1", "B2"
            };
            _badge = new Badge(12345, Doors);
        }

        [TestMethod]
        public void DeleteNewBadge()
        {
            bool removeResult = _repo.DeleteADoor(12345,"A1");
        }
    }

}











/* users.Add("John Doe", 42);
users.Add("Jane Doe", 38);  
users.Add("Joe Doe", 12);  
users.Add("Jenna Doe", 12);

Console.WriteLine("John Doe is " + users["John Doe"] + " years old");*/