using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class MenuItemsRepository
    {
        protected readonly List<MenuItems> _menuDirectory = new List<MenuItems>();
        //CRUD - Create Read Update Delete <- Only need to be able to Create, Read, and Delete

        //CREATE
        public bool AddItemToMenu(MenuItems newContent)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(newContent);
            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ ALL
        public List<MenuItems> GetAllItems()
        {
            return _menuDirectory;
        }

        //READ ONE
        public MenuItems GetItemsByName(string mealName)
        {
            foreach (MenuItems singleItem in _menuDirectory)
            {
                if (singleItem.MealName.ToLower() == mealName.ToLower())
                {
                    return singleItem;
                }
            }
            return null;
        }

        //DELETE
        public bool RemoveItemFromMenu(MenuItems deletedContent)
        {
            bool deleteResult = _menuDirectory.Remove(deletedContent);
            return deleteResult;
        }
    }
}
