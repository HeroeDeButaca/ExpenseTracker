using ExpenseTracker.Data;
using ExpenseTracker.Model;
using ExpenseTracker.ViewModel;
using System.Windows.Controls;

namespace ExpenseTracker.View.Pages
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

            Database database = new Database();
            TransactionRepository transactionRepository = new TransactionRepository(database);
            DataContext = new HomeViewModel(transactionRepository);
        }
    }
}
