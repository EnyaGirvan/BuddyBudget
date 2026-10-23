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
            // while statement to keep the application running until the user chooses to exit
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
        // Display the main menu options to the user
        Console.WriteLine("\n====BuddyBudget Menu ====");
        Console.WriteLine("1. Add income or expense");
        Console.WriteLine("2. Show Transactions");
        Console.WriteLine("3. Show Monthly Summary");
        Console.WriteLine("4. Delete Transaction");
        Console.WriteLine("5. Save and Exit");
    }
    
    private void AddTransaction()
    {
        // Prompt the user for the transaction type and validate it
        Console.Write("Type (income/expense): ");
        var typetext = Console.ReadLine()?.Trim().ToLowerInvariant();
        if (typetext is not ("income" or "expense"))
        {
            Console.WriteLine("Invalid type. Please enter 'income' or 'expense'.");
            return;
        }

        // Prompt the user for the amount and validate it
        Console.Write("Amount: ");
        if (!decimal.TryParse(Console.Readline(), NumberStyles.Number, CultureInfo.InvariantCulture, out var amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter an amount greater than zero.");
            return;
        }

        // Prompt the user for the category and validate it
        Console.write("Catagory: ");
        var category = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(category))
        {
            Console.WriteLine("Category cannot be empty.");
            return;
        }

        // Prompt the user for the description (optional)
        Console.write("Description (options): ");
        var description = Console.ReadLine()?.Trim() ?? "";
        var nextId = _transactions.Count == 0 ? 1 : _transactions.Max(t => t.Id) + 1;
        var type = typetext == "income" ? TransactionType.Income : TransactionType.Expense;
        var transaction = new Transaction(nextId, type, amount, category, description);

        DateOnly.FromDateTime(DateTime.Today);

        // Add the new transaction to the list and save it to the store
        _transactions.Add(transaction);
        _store.Save(_transactions);
        Console.WriteLine("Transaction saved successfully.");
    }
    // Display the list of transactions to the user
    private void ShowTransactions()
    {
        if (_transactions.Count == 0)
        {
            Console.WriteLine("No transactions found.");
            return;
        }

        // Display the header for the transaction list
        foreach (var item in _transactions.OrderByDescending(t => t.date).ThenByDescending(t => t.Id))
        {
            // Display each transaction's details in a formatted manner
            Console.WriteLine($"#{item.Id} {item.Date:yyyy-MM-dd}  {item.Type,-7}  {item.Amount,10:C}  {item.Category}  {item.Description}");
        }
    }

    private void ShowMonthlySummary