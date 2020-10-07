using Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Badges_Console_App
{
    public class ProgramUI
    {
        private readonly BadgeItemsRepository _badgeItemsRepo = new BadgeItemsRepository();
        public void Run()
        {
            Console.Title = "Komodo Claims";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string title = @"
                          __________________________________________________________
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                     Komodo Insurance                     |
                         |                          Badges                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |  -Ausjwill                                               |
                         |__________________________________________________________|
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
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Hello Security Admin, What would you like to do?");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all Badges\n" +
                "4. Exit");
                string adminInput = Console.ReadLine();
                switch (adminInput)
                {
                    case "1":
                        //ADD NEW
                        EnterNewBadge();
                        break;
                    case "2":
                        //UPDATE BADGE
                        EditBadge();
                        break;
                    case "3":
                        //SHOW ALL
                        ShowAllBadges();
                        break;
                    case "4":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        //Default
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Please enter a valid number between 1 & 4.");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void EnterNewBadge()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            BadgeItems content = new BadgeItems();
            Console.WriteLine("What is the number on the badge:");
            Console.ForegroundColor = ConsoleColor.Gray;
            content.BadgeId = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("List a door that it needs access to:");
            Console.ForegroundColor = ConsoleColor.Gray;
            List<string> newList = new List<string>();
            string input = Console.ReadLine();
            newList.Add(input);

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Any other doors(y/n)?");
                Console.ForegroundColor = ConsoleColor.Gray;
                string answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("List a door that it needs access to:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    input = Console.ReadLine();
                    newList.Add(input);
                }

                else if (answer.ToLower() == "n")
                {
                    keepRunning = false;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opton is invalid.");
                }
            }
            content.DoorName = newList;
            _badgeItemsRepo.AddNewBadge(content);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void EditBadge()
        {
            Console.Clear();
            Dictionary<int, List<string>> listOfBadges = _badgeItemsRepo.GetAllBadges();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("What is the badge number to update?");
            Console.ForegroundColor = ConsoleColor.Gray;
            int badgeId = int.Parse(Console.ReadLine());
            BadgeItems foundContent = _badgeItemsRepo.GetBadgeById(badgeId);

            if (foundContent != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{foundContent.BadgeId} has access to doors:");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (var doorList in listOfBadges[badgeId])
                {
                    Console.WriteLine(doorList);
                }
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("What would you like to do?");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Remove a door\n" +
                    "2. Add a door");
                Console.ForegroundColor = ConsoleColor.Gray;
                string option = Console.ReadLine();
                if (option == "1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Which door would you like to remove?");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string input = Console.ReadLine();
                    foundContent.DoorName.Remove(input);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Door Removed");
                    Console.WriteLine($"{foundContent.BadgeId} has access to doors:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    foreach (var doorList in listOfBadges[badgeId])
                    {
                        Console.WriteLine(doorList);
                    }

                }
                else if (option == "2")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Which door would you like to add?");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string input = Console.ReadLine();
                    foundContent.DoorName.Add(input);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Door Added");
                    Console.WriteLine($"{foundContent.BadgeId} has access to doors:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    foreach (var doorList in listOfBadges[badgeId])
                    {
                        Console.WriteLine(doorList);
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Entry");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Badge number not found...");
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowAllBadges()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Key");
            Console.WriteLine("Badge #	   Door Access");
            Dictionary<int, List<string>> listOfBadges = _badgeItemsRepo.GetAllBadges();
            foreach (var badges in listOfBadges.Keys)
            {
                foreach (var doorList in listOfBadges[badges])
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(badges + "      " + doorList);
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
            Console.WriteLine("Press any key to continue... \n");
            Console.ReadKey();
        }

        private void SeedContent()
        {
            string a1 = "A1";
            string a4 = "A4";
            string a5 = "A5";
            string a7 = "A7";

            string b1 = "B1";
            string b2 = "B2";

            BadgeItems badgeOne = new BadgeItems(12345, new List<string> { a7 });
            BadgeItems badgeTwo = new BadgeItems(22345, new List<string> { a1, a4, b1, b2 });
            BadgeItems badgeThree = new BadgeItems(32345, new List<string> { a4, a5 });

            _badgeItemsRepo.AddNewBadge(badgeOne);
            _badgeItemsRepo.AddNewBadge(badgeTwo);
            _badgeItemsRepo.AddNewBadge(badgeThree);
        }
    }
}
