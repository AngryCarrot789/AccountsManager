using AccountsManager.Account;
using AccountsManager.Account.IO;
using AccountsManager.AppInstance;
using AccountsManager.CClipboard;
using AccountsManager.Helpers;
using AccountsManager.Login;
using AccountsManager.Utilities;
using AccountsManager.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AccountsManager.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool _editorPanelExpanded;
        public bool EditorPanelExpanded
        {
            get => _editorPanelExpanded;
            set => RaisePropertyChanged(ref _editorPanelExpanded, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => RaisePropertyChanged(ref _password, value);
        }

        private AccountViewModel _selectedAccount;
        public AccountViewModel SelectedAccount
        {
            get => _selectedAccount;
            set => RaisePropertyChanged(ref _selectedAccount, value, SelectionChanged);
        }

        public ObservableCollection<AccountViewModel> Accounts { get; set; }

        public IMainWindow MainView { get; }

        public AccountCreatorViewModel Creator { get; set; }

        public ICommand ShowCreatorCommand { get; }
        public ICommand AutoShowEditorPanelCommand { get; }

        public ICommand CopyToClipboardCommand { get; }
        public ICommand ShowPasswordCommad { get; }

        public MainViewModel(IMainWindow window)
        {
            MainView = window;

            Accounts = new ObservableCollection<AccountViewModel>();

            Creator = ThisApplication.AccountCreator.Creator;
            Creator.AddAccountCallback = CreateAndAddAccountFromUnsecure;

            // probably not 100% mvvm but idk how else to do it
            ThisApplication.AccountCreator.Creator = Creator;

            ShowCreatorCommand = new Command(ShowCreator);
            AutoShowEditorPanelCommand = new Command(AutoShowEditorPanel);

            CopyToClipboardCommand = new CommandParam<string>(CopyToClipboard);
            ShowPasswordCommad = new Command(ShowPassword);
        }

        public void CopyToClipboard(string whichAccountInfo)
        {
            if (SelectedAccount != null)
            {
                switch (whichAccountInfo)
                {
                    case "a": CustomClipboard.SetTextObject(SelectedAccount.AccountName); break;
                    case "e": CustomClipboard.SetTextObject(SelectedAccount.Email); break;
                    case "u": CustomClipboard.SetTextObject(SelectedAccount.Username); break;
                    case "p": CustomClipboard.SetTextObject(SelectedAccount.Password.GetUnsecure()); break;
                    case "d": CustomClipboard.SetTextObject(SelectedAccount.DateOfBirth); break;
                    case "s": CustomClipboard.SetTextObject(SelectedAccount.SecurityInfo); break;
                    case "1": CustomClipboard.SetTextObject(SelectedAccount.ExtraInfo1); break;
                    case "2": CustomClipboard.SetTextObject(SelectedAccount.ExtraInfo2); break;
                    case "3": CustomClipboard.SetTextObject(SelectedAccount.ExtraInfo3); break;
                    case "4": CustomClipboard.SetTextObject(SelectedAccount.ExtraInfo4); break;
                    case "5": CustomClipboard.SetTextObject(SelectedAccount.ExtraInfo5); break;
                }
            }
        }

        public void ShowPassword()
        {
            if (SelectedAccount?.Password != null)
            {
                MessageBox.Show(SelectedAccount.Password.GetUnsecure(), "Password");
            }
        }

        private void ShowCreator()
        {
            Creator.View.ShowView();
        }

        private void HideCreator()
        {
            Creator.View.HideView();
        }

        private void ResetCreator()
        {
            Creator.ResetVariables();
        }

        public void AutoShowEditorPanel()
        {
            if (EditorPanelExpanded)
                CloseEditorPanel();
            else
                OpenEditorPanel();

            EditorPanelExpanded = !EditorPanelExpanded;
        }

        public void OpenEditorPanel()
        {
            MainView.OpenEditorPanel();
        }

        public void CloseEditorPanel()
        {
            MainView.CloseEditorPanel();
        }

        public void CreateAndAddAccountFromUnsecure(UnsecureAccountModel uam)
        {
            AddAccount(CreateSecureFromUnsecure(uam));
            ResetCreator();
            HideCreator();
        }

        public AccountViewModel CreateSecureFromUnsecure(UnsecureAccountModel uam)
        {
            AccountViewModel avm = new AccountViewModel();
            avm.FromUnsecure(uam);
            return avm;
        }

        public void AddAccount(AccountViewModel account)
        {
            Accounts.Add(account);
        }


        public void SelectionChanged()
        {
            AccountViewModel selected = SelectedAccount;

            Password = selected.Password.GetUnsecure();
        }


    }
}
