using System;
using Badges;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    //CRUD
    public class BadgeRepo
    {
        private List<Badge> _listOfBadgeInfo = new List<Badge>();
        public Dictionary<int, Badge> badgeDict = new Dictionary<int, Badge>();
        public Dictionary<string, int> badgeLUT = new Dictionary<string, int>();

        //Create New Badge
        public void AddBadgeInfo(Badge badgeInfo) //Method
        {
            badgeDict.Add(badgeInfo.BadgeID, badgeInfo);
            badgeLUT.Add(badgeInfo.BadgeName, badgeInfo.BadgeID);
        }

        // public/private/protected return_type functionName(parameters)
        //Read or Pull
        
        public List<Badge> GetBadgeInfo()
        {
            //foreach (KeyValuePair<int, Badge> item in badgeDict)
            //{
                //badges.Add(item.Value);
            //};
            return _listOfBadgeInfo;
        }

        private Badge GetBadgeInfoByName(string name)
        {
            int nameId;
            try
            {
                nameId = badgeLUT[name];
                return badgeDict[nameId];
            }
            catch
            {
                return null;
            }
        }

        //Update


        public bool UpdateExistingInfo(string originalName, string doorInfo, bool Remove)
        {
            //find info
            
            Badge oldInfo = GetBadgeInfo(originalName);

            //update info
            

            if (oldInfo == null)
            {

                return false;
            }
            switch (Remove)
            {
                case true:
                    return oldInfo.DoorName.Remove(doorInfo);
                case false:
                    oldInfo.DoorName.Add(doorInfo);
                    return true;
                default:
                    return false;
            }

        }

        //Delete
        public bool RemoveAllDoorInfoFromList(string name)
        {
            Badge badgeInfo = GetBadgeInfoByName(name);

            if(badgeInfo == null)
            {
                return false;
            }

            badgeInfo.DoorName.Clear();
            return true;

        }

        //Helper Method
        private Badge GetInfoByName(string name)
        {
            foreach(Badge badgeInfo in _listOfBadgeInfo)
            {
                if(badgeInfo.BadgeName == name)
                {
                    return badgeInfo;
                }
            }
            return null;
        }
    }
}
