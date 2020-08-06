using AccountsManager.Login;
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
        public static void Startup()
        {
            LoginWindow login = new LoginWindow();
            login.Show();
        }

        public static void Shutdown()
        {
            Application.Current?.Shutdown();
        }
    }
}
