using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseInterface.Models;
using ExpenseInterface.Services;
using ExpenseInterface.Storage;
using ExpenseInterface.ProjectUI;

namespace ExpenseInterface
{
   class Program
   {
      private ExpenseStore expenseStore = new ExpenseStore();
      private ExpenseManager expenseManager = new ExpenseManager();

      public static void Main(string[] args)
      {
         var program = new Program();
         program.Run();
      }

      public void Run()
      {
         expenseStore.LoadExpenses();
         ShowMenu();
      }

      public void ShowMenu()
      {
         bool running = true;
         while (running)
         {

            Console.WriteLine("--Expense Tracker Menu--");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. Update Expense");
            Console.WriteLine("3. View Expenses");
            Console.WriteLine("4. Filter Expenses by Category");
            Console.WriteLine("5. Filter Expenses by Description");
            Console.WriteLine("6. Filter Expenses by Date");
            Console.WriteLine("7. Filter Expenses by Amount");
            Console.WriteLine("8. View Monthly Report");
            Console.WriteLine("9. View Total Expenses");
            Console.WriteLine("10. Delete Expense");
            Console.WriteLine("11. Exit");

            Console.Write("Select an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
               case "1":
                  ExpenseUI.AddExpenseFlow(expenseStore);
                  break;
               case "2":
                  ExpenseUI.UpdateExpenseFlow(expenseStore);
                  break;
               case "3":
                  ExpenseUI.ViewExpenseFlow(expenseStore);
                  break;
               case "4":
                  ExpenseUI.FilterExpensesByCategory(expenseStore);
                  break;
               case "5":
                  ExpenseUI.FilterExpensesByDescription(expenseStore);
                  break;
               case "6":
                  ExpenseUI.FilterExpensesByDate(expenseStore);
                  break;
               case "7":
                  ExpenseUI.FilterExpensesByAmount(expenseStore);
                  break;
               case "8":
                  ExpenseUI.ViewMonthlyExpensesFlow(expenseStore);
                  break;
               case "9":
                  var total = expenseManager.GetTotalExpenses(expenseStore.GetExpenses());
                  Console.WriteLine($"Total Expenses: {total:C}");
                  break;
               case "10":
                  ExpenseUI.DeleteExpenseFlow(expenseStore);
                  break;
               case "11":
                  Console.WriteLine("Exiting...");
                  running = false;
                  break;
               default:
                  Console.WriteLine("Invalid option. Please try again.");
                  break;
            }
         }
      }
   }
}
