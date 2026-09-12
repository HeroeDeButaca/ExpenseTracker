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

        public RelayCommand SetHomeViewCommand { get; }
        public RelayCommand SetTransactionsViewCommand { get; }
        public RelayCommand SetExchangeViewCommand { get; }
        public RelayCommand SetSettingsViewCommand { get; }

        public MainWindowViewModel()
        {
            SetHomeViewCommand = new RelayCommand(execute => SetToHomeView(), canExecute => _currentView is not HomeView);
            SetTransactionsViewCommand = new RelayCommand(execute => SetToTransactionsView(), canExecute => _currentView is not TransactionsView);
            SetExchangeViewCommand = new RelayCommand(execute => SetToExchangeView(), canExecute => _currentView is not ExchangeView);
            SetSettingsViewCommand = new RelayCommand(execute => SetToSettingsView(), canExecute => _currentView is not SettingsView);

            CurrentView = new HomeView();
        }

        private void SetToHomeView() { CurrentView = new HomeView(); }
        private void SetToTransactionsView() { CurrentView = new TransactionsView(); }
        private void SetToExchangeView() { CurrentView = new ExchangeView(); }
        private void SetToSettingsView() { CurrentView = new SettingsView(); }
    }
}
