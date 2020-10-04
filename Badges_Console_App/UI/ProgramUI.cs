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
                        //EnterNewBadge();
                        break;
                    case "2":
                        //UPDATE BADGE
                        //EditBadge();
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
        private void ShowAllBadges()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Key");
            Console.WriteLine("Badge #	   Door Access");
            List<BadgeItems> listOfBadges = _badgeItemsRepo.GetAllBadges();
            foreach (BadgeItems content in listOfBadges)
            {
                DisplaySimple(content);
            }
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
            var badgeOne = new BadgeItems(12345, "A7");
            var badgeTwo = new BadgeItems(22345, "A1, A4, B1, B2");
            var badgeThree = new BadgeItems(32345, "A4, A5");

            _badgeItemsRepo.AddNewBadge(badgeOne);
            _badgeItemsRepo.AddNewBadge(badgeTwo);
            _badgeItemsRepo.AddNewBadge(badgeThree);
        }
    }
}
