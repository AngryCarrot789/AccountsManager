using AccountsManager.Login;
using AccountsManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountsManager.AppInstance
{
    public static class ThisApplication
    {
        public static MainWindow MainWindow { get; set; }
        public static AccountCreatorWindow AccountCreator { get; set; }

        public static void Startup()
        {
            //LoginWindow login = new LoginWindow();
            //login.Show();

            AccountCreator = new AccountCreatorWindow();
            MainWindow = new MainWindow();

            Application.Current.MainWindow = MainWindow;

            MainWindow.Show();
        }

        public static void Shutdown()
        {
            Application.Current?.Shutdown();
        }
    }
}
