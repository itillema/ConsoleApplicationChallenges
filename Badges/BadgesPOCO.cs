using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    
    //Plain Old C# Object -- POCO
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorName { get; set; }
        public string BadgeName { get; set; }
        

        public Badge() { }

        public Badge(int badgeID, List<string> doorName, string badgeName)
        {
            DoorName = new List<string>();
            foreach (string door in doorName)
            {
                DoorName.Add(door);
            }

            BadgeID = badgeID;
            BadgeName = badgeName;


        }

        
    }
}
