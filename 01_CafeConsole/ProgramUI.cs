using _01_Cafe;
using _01_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeConsole
{
    class ProgramUI
    {
        private readonly Menu_Repo _menuRepo = new Menu_Repo();
        private IConsole _console;

        public ProgramUI(IConsole console)
        {
            _console = console;
        }

        public void Run()
        {
            SeedMenu();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                _console.Clear();

                _console.WriteLine("Select an option number:\n" +
                    "1. Display all meal items\n" +
                    "2. Add meal items\n" +
                    "3. Delete meal items\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                        ShowAllMealItems();
                        break;
                    case "2":
                        AddMealItems();
                        break;
                    case "3":
                        DeleteMealItems();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddMealItems()
        {
            MenuItem item = new MenuItem();
            _console.WriteLine("Greetings, please enter a meal number.");
            item.MealNumber = Convert.ToInt32(_console.ReadLine());

            _console.WriteLine("What is the meal name?");
            item.MealName = _console.ReadLine();

            _console.WriteLine("What is the description?");
            item.MealDescription = _console.ReadLine();

            _console.WriteLine("What are the ingredients?");
            string userInput = Console.ReadLine();
            List<string> result = userInput.Split(',').ToList();
            item.ListOfIngredients = result;

            _console.Write("What is the price?");
            decimal price = Convert.ToDecimal(_console.ReadLine());
            item.SetPrice(price);

        }

        private void DeleteMealItems()
        {
            _console.Clear();
            _console.WriteLine("Enter the menu item you would like to delete:");
            int userInput = Convert.ToInt32(_console.ReadLine());
            _menuRepo.DeleteExistingItems(userInput);
            _console.WriteLine($"{userInput} was successfully deleted.\n" +
                $"Press any key to continue...");
            _console.ReadKey();
        }

        private void ShowAllMealItems()
        {
            List<MenuItem> item = new List<MenuItem>();
            item = _menuRepo.GetAllItems();
            foreach (MenuItem content in item)
            {
                _console.WriteLine($"Meal number is {content.MealNumber}\n" +
                    $"Meal name is {content.MealName}\n" +
                    $"Meal description is {content.MealDescription}\n" +
                    $"List of ingredients are {content.ListOfIngredients}\n" +
                    $"The price of the meal is {content.MealPrice}");              
            }
            _console.WriteLine("Press any key to continue...");
            _console.ReadKey();
        }

        private void SeedMenu()
        {
            MenuItem item1 = new MenuItem(1, "Burn Your Tongue Chicken Sandwich", "A spicy chicken sandwich on a pretzel bun", new List<string>(), 3.99m);

            MenuItem item2 = new MenuItem(2, "Fish of the Sea Sandwich", "A spicy fish sandwich on a kaiser bun", new List<string>(), 3.49m);

            MenuItem item3 = new MenuItem(3, "Juicy hamburger", "A big juicy hamburger with all the fixins", new List<string>(), 4.50m);
        }
    }
}
