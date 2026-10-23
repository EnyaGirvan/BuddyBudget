using BuddyBudget;
using BuddyBudget.Services;

var store = new
// Initialize the transaction store with a JSON file
TransactionStore("transaction.json");
var app = new BudgetApp(store);
app.Run();
