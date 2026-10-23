using System.Globalization;
using BuddyBudget.Models;
using BuddyBudget.Services;

namespace BuddyBudget;

public class BudgetApp
{
    // The transaction store used to 

    //private readonly so that it can only be seen within the BudgetApp class
    //and cannot be modified from outside

    private readonly TransactionStore _transactionStore;
    private readonlyList<Transaction> _transactions;

    public BudgetApp(TransactionStore transactionStore)
    {
        // Initialize the transaction store and load transactions from it
        _store = _store;
        _transaction = _store.Load();
    }

    public void Run()
    {
        while (true)
        {
            ShowMenu();
            Console.Write("Enter your choice: ");

            switch (Console.ReadLine()?.Trim())
            { 

            case "1":
                AddTransaction();
                break;
            case "2":
                ShowTransactions();
                break;
            case "3":
                ShowMonthlySummary();
                break;
            case "4":
                DeleteTransaction();
                break;
            case "5":
                SaveAndExit();
                return;
            default;
                Console.WriteLine("Please choose a number from 1-5");
                break;

            }

        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\n====BuddyBudget Menu ====");
        Console.WriteLine("1. Add income or expense");
        Console.WriteLine("2. Show Transactions");
        Console.WriteLine("3. Show Monthly Summary");
        Console.WriteLine("4. Delete Transaction");
        Console.WriteLine("5. Save and Exit");
    }

