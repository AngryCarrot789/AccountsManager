using AccountsManager.Account.IO;
using AccountsManager.Helpers;
using AccountsManager.Login;
using AccountsManager.ViewModels;
using AccountsManager.Views.Interfaces;
using System;
using System.IO;
using System.Security;
using System.Windows;
using System.Windows.Media.Animation;

namespace AccountsManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public MainViewModel Model
        {
            get => DataContext as MainViewModel;
            set => DataContext = value;
        }

        public MainWindow()
        {
            InitializeComponent();
            Model = new MainViewModel(this);
        }

        public void Test()
        {
            
        }

        public void OpenEditorPanel()
        {
            DoubleAnimation da = new DoubleAnimation(0, 330, TimeSpan.FromMilliseconds(200));
            da.AccelerationRatio = 0.0;
            da.DecelerationRatio = 1.0;
            EditorPanel.BeginAnimation(WidthProperty, da);
        }

        public void CloseEditorPanel()
        {
            DoubleAnimation da = new DoubleAnimation(330, 0, TimeSpan.FromMilliseconds(200));
            da.AccelerationRatio = 0.0;
            da.DecelerationRatio = 1.0;
            EditorPanel.BeginAnimation(WidthProperty, da);
        }
    }
}
