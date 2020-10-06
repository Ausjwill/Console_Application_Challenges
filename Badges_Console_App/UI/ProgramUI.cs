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
            Console.Clear();
            BadgeItems content = new BadgeItems();
            Console.WriteLine("What is the number on the badge:");
            content.BadgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("List a door that it needs access to:");
            List<string> newList = new List<string>();
            string input = Console.ReadLine();
            newList.Add(input);

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Any other doors(y/n)?");
                string answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                {
                    Console.WriteLine("List a door that it needs access to:");
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
            BadgeItems updatedDoorAccess = new BadgeItems();
            Dictionary<int, List<string>> listOfBadges = _badgeItemsRepo.GetAllBadges();

            Console.WriteLine("What is the badge number to update?");
            int badgeId = int.Parse(Console.ReadLine());
            BadgeItems foundContent = _badgeItemsRepo.GetBadgeById(badgeId);

            if (foundContent != null) //???
            {
                Console.WriteLine($"{foundContent.BadgeId} has access to doors {_badgeItemsRepo.GetAllBadges()}");
                Console.WriteLine("What would you like to do?\n" +
                    "1. Remove a door\n" +
                    "2. Add a door");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    Console.WriteLine("Which door would you like to remove?");
                    List<string> newList = new List<string>();
                    string input = Console.ReadLine();
                    newList.Remove(input);
                    foundContent.DoorName = newList;
                    Console.WriteLine("Door Removed");
                    Console.WriteLine($"{foundContent.BadgeId} has access to doors {foundContent.DoorName}");
                }
                else if (option == "2")
                {
                    Console.WriteLine("Which door would you like to add?");
                    List<string> newList = new List<string>();
                    string input = Console.ReadLine();
                    newList.Add(input);
                    foundContent.DoorName = newList;
                    Console.WriteLine("Door Added");
                    Console.WriteLine($"{foundContent.BadgeId} has access to doors {foundContent.DoorName}");
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
            else
            {
                Console.WriteLine("Badge number not found...");
            }
            _badgeItemsRepo.AddNewBadge(foundContent);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowAllBadges()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Key");
            Console.WriteLine("Badge #	   Door Access");

            //foreach (KeyValuePair<int, List<string>> content  in _badgeDirectory())
            //{
            //    //DisplaySimple(new BadgeItems(content.Key, content.Value));
            //    Console.WriteLine($"Key = {0}, Value = {1}", content.Key, content.Value);
            //}

            Dictionary<int, List<string>> listOfBadges = _badgeItemsRepo.GetAllBadges();
            Console.WriteLine();
            foreach (var badges in listOfBadges.Keys)
            {
                foreach (var doorList in listOfBadges[badges])
                {
                    Console.WriteLine("Key: " + badges + "member:" + doorList);
                }
            }

            Console.WriteLine("Press any key to continue... \n");
            Console.ReadKey();


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DisplaySimple(BadgeItems content)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{content.BadgeId,-10} {content.DoorName}");
        }
        private void SeedContent()
        {
            string a1 = "A1";
            string a2 = "A2";
            string a3 = "A3";
            string a4 = "A4";
            string a5 = "A5";
            string a6 = "A6";
            string a7 = "A7";
            string a8 = "A8";
            string a9 = "A9";

            string b1 = "B1";
            string b2 = "B2";
            string b3 = "B3";
            string b4 = "B4";
            string b5 = "B5";
            string b6 = "B6";
            string b7 = "B7";
            string b8 = "B8";
            string b9 = "B9";

            BadgeItems badgeOne = new BadgeItems(12345, new List<string> { "a7" });
            BadgeItems badgeTwo = new BadgeItems(22345, new List<string> { a1, a4, b1, b2 });
            BadgeItems badgeThree = new BadgeItems(32345, new List<string> { a4, a5 });

            _badgeItemsRepo.AddNewBadge(badgeOne);
            _badgeItemsRepo.AddNewBadge(badgeTwo);
            _badgeItemsRepo.AddNewBadge(badgeThree);
        }
    }
}
