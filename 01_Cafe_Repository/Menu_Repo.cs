using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    public class Menu_Repo
    {
        private readonly List<MenuItem> _listOfItems = new List<MenuItem>();
        public bool AddListOfItems(MenuItem items)  //this is the create portion of CRUD
        { 
            int initialCount = _listOfItems.Count();
            _listOfItems.Add(items);
            bool wasAdded = initialCount + 1 == _listOfItems.Count();
            return wasAdded;
        }

        public List<MenuItem> GetAllItems()
        {
            return _listOfItems;
        }

        public MenuItem GetMenuByIDNum(int ID) //this is the read portion of CRUD
        {
            foreach(MenuItem items in _listOfItems)
            {
                if (items.MealNumber == ID)
                {
                    return items;
                }
            }
            return null;
        }

        //public bool UpdateExistingItems(MenuItems) 
        //{

        //}

        public bool DeleteExistingItems(int mealNumber) //this is the delete portion of CRUD
        {
            MenuItem foundItem = GetMenuByIDNum(mealNumber);
            bool deletedResult = _listOfItems.Remove(foundItem);
            return deletedResult;
        }
    }
}
