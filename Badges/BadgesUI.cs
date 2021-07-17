using System;
using Badges;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    class BadgesUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        public void Run()
        {
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //Display options to user
                Console.WriteLine("Hello System Admin.  What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Delete all doors from a badge\n" +
                    "5. Exit application");

                //Get user input
                string input = Console.ReadLine();

                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        CreateNewBadge();
                        break;
                    case "2":
                        Console.Clear();
                        EditBadge();
                        break;
                    case "3":
                        Console.Clear();
                        ViewAllBadges();
                        break;
                    case "4":
                        Console.Clear();
                        DeleteDoors();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        Console.Clear();
                        keepRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid input (1-4).");
                        Menu();
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewBadge()
        {
            Badge badgeInfo = new Badge();

            //Badge Name
            Console.WriteLine("Input the new badge name: ");
            badgeInfo.BadgeName = Console.ReadLine();

            //Badge Number/ID
            Console.WriteLine("Input the new badge number/ID: ");
            string stringBadgeNumber = Console.ReadLine();
            int intBadgeNumber = int.Parse(stringBadgeNumber);
            badgeInfo.BadgeID = intBadgeNumber;
            AddDoorsMenu();

            void AddDoorsMenu()
            {
                //Accessable doors
                Console.WriteLine("List a door that this badge will have access to: ");

                //find and add door info
                string doorInput = Console.ReadLine();
                badgeInfo.DoorName.Add(doorInput);
                
                Console.WriteLine("Would you like to:\n" +
                    "1. Add another door to this badge?\n" +
                    "2. Return to the System Admin menu?");
                string addAnotherDoorInput = Console.ReadLine();
                switch (addAnotherDoorInput)
                {
                    case "1":
                        Console.Clear();
                        AddDoorsMenu();
                        break;
                    case "2":
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        break;
                }
                
            }
            Console.WriteLine("Now that you're finished, what would you like to do?\n" +
                "1. Create another badge\n" +
                "2. Return to the System Admin menu");
            string createDoorInput = Console.ReadLine();
            switch (createDoorInput)
            {
                case "1":
                    Console.Clear();
                    CreateNewBadge();
                    break;
                case "2":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Not sure what you meant by that input, so we're going back to the System Admin menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
                
        }

        private void EditBadge()
        {
            List<Badge> listOfAllBadges = _badgeRepo.GetBadgeInfo();
            foreach (Badge badgeInfo in listOfAllBadges)
            {
                Console.WriteLine($"Badge Name: {badgeInfo.BadgeName} \n" +
                    $"BadgeID: {badgeInfo.BadgeID}\n" +
                    $"Doors: {badgeInfo.DoorName}\n" +
                    $"......");
            }

            Console.WriteLine("Enter the name of the badge you would like to update:");

            string updateInput = Console.ReadLine();

            Badge newBadgeInfo = new Badge();

            bool moreDoors = true;
            while (moreDoors)
            {


                //Accessable doors
                Console.WriteLine("List a door that this badge will have access to: ");

                //find and add door info
                string newBadgeInfoString = Console.ReadLine();
                newBadgeInfoString = string.Join(",", newBadgeInfo.DoorName.ToArray());
                
                

                Console.WriteLine("Would you like to:\n" +
                    "1. Add another door to this badge?\n" +
                    "2. Return to the System Admin menu?");
                string addAnotherDoorInput = Console.ReadLine();
                switch (addAnotherDoorInput)
                {
                    case "1":
                        Console.Clear();

                        break;
                    case "2":
                        Console.Clear();
                        moreDoors = false;
                        Menu();
                        break;
                    default:
                        Console.Clear();
                        moreDoors = false;
                        Menu();
                        break;
                }
            }
        }
        private void ViewAllBadges()
        {
            //I should be able to view the dictionary exactly how I have it in the Repo, but the method

            Console.WriteLine("All Badges");
            List<Badge> listOfAllBadges = _badgeRepo.GetBadgeInfo(); 
            foreach(Badge badgeInfo in listOfAllBadges)
            {
                Console.WriteLine($"BadgeID: {badgeInfo.BadgeID}\n" +
                    $"Doors: {badgeInfo.DoorName}");
            }

            Console.WriteLine("Now that you're finished, what would you like to do?\n" +
                "1. Create another badge\n" +
                "2. Return to the System Admin menu");
            string createDoorInput = Console.ReadLine();
            switch (createDoorInput)
            {
                case "1":
                    Console.Clear();
                    CreateNewBadge();
                    break;
                case "2":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Not sure what you meant by that input, so we're going back to the System Admin menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }

        }

        private void DeleteDoors()
        {
            List<Badge> listOfAllBadges = _badgeRepo.GetBadgeInfo();
            foreach (Badge badgeInfo in listOfAllBadges)
            {
                Console.WriteLine($"Doors: {badgeInfo.DoorName}");
            }

            Console.WriteLine("\nEnter the badge number of the badge you would like to remove:");

            string deleteInput = Console.ReadLine();
            
            bool wasDeleted = _badgeRepo.RemoveAllDoorInfoFromList(deleteInput);

            if (wasDeleted)
            {
                Console.WriteLine("The doors have been successfully successfully deleted.");
            }
            else
            {
                Console.WriteLine("The door could not be deleted.");
            }

            Console.WriteLine("Now that you're finished, what would you like to do?\n" +
                "1. Update a badge\n" +
                "2. Return to the System Admin menu");
            string createDoorInput = Console.ReadLine();
            switch (createDoorInput)
            {
                case "1":
                    Console.Clear();
                    EditBadge();
                    break;
                case "2":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Not sure what you meant by that input, so we're going back to the System Admin menu.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }
    }
}
