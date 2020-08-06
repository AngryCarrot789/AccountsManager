using AccountsManager.Account;
using AccountsManager.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AccountsManager.Login
{
    public class LoginViewModel : BaseViewModel
    {
        public IPassword Password { get; private set; }

        public ICommand ShowPasswordCommand { get; }

        public LoginViewModel(IPassword password)
        {
            Password = password;

            ShowPasswordCommand = new Command(ShowPassword);
        }

        public void ShowPassword()
        {
            MessageBox.Show(Password.Password.GetUnsecure());
        }
    }
}
