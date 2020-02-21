using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeRepository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> ListOfDoorName { get; set; }

        public Badge() { }

        public Badge(int badgeID, List<string> listOfDoorName)
        {
            BadgeID = badgeID;
            ListOfDoorName = listOfDoorName;
        }

        public override string ToString()
        {
            return $"{BadgeID}";
        }
    }
}
