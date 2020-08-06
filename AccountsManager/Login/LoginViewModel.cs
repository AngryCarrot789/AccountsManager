using AccountsManager.Account;
using AccountsManager.Utilities;
using System.Windows;
using AccountsManager.Helpers;
using System.Windows.Input;

namespace AccountsManager.Login
{
    public class LoginViewModel : BaseViewModel
    {
        public IPassword Password { get; private set; }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IPassword password)
        {
            Password = password;

            LoginCommand = new Command(Login);
        }

        public void Login()
        {
            string pass = Password.Password.GetUnsecure();
        }
    }
}
