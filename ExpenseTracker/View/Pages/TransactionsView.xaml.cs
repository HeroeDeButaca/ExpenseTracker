using ExpenseTracker.Data;
using ExpenseTracker.ViewModel;
using System.Windows.Controls;

namespace ExpenseTracker.View.Pages
{
    public partial class TransactionsView : UserControl
    {
        public TransactionsView()
        {
            InitializeComponent();
            Database database = new Database();
            TransactionRepository transactionRepository = new TransactionRepository(database);
            DataContext = new TransactionsViewModel(transactionRepository);
        }
    }
}
