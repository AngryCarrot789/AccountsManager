using AccountsManager.Account.IO;
using AccountsManager.AppInstance;
using AccountsManager.CClipboard;
using AccountsManager.Utilities;
using AccountsManager.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;

namespace AccountsManager.ViewModels
{
    public class AccountCreatorViewModel : BaseViewModel
    {
        private string _accountName;
        private string _email;
        private string _username;
        private string _password;
        private string _dateOfBirth;
        private string _securityInfo;
        private string _extraInfo1;
        private string _extraInfo2;
        private string _extraInfo3;
        private string _extraInfo4;
        private string _extraInfo5;
        private string _extraInfo6;

        #region Account Info

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

        public string Password
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

        #endregion

        public IAccountCreator View { get; }

        public ICommand AddAccountCommand { get; }

        public ICommand CopyToClipboardCommand { get; }
        public ICommand PasteToInputCommand { get; }

        public Action<UnsecureAccountModel> AddAccountCallback { get; set; }

        public AccountCreatorViewModel(IAccountCreator creator)
        {
            View = creator;

            CopyToClipboardCommand = new CommandParam<string>(CopyToClipboard);
            PasteToInputCommand = new CommandParam<string>(PasteToInput);
            AddAccountCommand = new Command(AddAccount);
        }

        public void ResetVariables()
        {
            AccountName = "";
            Email = "";
            Username = "";
            Password = "";
            DateOfBirth = "";
            SecurityInfo = "";
            ExtraInfo1 = "";
            ExtraInfo2 = "";
            ExtraInfo3 = "";
            ExtraInfo4 = "";
            ExtraInfo5 = "";
            ExtraInfo6 = "";
        }

        public void AddAccount()
        {
            UnsecureAccountModel uam = new UnsecureAccountModel()
            {
                AccountName  = AccountName,
                Email        = Email,
                Username     = Username,
                Password     = Password,
                DateOfBirth  = DateOfBirth,
                SecurityInfo = SecurityInfo,
                ExtraInfo1   = ExtraInfo1,
                ExtraInfo2   = ExtraInfo2,
                ExtraInfo3   = ExtraInfo3,
                ExtraInfo4   = ExtraInfo4,
                ExtraInfo5   = ExtraInfo5,
                ExtraInfo6   = ExtraInfo6
            };

            AddAccountCallback?.Invoke(uam);
        }

        public void CopyToClipboard(string whichAccountInfo)
        {
            switch (whichAccountInfo)
            {
                case "a": CustomClipboard.SetTextObject(AccountName); break;
                case "e": CustomClipboard.SetTextObject(Email); break;
                case "u": CustomClipboard.SetTextObject(Username); break;
                case "p": CustomClipboard.SetTextObject(Password); break;
                case "d": CustomClipboard.SetTextObject(DateOfBirth); break;
                case "s": CustomClipboard.SetTextObject(SecurityInfo); break;
                case "1": CustomClipboard.SetTextObject(ExtraInfo1); break;
                case "2": CustomClipboard.SetTextObject(ExtraInfo2); break;
                case "3": CustomClipboard.SetTextObject(ExtraInfo3); break;
                case "4": CustomClipboard.SetTextObject(ExtraInfo4); break;
                case "5": CustomClipboard.SetTextObject(ExtraInfo5); break;
            }
        }

        public void PasteToInput(string whichAccountInfo)
        {
            string clipboard = CustomClipboard.GetTextObject().ToString();

            if (string.IsNullOrEmpty(clipboard))
                return;

            switch (whichAccountInfo)
            {
                case "a": AccountName = clipboard; break;
                case "e": Email = clipboard; break;
                case "u": Username = clipboard; break;
                case "p": Password = clipboard; break;
                case "d": DateOfBirth = clipboard; break;
                case "s": SecurityInfo = clipboard; break;
                case "1": ExtraInfo1 = clipboard; break;
                case "2": ExtraInfo2 = clipboard; break;
                case "3": ExtraInfo3 = clipboard; break;
                case "4": ExtraInfo4 = clipboard; break;
                case "5": ExtraInfo5 = clipboard; break;
            }
        }
    }
}
