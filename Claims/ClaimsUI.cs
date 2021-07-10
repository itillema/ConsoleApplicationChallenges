using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    class ClaimsUI
    {
        private ClaimsRepo _contentRepo = new ClaimsRepo();
        public void Run()
        {
            Menu();
        }

        public void Menu()
        {

            //Claims Agent Menu
            //1. See all Claims
            //2. Take care of next queued claim
            //3. Enter a new claim
            Console.WriteLine("Welcome Claims Agent.  What would you like to do?  Please choose one of the following items:\n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n" +
                "4. Exit application");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ViewAllClaims();
                    break;
                case "2":
                    NextClaim();
                    break;
                case "3":
                    CreateNewClaim();
                    break;
                case "4":
                    
                    break;
                default:
                    break;
            }
        }
        public void ViewAllClaims()
        {

        }

        public void NextClaim()
        {

        }

        public void CreateNewClaim()
        {
            ClaimContent newClaimContent = new ClaimContent();

            //Claim ID
            Console.WriteLine("Enter new ClaimID: ");
            string claimIdAsString = Console.ReadLine();
            newClaimContent.ClaimID = int.Parse(claimIdAsString);

            //Claim type
            Console.WriteLine("Enter new ClaimType:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft ");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaimContent.ClaimType = (ClaimType)claimTypeAsInt;

            //Description
            Console.WriteLine("Enter new Claim Description: ");
            newClaimContent.Description = Console.ReadLine();

            //ClaimAmount
            Console.WriteLine("Enter new Claim Amount (Do not use dollar sign [$]): ");
            string claimAmountAsString = Console.ReadLine();
            newClaimContent.ClaimAmount = decimal.Parse(claimAmountAsString);

            //Date Of Incident
            Console.WriteLine("Enter Date of Incident: ");

            //Date of Claim
            DateTime today = DateTime.Today;
            Console.WriteLine($"Date of Claim: {today}" );
            newClaimContent.DateOfClaim = today;

            //Isvalid
            Console.WriteLine("Is the new claim valid? (Y/N) ");
            string validAsString = Console.ReadLine().ToLower();

            if(validAsString == "y")
            {
                newClaimContent.IsValid = true;
            }
            else
            {
                newClaimContent.IsValid = false;
            }

            _contentRepo.AddClaimContentToList(newClaimContent);
            
        }
            

        
    }
}
