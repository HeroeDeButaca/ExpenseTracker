using ExpenseTracker.Data;
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

        private readonly TransactionRepository _repository;

        public TransactionsViewModel(TransactionRepository repository)
        {
            _repository = repository;

            LoadTransactions();

            TransactionsView = CollectionViewSource.GetDefaultView(Transactions);
        }

        private void LoadTransactions()
        {
            foreach (var transaction in _repository.GetAll(true))
            {
                Transactions.Add(transaction);
            }
        }
    }
}
