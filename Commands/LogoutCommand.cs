using ContractManagment.Client.MVVM.View;
using ContractManagment.Client.MVVM.View.Factories;
using ContractManagment.Client.Services;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;

namespace ContractManagment.Client.Commands
{
    public class LogoutCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly IXmlService _xmlService;

        public LogoutCommand(IAuthenticator authenticator, IXmlService xmlService)
        {
            _authenticator = authenticator;
            _xmlService = xmlService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _authenticator.Logout();
            _xmlService.IsRemember = false;
            _xmlService.Token = "";
            MainWindow mainWindow = MainWindowFactory.Window;
            LoginView loginView = LoginWindowFactory.NewWindow();
            loginView.Show();
            mainWindow.Exitable = false;
            mainWindow.Close();
            Application.Current.MainWindow = loginView;
        }
    }
}
