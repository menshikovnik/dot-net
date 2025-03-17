using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Controls;
using AvaloniaApp.ViewModels;

namespace AvaloniaApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}