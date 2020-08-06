using AccountsManager.Account.IO;
using AccountsManager.CClipboard;
using AccountsManager.Helpers;
using AccountsManager.Utilities;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace AccountsManager.Account
{
    public class AccountViewModel : BaseViewModel
    {
        private string _accountName;
        private string _email;
        private string _username;
        private SecureString _password;
        private string _dateOfBirth;
        private string _securityInfo;
        private string _extraInfo1;
        private string _extraInfo2;
        private string _extraInfo3;
        private string _extraInfo4;
        private string _extraInfo5;
        private string _extraInfo6;

        public string AccountName
        {
            get => _accountName;
            set => RaisePropertyChanged(ref _accountName, value);
        }

        public string Email
        {
            get => _email;
            set => RaisePropertyChanged(ref _email, value);
        }

        public string Username
        {
            get => _username;
            set => RaisePropertyChanged(ref _username, value);
        }

        public SecureString Password
        {
            get => _password;
            set => RaisePropertyChanged(ref _password, value);
        }

        public string DateOfBirth
        {
            get => _dateOfBirth;
            set => RaisePropertyChanged(ref _dateOfBirth, value);
        }

        public string SecurityInfo
        {
            get => _securityInfo;
            set => RaisePropertyChanged(ref _securityInfo, value);
        }

        public string ExtraInfo1
        {
            get => _extraInfo1;
            set => RaisePropertyChanged(ref _extraInfo1, value);
        }

        public string ExtraInfo2
        {
            get => _extraInfo2;
            set => RaisePropertyChanged(ref _extraInfo2, value);
        }

        public string ExtraInfo3
        {
            get => _extraInfo3;
            set => RaisePropertyChanged(ref _extraInfo3, value);
        }

        public string ExtraInfo4
        {
            get => _extraInfo4;
            set => RaisePropertyChanged(ref _extraInfo4, value);
        }

        public string ExtraInfo5
        {
            get => _extraInfo5;
            set => RaisePropertyChanged(ref _extraInfo5, value);
        }

        public string ExtraInfo6
        {
            get => _extraInfo6;
            set => RaisePropertyChanged(ref _extraInfo6, value);
        }

        public ICommand CopyDetails { get; }
        public ICommand ShowPasswordCommand { get; set; }

        public AccountViewModel()
        {
            CopyDetails = new CommandParam<string>(CopyDetailsToClipboard);
            ShowPasswordCommand = new Command(ShowPassword);
        }

        public void CopyDetailsToClipboard(string detailsToCpy)
        {
            switch (detailsToCpy)
            {
                case "a": CustomClipboard.SetTextObject(AccountName); break;
                case "e": CustomClipboard.SetTextObject(Email); break;
                case "u": CustomClipboard.SetTextObject(Username); break;
                case "p": CustomClipboard.SetTextObject(Password.GetUnsecure()); break;
                case "d": CustomClipboard.SetTextObject(DateOfBirth); break;
                case "s": CustomClipboard.SetTextObject(SecurityInfo); break;
                case "1": CustomClipboard.SetTextObject(ExtraInfo1); break;
                case "2": CustomClipboard.SetTextObject(ExtraInfo2); break;
                case "3": CustomClipboard.SetTextObject(ExtraInfo3); break;
                case "4": CustomClipboard.SetTextObject(ExtraInfo4); break;
                case "5": CustomClipboard.SetTextObject(ExtraInfo5); break;
            }
        }

        public void ShowPassword()
        {
            if (Password != null)
            {
                MessageBox.Show(Password.GetUnsecure(), "Password");
            }
        }

        public void FromUnsecure(UnsecureAccountModel uam)
        {
            AccountName  = uam.AccountName;
            Email        = uam.Email;
            Username     = uam.Username;
            if (uam.Password != null)
                Password = uam.Password.CreateSecure();
            DateOfBirth  = uam.DateOfBirth;
            SecurityInfo = uam.SecurityInfo;
            ExtraInfo1   = uam.ExtraInfo1;
            ExtraInfo2   = uam.ExtraInfo2;
            ExtraInfo3   = uam.ExtraInfo3;
            ExtraInfo4   = uam.ExtraInfo4;
            ExtraInfo5   = uam.ExtraInfo5;
            ExtraInfo6   = uam.ExtraInfo6;
        }

        public AccountViewModel Duplicate()
        {
            return new AccountViewModel()
            {
                AccountName = AccountName,
                Email = Email,
                Username = Username,
                Password = Password,
                DateOfBirth = DateOfBirth,
                SecurityInfo = SecurityInfo,
                ExtraInfo1 = ExtraInfo1,
                ExtraInfo2 = ExtraInfo2,
                ExtraInfo3 = ExtraInfo3,
                ExtraInfo4 = ExtraInfo4,
                ExtraInfo5 = ExtraInfo5,
                ExtraInfo6 = ExtraInfo6
            };
        }

        public UnsecureAccountModel CreateUnsecureAccount()
        {
            UnsecureAccountModel UAM = new UnsecureAccountModel()
            {
                AccountName = AccountName,
                Email = Email,
                Username = Username,
                DateOfBirth = DateOfBirth,
                SecurityInfo = SecurityInfo,
                ExtraInfo1 = ExtraInfo1,
                ExtraInfo2 = ExtraInfo2,
                ExtraInfo3 = ExtraInfo3,
                ExtraInfo4 = ExtraInfo4,
                ExtraInfo5 = ExtraInfo5,
                ExtraInfo6 = ExtraInfo6
            };
            if (Password != null)
                UAM.Password = Password.GetUnsecure();

            return UAM;
        }
    }
}
