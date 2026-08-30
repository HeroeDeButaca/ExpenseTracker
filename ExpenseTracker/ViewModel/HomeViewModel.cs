using ExpenseTracker.Model;
using ExpenseTracker.MVVM;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace ExpenseTracker.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<Transaction> Transactions { get; } = new();
        public ICollectionView TransactionsView { get; }

        public HomeViewModel()
        {
            Transaction t = new Transaction("Prueba", TransactionCategories.Food, TransactionType.Expense, -100m);
            Transactions.Add(t);

            TransactionsView = CollectionViewSource.GetDefaultView(Transactions);

        }
    }
}
