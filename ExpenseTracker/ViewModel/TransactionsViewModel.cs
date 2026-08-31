using ExpenseTracker.Model;
using ExpenseTracker.MVVM;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace ExpenseTracker.ViewModel
{
    public class TransactionsViewModel : ViewModelBase
    {
        public ObservableCollection<Transaction> Transactions { get; } = new();
        public ICollectionView TransactionsView { get; }

        public TransactionsViewModel()
        {
            Transaction t = new Transaction("Prueba", TransactionCategories.Food, TransactionType.Expense, -100m);
            Transaction t2 = new Transaction("Segunda prueba", TransactionCategories.Entertainment, TransactionType.Expense, -150.02m);
            Transactions.Add(t);
            Transactions.Add(t2);
            Transactions.Add(t);
            Transactions.Add(t2);
            Transactions.Add(t);
            Transactions.Add(t2);
            Transactions.Add(t);
            Transactions.Add(t2);
            Transactions.Add(t);
            Transactions.Add(t2);
            Transactions.Add(t);
            Transactions.Add(t2);
            Transactions.Add(t);
            Transactions.Add(t2);
            Transactions.Add(t);
            Transactions.Add(t2);
            Transactions.Add(t);
            Transactions.Add(t2);

            TransactionsView = CollectionViewSource.GetDefaultView(Transactions);
        }
    }
}
