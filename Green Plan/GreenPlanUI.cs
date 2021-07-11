using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Plan
{
    class GreenPlanUI
    {
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                Console.WriteLine("Insurance Agent menu.  What would you like to do?\n" +
                    "1. Create new car profile\n" +
                    "2. Update a car profile\n" +
                    "3. Delete a car profile\n" +
                    "4. View all car profiles\n" +
                    "5. Exit application");
                string menuInput = Console.ReadLine();
                switch (menuInput)
                {
                    case "1":
                        Console.Clear();
                        CreateCarProfile();
                        break;
                    case "2":
                        Console.Clear();
                        UpdateCarProfile();
                        break;
                    case "3":
                        Console.Clear();
                        DeleteCarProfile();
                        break;
                    case "4":
                        Console.Clear();
                        ListAllCarProfiles();
                        break;
                    case "5":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                }
            }
        }

        public void CreateCarProfile()
        {

        }

        public void UpdateCarProfile()
        {

        }

        public void DeleteCarProfile()
        {

        }

        public void ListAllCarProfiles()
        {

        }

    }
}
