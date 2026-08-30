using ExpenseTracker.ViewModel;
using System.Windows;

namespace ExpenseTracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}