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
                    "4. Exit application");

                //Get user input
                string input = Console.ReadLine();

                //Evaluate user input and act accordingly
                switch (input)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input (1-4).");
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
                
        }

        private void EditBadge()
        {

        }

        private void ViewAllBadges()
        {
            
            Console.WriteLine("All Badges");
            
            //Console.WriteLine("Badge # {0}, Door Access {1}", item.Key, item.Value);
                            
                Console.WriteLine("Press any key to return to the System Admin menu...");
            Console.ReadKey();
            Console.Clear();
            Menu();
                
        }

    }
}
