﻿using Claim_Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Claims_Console_App
{
    public class ProgramUI
    {
        private readonly ClaimItemsRepository _claimItemsRepo = new ClaimItemsRepository();
        public void Run()
        {
            Console.Title = "Komodo Claims";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
                         |                       Komodo Claims                      |
                         |                        Department                        |
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
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Choose a menu item:");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n" +
                "4. Exit");
                string agentInput = Console.ReadLine();
                switch (agentInput)
                {
                    case "1":
                        //Show All
                        ShowAllClaims();
                        break;
                    case "2":
                        ShowNextClaim();
                        break;
                    case "3":
                        //add new
                        EnterNewClaim();
                        break;
                    case "4":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        //Default
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Please enter a valid number between 1 & 4.");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllClaims()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("ClaimID   Type      Description                Amount     DateOfAccident     DateOfClaim    IsValid");
            Console.ResetColor();
            List<ClaimItems> listOfClaims = _claimItemsRepo.GetAllClaims();
            foreach (ClaimItems content in listOfClaims)
            {
                DisplaySimple(content);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowNextClaim()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            List<ClaimItems> claimList = _claimItemsRepo.GetAllClaims();

            for (int i = 0; i < claimList.Count; i++)
            {
                List<ClaimItems> toRemove = new List<ClaimItems>();
                foreach (ClaimItems content in claimList)
                {
                   

                    DisplayNext(content);

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("\n" +
                        "Do you want to deal with this claim now(y/n)?");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string answer = Console.ReadLine();

                    if (answer.ToLower() == "y")
                    {
                        toRemove.Add(content);
                    }

                    else if (answer.ToLower() == "n")
                    {
                        foreach (ClaimItems contentToDelete in toRemove)
                        {
                            DeleteClaim(contentToDelete);
                        }
                        return;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Opton is invalid.");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Press any key to continue...");
                    Console.ResetColor();
                    Console.ReadKey();
                }
               foreach(ClaimItems contentToDelete in toRemove)
                {
                    DeleteClaim(contentToDelete);
                }
            }
        }
        private void EnterNewClaim()
        {
            Console.Clear();
            ClaimItems content = new ClaimItems();
            //Claim ID
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Enter the claim id:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            content.ClaimId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //Claim Type
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Enter the claim type:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1) Car\n" +
                "2) Home\n" +
                "3) Theft");
            string type = Console.ReadLine();
            switch (type)
            {
                case "1":
                    content.Type = ClaimType.Car;
                    break;
                case "2":
                    content.Type = ClaimType.Home;
                    break;
                case "3":
                    content.Type = ClaimType.Theft;
                    break;
            }
            Console.WriteLine();

            //Description
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Enter a claim description:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string description = Console.ReadLine();
            content.Description = description;
            Console.WriteLine();

            //Amount
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Amount of Damage:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            content.Amount = float.Parse(Console.ReadLine());
            Console.WriteLine();

            //Date Of Accident
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Date of Accident (eg. mm/dd/yy):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string accidentInput = Console.ReadLine();
            var accidentDate = DateTime.Parse(accidentInput);
            content.DateOfAccident = accidentDate;
            Console.WriteLine();

            //Date Of Claim
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Date of Claim (eg. mm/dd/yy):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string claimInput = Console.ReadLine();
            var claimDate = DateTime.Parse(claimInput);
            content.DateOfClaim = claimDate;


            _claimItemsRepo.AddNewClaim(content);
        }

        private void DisplaySimple(ClaimItems content)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{content.ClaimId,-9} {content.Type,-9} {content.Description,-26} ${content.Amount,-9} {content.DateOfAccident,-18:M/dd/yy} {content.DateOfClaim,-14:M/dd/yy} {content.IsValid}");
        }
        private void DisplayNext(ClaimItems nextClaim)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"ClaimID: {nextClaim.ClaimId}\n" +
                $"Type: {nextClaim.Type}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.Amount}\n" +
                $"Date Of Accident: {nextClaim.DateOfAccident:M/dd/yy}\n" +
                $"Date Of Claim: {nextClaim.DateOfClaim:M/dd/yy}\n" +
                $"Is Valid: {nextClaim.IsValid}\n" +
                "");
        }
        private void DeleteClaim(ClaimItems content)
        {
            _claimItemsRepo.RemoveClaim(content);
        }
        private void SeedContent()
        {
            var dateOne = new DateTime(18, 04, 25);
            var dateTwo = new DateTime(18, 04, 27);
            var dateThree = new DateTime(18, 04, 11);
            var dateFour = new DateTime(18, 04, 12);
            var dateFive = new DateTime(18, 04, 27);
            var dateSix = new DateTime(18, 06, 01);


            var claimOne = new ClaimItems(1, ClaimType.Car, "Car accident on 465.", 400.00f, dateOne, dateTwo, true);
            var claimTwo = new ClaimItems(2, ClaimType.Home, "House fire in kitchen.", 4000.00f, dateThree, dateFour, true);
            var claimThree = new ClaimItems(3, ClaimType.Theft, "Stolen pancakes.", 4.00f, dateFive, dateSix, false);

            _claimItemsRepo.AddNewClaim(claimOne);
            _claimItemsRepo.AddNewClaim(claimTwo);
            _claimItemsRepo.AddNewClaim(claimThree);
        }
    }
}
