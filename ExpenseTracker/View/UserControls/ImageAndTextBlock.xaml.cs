using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExpenseTracker.View.UserControls
{
    public partial class ImageAndTextBlock : UserControl
    {
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register(nameof(ImagePath), typeof(ImageSource), typeof(ImageAndTextBlock),
            new PropertyMetadata(null));

        public new static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register(nameof(FontSize), typeof(double), typeof(ImageAndTextBlock),
            new PropertyMetadata(default(double)));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(ImageAndTextBlock),
            new PropertyMetadata(string.Empty));

        public new static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register(nameof(Foreground), typeof(Brush), typeof(ImageAndTextBlock),
            new PropertyMetadata(default(Brush)));

        public ImageSource ImagePath
        {
            get => (ImageSource)GetValue(ImagePathProperty);
            set => SetValue(ImagePathProperty, value);
        }

        public new double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public new Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public ImageAndTextBlock()
        {
            InitializeComponent();
        }
    }
}
