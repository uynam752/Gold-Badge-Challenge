using System;
using System.Collections.Generic;
using _01_Cafe;
using _01_Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTest
{
    [TestClass]
    public class MenuRepoTests
    {
        [TestMethod]
        public void CreateMenuItem()
        {
            MenuItem items = new MenuItem();
            Menu_Repo repository = new Menu_Repo();

            bool addResult = repository.AddListOfItems(items);

            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetMenuItem()
        {
            MenuItem items = new MenuItem();
            Menu_Repo repo = new Menu_Repo();

            repo.AddListOfItems(items);

            List<MenuItem> item = repo.GetAllItems();

            bool menuHasItem = item.Contains(items);
            Assert.IsTrue(menuHasItem);
        }

        private Menu_Repo _repo;
        private MenuItem _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new Menu_Repo();
            List<string> Ingredients = new List<string>
            {
                "lettuce", "tomato", "onions", "spicy mayo", "jalapenos"
            };
            _item = new MenuItem(1, "Crispy Chicken", "A boneless skinless chicken breast coated in breadcrumbs and fried in oil", Ingredients, 3.99m);
            
        }
        [TestMethod]
        public void RemoveMenuItem()
        {
            bool removeResult = _repo.DeleteExistingItems(1);
            Assert.IsTrue(removeResult);
        }
        

        
    }
}
