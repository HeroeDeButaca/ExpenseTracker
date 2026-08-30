using ExpenseTracker.MVVM;
using ExpenseTracker.View.Pages;

namespace ExpenseTracker.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            //CurrentView = new HomeView();
            CurrentView = new TransactionsView();
        }
    }
}
