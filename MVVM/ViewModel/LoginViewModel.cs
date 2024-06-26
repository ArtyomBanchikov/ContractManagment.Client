﻿using ContractManagment.Client.Commands;
using ContractManagment.Client.Core;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using System;
using System.Reflection;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private bool isRemember;
        public bool IsRemember
        {
            get { return isRemember; }
            set
            {
                isRemember = value;
                OnPropertyChanged();
            }
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        private string appVersion;
        public string AppVersion
        {
            get { return appVersion; }
            set
            {
                appVersion = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }
        public event EventHandler LoginSuccessful;

        public LoginViewModel(IAuthenticator authenticator, IXmlService xmlProvider)
        {
            if (!string.IsNullOrEmpty(xmlProvider.LastLogin))
                Login = xmlProvider.LastLogin;
            LoginCommand = new LoginCommandAsync(authenticator, this, xmlProvider);
            AppVersion = "ContractManagment v" + Assembly.GetEntryAssembly().GetName().Version.ToString(); 
        }
        public void OnLoginSuccessful()
        {
            LoginSuccessful?.Invoke(this, EventArgs.Empty);
        }
    }
}
