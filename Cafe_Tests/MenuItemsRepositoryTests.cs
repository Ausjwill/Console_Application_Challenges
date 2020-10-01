using System;
using System.Collections.Generic;
using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Repository_Tests
{
    [TestClass]
    public class MenuItemsRepositoryTests
    {
        private MenuItems _content;
        private MenuItemsRepository _repo;
        [TestMethod]
        public void AddItemToMenu_ShouldGetCorrectBoolean()
        {
            //ARRANGE
            MenuItems newContent = new MenuItems();
            MenuItemsRepository repo = new MenuItemsRepository();

            //ACT
            bool addResult = repo.AddItemToMenu(newContent);

            //ASSERT
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenuItems_ShouldReturnCorrectListOfMenuItems()
        {
            //ARRANGE
            MenuItems newObject = new MenuItems();
            MenuItemsRepository repository = new MenuItemsRepository();
            repository.AddItemToMenu(newObject);

            //ACT
            List<MenuItems> listOfMenuItems = repository.GetAllItems();

            //ASSERT
            bool menuHasItems = listOfMenuItems.Contains(newObject);
            Assert.IsTrue(menuHasItems);
        }

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemsRepository();
            _content = new MenuItems(5, "Meat Lover's Delight", "Ham sausage bacon egg cheese sandwich", "1, 2, 3", 3.95f);
            _repo.AddItemToMenu(_content);
        }

        [TestMethod]
        public void GetByName_ShouldReturnCorrectItem()
        {
            //ARRANGE

            //ACT
            MenuItems searchResult = _repo.GetItemsByName("Meat Lover's Delight");

            //ASSERT
            Assert.AreEqual(_content, searchResult);
        }

        [TestMethod]
        public void DeleteMenuItems_ShouldReturnTrue()
        {
            //ARRANGE
            MenuItems deleteContent = _repo.GetItemsByName("Meat Lover's Delight");

            //ACT
            bool removeResult = _repo.RemoveItemFromMenu(deleteContent);

            //ASSERT
            Assert.IsTrue(removeResult);
        }
    }
}
