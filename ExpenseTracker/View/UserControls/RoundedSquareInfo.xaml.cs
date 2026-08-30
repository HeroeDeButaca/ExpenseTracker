using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExpenseTracker.View.UserControls
{
    public partial class RoundedSquareInfo : UserControl
    {
        public new static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register(nameof(Background), typeof(Brush), typeof(RoundedSquareInfo),
            new PropertyMetadata(default(Brush)));

        public static readonly DependencyProperty TitleTextProperty =
            DependencyProperty.Register(nameof(TitleText), typeof(string), typeof(RoundedSquareInfo),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TitleColorProperty =
            DependencyProperty.Register(nameof(TitleColor), typeof(Brush), typeof(RoundedSquareInfo),
            new PropertyMetadata(default(Brush)));

        public static readonly DependencyProperty MoneyTextProperty =
            DependencyProperty.Register(nameof(MoneyText), typeof(string), typeof(RoundedSquareInfo),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty MoneyTextColorProperty =
            DependencyProperty.Register(nameof(MoneyTextColor), typeof(Brush), typeof(RoundedSquareInfo),
            new PropertyMetadata(default(Brush)));

        public new Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }
        public string TitleText
        {
            get => (string)GetValue(TitleTextProperty);
            set => SetValue(TitleTextProperty, value);
        }
        public Brush TitleColor
        {
            get => (Brush)GetValue(TitleColorProperty);
            set => SetValue(TitleColorProperty, value);
        }
        public string MoneyText
        {
            get => (string)GetValue(MoneyTextProperty);
            set => SetValue(MoneyTextProperty, value);
        }
        public Brush MoneyTextColor
        {
            get => (Brush)GetValue(MoneyTextColorProperty);
            set => SetValue(MoneyTextColorProperty, value);
        }

        public RoundedSquareInfo()
        {
            InitializeComponent();
        }
    }
}
