using System;
using System.Collections.Generic;
using System.Text;
using CDManager.Models;

namespace CDManager.View
{
    public class CDView
    {
        public int GetMenuChoice()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to your personal CD Manager.");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Create [1], List All [2], Find by ID [3], Edit [4], Remove [5], or Exit [0]");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out int userChoice);
            return userChoice;
        }
        public CD GetNewCDInfo()
        {
            CD newCD = new CD();
            Console.WriteLine("What is the CD's name?");
            string input = Console.ReadLine();
            newCD.Title = input;
            Console.WriteLine("What year was the CD released?");
            input = Console.ReadLine();
            int.TryParse(input, out int CDYear);
            newCD.ReleaseYear = CDYear;
            Console.WriteLine("What artist is the album by?");
            input = Console.ReadLine();
            newCD.Artist = input;

            return newCD;
        }
        public void DisplayCD(CD cd)
        {
            if (cd == null)
            {
                Console.WriteLine("No CD was found.");
            }
            else
            {
                Console.WriteLine("The Following Results Were Found: ");
                Console.WriteLine($"{cd.Id} - Title: {cd.Title}");
                Console.WriteLine($"Artist: {cd.Artist}");
                Console.WriteLine($"Release Year: {cd.ReleaseYear}");
            }
        }
        public CD EditCDInfo(CD cd)
        {
            int userChoice = 4;
            do
            {
                Console.WriteLine("What would you like to update?");
                Console.WriteLine("Title [1], Release Year [2], Artist [3], or Exit [4]");
                string userInput = Console.ReadLine();
                int.TryParse(userInput, out userChoice);
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("What is the CD's name?");
                        string input = Console.ReadLine();
                        cd.Title = input;
                        break;
                    case 2:
                        Console.WriteLine("What year was the CD released?");
                        input = Console.ReadLine();
                        int.TryParse(input, out int CDYear);
                        cd.ReleaseYear = CDYear;
                        break;
                    case 3:
                        Console.WriteLine("What artist is the album by?");
                        input = Console.ReadLine();
                        cd.Artist = input;
                        break;
                    default:
                        break;
                }
            } while (userChoice != 4);

            return cd;
        }
        public int SearchCD()
        {
            Console.WriteLine("Please enter the ID of the CD you would like to find.");
            string input = Console.ReadLine();
            int.TryParse(input, out int result);
            return result;
        }
        public bool ConfirmRemoveCD()
        {
            Console.WriteLine("Are you sure you want to remove a CD? Once it has been removed it cannot be retrieved.");
            Console.WriteLine("(y/n)?");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Successful()
        {
            Console.WriteLine("Catalog was updated successfully.");
        }
        public void NoResults()
        {
            Console.WriteLine("No Results Were Found");
        }


    }
}
