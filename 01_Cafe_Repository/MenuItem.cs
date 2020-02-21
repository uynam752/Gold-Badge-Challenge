using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuItem
    {
        private decimal _MealPrice;
        public MenuItem() { }

        //public MenuItem(int v1, string v2, string v3, decimal v4)
        //{
        //}

        public MenuItem(int mealNumber, string mealName, string mealDescription, List<string> listOfIngredients, decimal mealPrice)

        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            SetPrice(mealPrice);
        }
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> ListOfIngredients { get; set; }
        public decimal MealPrice 
        {
            get { return _MealPrice; } //set { }
        }

        public void SetPrice(decimal amount)
        { //this method is being used despite it being irrelevant because it is public
          //i'm doing this in order to satifsy the rubic needing a "field"
            _MealPrice = amount;
         
        }
    }
}
