using AccountsManager.ViewModels;
using System.Windows;

namespace AccountsManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel Model
        {
            get => DataContext as MainViewModel;
            set => DataContext = value;
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
