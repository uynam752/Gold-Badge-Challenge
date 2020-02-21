using _02_Claim_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimConsole
{
    class ProgramUI //this is what the end user(index) will see
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            SeedClaim();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Select an option number:\n" +
                    "1. Display all claims\n" +
                    "2. Select a claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                        DisplayAllClaims(); //this is the retrieve/get part of CRUD
                        break;
                    case "2":
                        SelectAClaim(); //this is the delete part of CRUD
                        break;
                    case "3":
                        EnterANewClaim(); //this is the add/create part of CRUD
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again...");
                        break;

                }
            }
        }
        private void EnterANewClaim()
        {
            Claim1 claim = new Claim1();
            Console.WriteLine("Please enter a claim identification.");
            claim.ClaimID = Console.ReadLine();

            Console.WriteLine("Please enter a claim type (enter a value between 1 and 3\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");

            int claimType = Convert.ToInt32(Console.ReadLine());    //converting a string to an integer
            claim.ClaimType = (TypeOfClaim)claimType;               //"typecasting" to assign the index number of the Enum to the ClaimType property

            Console.WriteLine("Please enter a claim description.");
            claim.ClaimDescrip = Console.ReadLine();

            Console.WriteLine("Please enter a claim amount.");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            claim.SetPrice(amount);

            Console.WriteLine("Please enter the date of incident. Use format: YYYY,MM,DD");
            claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Please enter a date of claim. Use format: YYYY,MM,DD");
            claim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            claim.IsValid = _claimRepo.ClaimIsValid(claim);

            _claimRepo.AddNewClaim(claim); //to "peek"/see upcoming claim
        }

        private void DisplayAllClaims()
        {
            Queue<Claim1> claims = new Queue<Claim1>();
            claims = _claimRepo.RetrieveAllClaims();
            foreach (Claim1 claim in claims)
            {
                Console.WriteLine($"Claim Identification: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Claim Description: {claim.ClaimDescrip}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateOfClaim}\n" +
                    $"Is valid: {claim.IsValid}\n" +
                    $"");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SelectAClaim()
        {//peek
            ////display info
            ////ask if they want to take care of it
            //Console.WriteLine($"Claim Identification: {}\n" +
            //    $"");
            //Console.Clear();
            //Console.WriteLine("Please select a claim:"); //or is it...please select a claim to delete?
            //string userInput = Console.ReadLine();
            //_claimRepo.DeleteExistingClaim(userInput);
            //Console.WriteLine($"{userInput} was successfully deleted.\n" +
            //    $"Press any key to continue...");
            Queue<Claim1> claimQueue = _claimRepo.RetrieveAllClaims();
            Console.WriteLine("Here are the details for the next claim:\n");
            Console.WriteLine($"Claim ID: {claimQueue.Peek().ClaimID}");
            Console.WriteLine($"Claim Type: {claimQueue.Peek().ClaimType}");
            Console.WriteLine($"Claim Description: {claimQueue.Peek().ClaimDescrip}");
            Console.WriteLine($"Claim Amount: ${claimQueue.Peek().ClaimAmount}");
            Console.WriteLine($"Claim Incident Date: {claimQueue.Peek().DateOfIncident}");
            Console.WriteLine($"Claim Date: {claimQueue.Peek().DateOfClaim}");
            Console.WriteLine($"Claim Is Valid ? : {claimQueue.Peek().IsValid}");

            Console.WriteLine("Do you want to deal with this claim now?\n" +
                "Enter y for yes\n" +
                "Enter n for no");
            string userResponse = Console.ReadLine();
            if (userResponse == "y")
            {
                claimQueue.Dequeue();
            }
            else
            {
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadLine();
            }

        }

        private void SeedClaim()
        {
            Claim1 houseFire = new Claim1("1AA", TypeOfClaim.home, "house caught on fire", 758m, new DateTime(20160505), new DateTime(20160510), true);
            _claimRepo.AddNewClaim(houseFire);

            Claim1 damagedCar = new Claim1("1BB", TypeOfClaim.car, "car damaged from tornado", 15000m, new DateTime(20170711), new DateTime(20170813), false);
            _claimRepo.AddNewClaim(damagedCar);

            Claim1 purseTheft = new Claim1("1CC", TypeOfClaim.theft, "purse stolen from grocery store", 120m, new DateTime(20181102), new DateTime(20181103), true);
            _claimRepo.AddNewClaim(purseTheft); //this is the method from your repo file to run your code above.
        }
    }

}









/**/
