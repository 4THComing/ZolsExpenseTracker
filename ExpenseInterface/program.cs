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
        private  ExpenseStore expenseStore = new ExpenseStore();
        private ExpenseManager expenseManager = new ExpenseManager();

        public static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        public  void Run()
        {
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
                Console.WriteLine("4. View Total Expenses"); 
                Console.WriteLine("5. Delete Expense"); 
                Console.WriteLine("6. Exit");

                Console.Write("Select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                       ExpenseUI.AddExpenseFlow(expenseStore);
                       break;
                    case "2":
                       ExpenseUI.UpdateExpenseFlow();
                       break;
                    case "3":
                       ExpenseUI.ViewExpenseFlow(expenseStore);
                       break;
                    case "4":
                       var total = expenseManager.GetTotalExpenses(expenseStore.GetExpenses());
                       Console.WriteLine($"Total Expenses: {total:C}");
                       break;
                    case "5":
                       ExpenseUI.DeleteExpenseFlow(expenseStore);
                       break;   
                    case "6":
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
