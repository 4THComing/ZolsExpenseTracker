using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseInterface.Models;
using ExpenseInterface.Storage;

namespace ExpenseInterface.ProjectUI.Helper
{
    public static class InputHelper
    {
        public static CategorySelection GetValidCategoryInput()
        {
            CategorySelection newCategoryInput = default(CategorySelection);
            Console.WriteLine("Enter Valid Category from the following: \n1. Food \n2. Transportation \n3. Utilities \n4. Entertainment \n5. Healthcare \n6. Education \n7. Other");
            Console.Write("1. Enter Expense Category: ");
            var choice = Console.ReadLine();
            while (true)
            {
                switch (choice)
                {
                    case "1":
                        newCategoryInput = CategorySelection.Food;
                        break;
                    case "2":
                        newCategoryInput = CategorySelection.Transportation;
                        break;
                    case "3":
                        newCategoryInput = CategorySelection.Utilities;
                        break;
                    case "4":
                        newCategoryInput = CategorySelection.Entertainment;
                        break;
                    case "5":
                        newCategoryInput = CategorySelection.Healthcare;
                        break;
                    case "6":
                        newCategoryInput = CategorySelection.Education;
                        break;
                    case "7":
                        newCategoryInput = CategorySelection.Other;
                        break;
                    default:
                        newCategoryInput = CategorySelection.None;
                        Console.WriteLine("Invalid choice, Please select a valid category from the list.");
                        Console.Write("1. Enter Expense Category: ");
                        choice = Console.ReadLine();
                        continue;
                }
                return newCategoryInput;
            }
        }
        public static string GetValidDescriptionInput()
        {
            Console.Write("2. Enter description: ");
            var newDescriptionInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newDescriptionInput) || newDescriptionInput.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid description. Please enter a non-empty description without numbers.");
                Console.Write("2. Enter description: ");
                newDescriptionInput = Console.ReadLine();
            }
            return newDescriptionInput;

        }

        public static double GetValidAmountInput()
        {
            Console.Write("3. Enter amount: ");
            var newAmountInput = double.TryParse(Console.ReadLine(), out double amount) ? amount : 0.00;
            while (true)
            {
                bool invalidAmount = newAmountInput <= 0;

                if (invalidAmount)
                {
                    Console.WriteLine("Invalid amount, Please enter a figure greater than 0.00");
                    Console.Write("3. Enter Expense Amount: ");
                    newAmountInput = double.TryParse(Console.ReadLine(), out amount) ? amount : 0.00;
                }
                else
                {
                    break;
                }

            }
            return newAmountInput;

        }

        public static DateTime GetValidDateInput()
        {
            Console.Write("4. Enter date (yyyy-MM-dd): ");
            DateTime newDateInput;
            while (!DateTime.TryParse(Console.ReadLine(), out newDateInput))
            {
                Console.WriteLine("Invalid date format. Please enter a date in the format yyyy-MM-dd.");
                Console.Write("4. Enter date (yyyy-MM-dd): ");
            }
            return newDateInput;
        }

        public static int GetExpenseToDelete(int expenseCount)
        {
            Console.WriteLine("Enter the number of the expense you want to delete: ");
            int expenseIndex;

            while (true)
            {
                var expenseToDelete = Console.ReadLine();

                if (expenseToDelete == null || !int.TryParse(expenseToDelete, out expenseIndex) || expenseIndex < 1 || expenseIndex > expenseCount)
                {
                    Console.WriteLine("Invalid expense number.");
                    Console.Write("Enter the number of the expense you want to delete: ");
                    continue;
                }

                break;
            }

            return expenseIndex;
        }

        public static int GetValidMonthInput()
        {
            Console.Write("Enter month (1-12): ");
            int month;
            while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
            {
                Console.WriteLine("Invalid month. Please enter a number between 1 and 12.");
                Console.Write("Enter month (1-12): ");
            }
            return month;
        }

        public static int GetValidYearInput()
        {
            Console.Write("Enter year: ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Invalid year. Please enter a valid year.");
                Console.Write("Enter year: ");
            }
            return year;
        }
    }
}