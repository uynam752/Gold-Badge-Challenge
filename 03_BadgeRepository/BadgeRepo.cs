using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeRepository
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, List<string>> _badgeList = new Dictionary<int, List<string>>();

        public bool AddNewBadgeToDictionary(Badge badge) //Badge - key, badge - value
        {
            int intialCount = _badgeList.Count();
            _badgeList.Add(badge.BadgeID, badge.ListOfDoorName);
            bool wasAdded = intialCount + 1 == _badgeList.Count();
            return wasAdded;
        }

        public Dictionary<int, List<string>> DisplayAllBadges()
        {
            return _badgeList;
        }

        public bool UpdateAddNewDoor(int badgeID, string newDoor)
        {
            List<string> oldDoor = DisplayAllBadges()[badgeID];
            oldDoor.Add(newDoor);
            bool wasAdded = oldDoor.Contains(newDoor);
            return wasAdded;
        }

        public bool DeleteADoor(int badgeID, string oldDoor)
        {
            List<string> newDoor = DisplayAllBadges()[badgeID];
            newDoor.Remove(oldDoor);
            bool deletedResult = newDoor.Remove(oldDoor);
            return deletedResult;
        }

    }

}

