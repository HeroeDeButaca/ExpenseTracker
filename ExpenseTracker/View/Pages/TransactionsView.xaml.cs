using ExpenseTracker.ViewModel;
using System.Windows.Controls;

namespace ExpenseTracker.View.Pages
{
    public partial class TransactionsView : UserControl
    {
        public TransactionsView()
        {
            InitializeComponent();
            DataContext = new TransactionsViewModel();
        }
    }
}
