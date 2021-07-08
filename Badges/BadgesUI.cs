using System;
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

        }

        private void EditBadge()
        {

        }

        private void ViewAllBadges()
        {

        }

    }
}
