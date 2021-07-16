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
            bool keepRunning = true;
            while (keepRunning)
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
                        Console.Clear();
                        ViewAllClaims();
                        break;
                    case "2":
                        Console.Clear();
                        NextClaim();
                        break;
                    case "3":
                        Console.Clear();
                        CreateNewClaim();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void ViewAllClaims()
        {
            Console.WriteLine("To see claims, please add claims in the Claims Agent menu.");

            List<ClaimContent> viewClaimContent = _contentRepo.GetClaimContents();
            
            //figure out how to format correctly
            foreach (ClaimContent claimContent in viewClaimContent)
            {
                Console.WriteLine($"Claim ID {claimContent.ClaimID} Claim Type {claimContent.ClaimType} Description {claimContent.Description} Claim Amount {claimContent.ClaimAmount} Date of Incident {claimContent.DateOfIncident} Date of Claim {claimContent.DateOfClaim} Valid Claim? {claimContent.IsValid}");
                //Console.WriteLine("{0,-20} {1, 3} {0,-20:N1} {0:0.##} {0:d} {0:d} {%b}", claimContent.ClaimID, claimContent.ClaimType, claimContent.Description, claimContent.ClaimAmount, claimContent.DateOfIncident, claimContent.DateOfClaim, claimContent.IsValid);
            }

            Console.WriteLine("After viewing all current claims, choose one of the following:\n" +
                "1. Take care of next claim in queue\n" +
                "2. Return to the Claims Agent menu");
            string viewAllClaimsInput = Console.ReadLine();
            switch (viewAllClaimsInput)
            {
                case "1":
                    Console.Clear();
                    NextClaim();
                    break;
                case "2":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That was an invalid option.  Returning to Claims Agent menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }

        
        
        public void NextClaim()
        {
            //List<ClaimContent> viewLastClaimContent = _contentRepo.GetClaimContents();

            //Console.WriteLine(viewLastClaimContent.Last());

            Queue<ClaimContent> viewClaimContent = _contentRepo.NextClaimInQueue();
            var queue = new Queue<ClaimContent>(viewClaimContent);

            //figure out how to format correctly and get the last item

            foreach (ClaimContent claimContent in queue)
            {
                Console.WriteLine($"Claim ID {claimContent.ClaimID} \n" +
                    $"Claim Type {claimContent.ClaimType} \n" +
                    $"Description {claimContent.Description} \n" +
                    $"Claim Amount {claimContent.ClaimAmount} \n" +
                    $"Date of Incident {claimContent.DateOfIncident} \n" +
                    $"Date of Claim {claimContent.DateOfClaim} \n" +
                    $"Valid Claim? {claimContent.IsValid}");
            }

            Console.WriteLine("Would you like to delete this claim?\n" +
                "1. Yes\n" +
                "2. No, take me back to the Claims Agent menu");

            string nextClaimInput = Console.ReadLine();
            switch (nextClaimInput)
            {
                case "1":
                    //Figure out how to delete
                    string deleteInput = Console.ReadLine();
                    int deleteInputAsInt = int.Parse(deleteInput);

                    //call delete method
                    bool wasDeleted = _contentRepo.RemoveClaimContentFromList(deleteInputAsInt);

                    // if content was deleted, say so
                    // otherwise state it could not be deleted
                    if (wasDeleted)
                    {
                        Console.WriteLine("The car profile was successfully deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, the car name was not found and the car profile could not be deleted.");
                    }
                    break;
                case "2":
                    Menu();
                    break;
                default:
                    Console.WriteLine("That was an invalid choice.  I'm going to take that as a no, and just bring you back to the Claims Agent Menu");
                    Menu();
                    break;
            }
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
            Console.WriteLine("Enter Date of Incident in [YYYY,MM,DD] format: ");
            string incidentDate = Console.ReadLine();
            newClaimContent.DateOfIncident = DateTime.Parse(incidentDate);

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

            Console.WriteLine("New cLaim created! Would you like to:\n" +
                "1. Create another new claim\n" +
                "2. Take care of next claim in queue\n" +
                "3. Return to Claims Agent menu");
            string newClaimInput = Console.ReadLine();
            switch (newClaimInput)
            {
                case "1":
                    Console.Clear();
                    CreateNewClaim();
                    break;
                case "2":
                    Console.Clear();
                    NextClaim();
                    break;
                case "3":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("That was an invalid option.  Returning to Claims Agent menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }
            

        
    }
}
