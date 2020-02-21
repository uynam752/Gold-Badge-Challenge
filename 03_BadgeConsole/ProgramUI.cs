using _03_BadgeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgeConsole
{
    class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            SeedBadge();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Select an option number:\n" +
                    "1. Display a list of badge number and door access:\n" +
                    "2. Create a new badge:\n" +
                    "3. Update a door to an existing badge:\n" +
                    "4. Delete a door to an existing badge:\n" +
                    "5. Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                        DisplayAllBadges(); //this is the retrieve/get part of CRUD
                        break;
                    case "2":
                        AddNewBadgeToList(); //this is the add/create part of CRUD
                       
                        break;
                    case "3":
                        UpdateAddNewDoor(); //this is the delete part of CRUD
                        break;
                    case "4":
                        DeleteADoor();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again...");
                        break;

                }
            }
        }

        private void AddNewBadgeToList()
        {
            Badge badge = new Badge();
            Console.WriteLine("Please create a new badge.");
            badge.BadgeID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please display all badges.");
        }
        
        private void DisplayAllBadges()
        {
            var badges = _badgeRepo.DisplayAllBadges();
            foreach (var badge in badges)
            {
                Console.WriteLine($"Badge Identification: {badge.Key}\n" +
                    $"Badge Access: ");
                foreach(var room in badge.Value)
                {
                    Console.Write($"{room}, ");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void UpdateAddNewDoor()
        {
            var badges = _badgeRepo.DisplayAllBadges();
            foreach (var badge in badges)
            {
                Console.WriteLine($"Badge Identification: {badge.Key}\n" +
                    $"Badge Access: ");
                foreach (var room in badge.Value)
                {
                    Console.Write($"{room}, ");
                }
            }
            Console.WriteLine("\n" +
                "-------------------------------------------------");
            Console.WriteLine("Which badge are you updating?");
            int badgeChange = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Please update a door to your badge.");
            string userInput = Console.ReadLine();
            _badgeRepo.UpdateAddNewDoor(badgeChange, userInput);
            Console.WriteLine($"{userInput} was successfully added to your badge.\n" +
                $"Plase any key to continue...");
        }

        private void DeleteADoor()
        {
            Console.Clear();
            Console.WriteLine("Enter the door you would like to delete from your badge:");

            string userInput = Console.ReadLine();
          //  _badgeRepo.DeleteADoor(userInput);
            Console.WriteLine($"{userInput} was successfully deleted from your badge.\n" +
                $"Press any key to continue...");
        }

        private void SeedBadge()
        {
            List<string> Doors = new List<string>
            {
                "A1", "A4", "A5", "A7", "B1", "B2"
            };
            Badge badge1 = new Badge(12345, Doors);
            _badgeRepo.AddNewBadgeToDictionary(badge1);

            Badge badge2 = new Badge(22345, Doors);
            _badgeRepo.AddNewBadgeToDictionary(badge2);

            Badge badge3 = new Badge(32345, Doors);
            _badgeRepo.AddNewBadgeToDictionary(badge3);

        }
    }
}
