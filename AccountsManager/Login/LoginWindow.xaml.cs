﻿using System.Security;
using System.Windows;

namespace AccountsManager.Login
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IPassword
    {
        public LoginViewModel Login
        {
            get => DataContext as LoginViewModel;
            set => DataContext = value;
        }

        public SecureString Password => PasswordInput.SecurePassword;

        public LoginWindow()
        {
            InitializeComponent();

            Login = new LoginViewModel(this);
        }
    }
}
