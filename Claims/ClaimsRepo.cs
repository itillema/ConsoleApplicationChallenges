using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimsRepo
    {
        private List<ClaimContent> _listOfClaimContent = new List<ClaimContent>();
        private Queue<ClaimContent> queue = new Queue<ClaimContent>();
        

        //Create new claims
        public void AddClaimContentToList(ClaimContent content)
        {
            
            _listOfClaimContent.Add(content);
            queue = new Queue<ClaimContent>(_listOfClaimContent);
        }

        //See all Claims / Read
        public List<ClaimContent> GetClaimContents()
        {
            return _listOfClaimContent;
        }

        public Queue<ClaimContent> NextClaimInQueue()
        {
            return queue;
        }
        

        //Update list of claims in queued order
        public bool UpdateClaimInfo(int originalContent, ClaimContent newContent)
        {
            ClaimContent oldContent = GetClaimContent(originalContent);
            if (oldContent != null)
            {
                oldContent.ClaimID = newContent.ClaimID;
                oldContent.ClaimType = newContent.ClaimType;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.DateOfClaim = newContent.DateOfClaim;
                oldContent.Description = newContent.Description;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                oldContent.IsValid = newContent.IsValid;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete claims of invalid
        public bool RemoveClaimContentFromList(int claimID)
        {
            ClaimContent content = GetClaimContent(claimID);

            if(content == null)
            {
                return false;
            }

            int initialCount = _listOfClaimContent.Count;
            _listOfClaimContent.Remove(content);

            if(initialCount > _listOfClaimContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Helper Method
        public ClaimContent GetClaimContent(int claimID)
        {
            foreach(ClaimContent content in _listOfClaimContent)
            {
                if(content.ClaimID == claimID)
                {
                    return content;
                }
            }

            return null;
        }

    }
}
