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
           // SeedClaim();
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
                       // DisplayAllClaims();
                        break;
                    case "2":
                     //   SelectAClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    default:
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
            claim.ClaimAmount = Console.ReadLine();

            Console.WriteLine("Please enter the date of incident.");
            claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Please enter a date of claim.");
            claim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            claim.IsValid = _claimRepo.ClaimIsValid(claim);

            _claimRepo.AddNewClaim(claim);
        }

       // private void 
    }

}