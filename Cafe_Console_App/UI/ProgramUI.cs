using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe_Console_App
{
    public class ProgramUI
    {
        private readonly MenuItemsRepository _menuItemsRepo = new MenuItemsRepository();
        public void Run()
        {
            Console.Title = "Komodo Cafe";
            string title = @"
                          __________________________________________________________
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                        Komodo Cafe                       ||
                        ||                           Menu                           ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||                                                          ||
                        ||__________________________________________________________||
";
            Console.WriteLine(title);
            Thread.Sleep(5000);
            Console.Clear();
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select: \n" +
                "1) Show all menu items \n" +
                "2) Find by name\n" +
                "3) Add new content \n" +
                "4) Remove content \n" +
                "5) Exit");
                string managerInput = Console.ReadLine();
                switch (managerInput)
                {
                    case "1":
                        //Show All
                        ShowAllItems();
                        break;
                    case "2":
                        //Add New
                        ShowItemsByName();
                        break;
                    case "3":
                        //Add New
                        CreateNewItem();
                        break;
                    case "4":
                        //Remove
                        DeleteItem();
                        break;
                    case "5":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        //Default
                        Console.WriteLine("Please enter a valid number between 1 & 5. \n" +
                            "Press any key to continue......");
                        Console.ReadKey();
                        break;
                }
            }

        }

        private void ShowAllItems()
        {
            Console.Clear();
            List<MenuItems> listOfItems = _menuItemsRepo.GetAllItems();
            foreach (MenuItems content in listOfItems)
            {
                DisplaySimple(content);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowItemsByName()
        {
            Console.Clear();
            Console.WriteLine("Please enter the Name of the item you wish to see: ");
            string mealName = Console.ReadLine();
            MenuItems content = _menuItemsRepo.GetItemsByName(mealName);
            if (content != null)
            {
                DisplaySimple(content);
            }
            else
            {
                Console.WriteLine("There are no menu items that match that name.\n" +
                    "Please try again...");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void CreateNewItem()
        {
            MenuItems content = new MenuItems();
            //Menu Number
            Console.WriteLine("Please enter the menu number of the new item:");
            content.MealNumber = int.Parse(Console.ReadLine());

            //Menu Name
            Console.WriteLine("Please enter the name of the new item:");
            string mealName = Console.ReadLine();
            content.MealName = mealName;

            //Description
            Console.WriteLine($"Please enter the description for {content.MealName}:");
            string description = Console.ReadLine();
            content.Description = description;

            //Ingredients
            Console.WriteLine($"Please enter the ingredients for {content.MealName}:");
            string ingredients = Console.ReadLine();
            content.Ingredients = ingredients;

            //Price
            Console.WriteLine($"Please enter the price for {content.MealName}:");
            content.Price = float.Parse(Console.ReadLine());

            _menuItemsRepo.AddItemToMenu(content);
        }
        private void DeleteItem()
        {
            Console.WriteLine("Please select the item you would like to remove:");
            List<MenuItems> menuList = _menuItemsRepo.GetAllItems();
            int count = 0;
            foreach (var content in menuList)
            {
                count++;
                Console.WriteLine($"{count} {content.MealName}");
            }
            int targetedItem = int.Parse(Console.ReadLine());
            int correctList = targetedItem - 1;
            if (correctList >= 0 && correctList < menuList.Count)
            {
                MenuItems chosenContent = menuList[correctList];
                if (_menuItemsRepo.RemoveItemFromMenu(chosenContent))
                {
                    Console.WriteLine($"{chosenContent.MealName} has been removed.");
                }
                else
                {
                    Console.WriteLine($"Could not remove {chosenContent.MealName}.");
                }
            }
            else
            {
                Console.WriteLine("Opton is invalid.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DisplaySimple(MenuItems content)
        {
            Console.WriteLine($"#{content.MealNumber}: {content.MealName} | ${content.Price}\n" +
                $"Description: {content.Description}\n" +
                $"Ingredients: {content.Ingredients}\n" +
                "\n");
        }
        private void SeedContent()
        {
            var menuItemOne = new MenuItems(1, "Reuben", "Try our delicious Reuben sandwith, it's AMAZING!", "Corned Beef | Swiss Cheese | Sauerkraut | Russian Dressing | Rye Bread", 6.25f);
            var menuItemTwo = new MenuItems(2, "Club", "Our club may just be the best in the world!", "Sliced Cooked Poultry | Ham or Fried Bacon | Lettuce | Tomato | Mayonnaise", 4.50f);
            var menuItemThree = new MenuItems(3, "Chicken Sandwich", "If you're feeling chicken, then this is sure to satisfy your craving!", "Boneless, Skinless Chicken Breast | Pickles | Lettuce | Tomatoes | Bun or Roll.", 5.00f);

            _menuItemsRepo.AddItemToMenu(menuItemOne);
            _menuItemsRepo.AddItemToMenu(menuItemTwo);
            _menuItemsRepo.AddItemToMenu(menuItemThree);
        }

    }
}
