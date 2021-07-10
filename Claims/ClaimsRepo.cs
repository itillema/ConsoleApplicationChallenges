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

        //Create new claims
        public void AddClaimContentToList(ClaimContent content)
        {
            _listOfClaimContent.Add(content);
        }

        //See all Claims
        public List<ClaimContent> GetClaimContents()
        {
            return _listOfClaimContent;
        }

        //Update list of claims in queued order
        

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
        private ClaimContent GetClaimContent(int claimID)
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
