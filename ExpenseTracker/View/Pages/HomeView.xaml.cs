using ExpenseTracker.ViewModel;
using System.Windows.Controls;

namespace ExpenseTracker.View.Pages
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }
    }
}
