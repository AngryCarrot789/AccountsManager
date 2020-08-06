using AccountsManager.ViewModels;
using AccountsManager.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace AccountsManager.Views
{
    /// <summary>
    /// Interaction logic for AccountCreatorWindow.xaml
    /// </summary>
    public partial class AccountCreatorWindow : Window, IAccountCreator
    {
        public AccountCreatorViewModel Creator
        {
            get => this.DataContext as AccountCreatorViewModel;
            set => this.DataContext = value;
        }

        public AccountCreatorWindow()
        {
            InitializeComponent();
            Closing += AccountCreatorWindow_Closing;

            Creator = new AccountCreatorViewModel(this);
        }

        private void AccountCreatorWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void ShowView()
        {
            this.Show();
        }

        public void HideView()
        {
            this.Hide();
        }
    }
}
