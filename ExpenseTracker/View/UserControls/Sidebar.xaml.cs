using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExpenseTracker.View.UserControls
{
    public partial class Sidebar : UserControl
    {
        public static readonly DependencyProperty HomeCommandProperty =
            DependencyProperty.Register(nameof(HomeCommand), typeof(ICommand), typeof(Sidebar),
            new PropertyMetadata(default(ICommand)));
        public static readonly DependencyProperty TransactionsCommandProperty =
            DependencyProperty.Register(nameof(TransactionsCommand), typeof(ICommand), typeof(Sidebar),
            new PropertyMetadata(default(ICommand)));
        public static readonly DependencyProperty ExchangeCommandProperty =
            DependencyProperty.Register(nameof(ExchangeCommand), typeof(ICommand), typeof(Sidebar),
            new PropertyMetadata(default(ICommand)));
        public static readonly DependencyProperty SettingsCommandProperty =
            DependencyProperty.Register(nameof(SettingsCommand), typeof(ICommand), typeof(Sidebar),
            new PropertyMetadata(default(ICommand)));

        public ICommand HomeCommand
        {
            get => (ICommand)GetValue(HomeCommandProperty);
            set => SetValue(HomeCommandProperty, value);
        }
        public ICommand TransactionsCommand
        {
            get => (ICommand)GetValue(TransactionsCommandProperty);
            set => SetValue(TransactionsCommandProperty, value);
        }
        public ICommand ExchangeCommand
        {
            get => (ICommand)GetValue(ExchangeCommandProperty);
            set => SetValue(ExchangeCommandProperty, value);
        }
        public ICommand SettingsCommand
        {
            get => (ICommand)GetValue(SettingsCommandProperty);
            set => SetValue(SettingsCommandProperty, value);
        }

        public Sidebar()
        {
            InitializeComponent();
        }
    }
}
