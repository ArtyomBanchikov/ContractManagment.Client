using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.State.Authenticators;
using System;
using System.Windows.Input;

namespace ContractManagment.Client.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        public LoginViewModel _loginVM;

        public LoginCommand(IAuthenticator authenticator, LoginViewModel loginVM)
        {
            _authenticator = authenticator;
            _loginVM = loginVM;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            bool succes = await _authenticator.Login(_loginVM.Login, parameter.ToString());
        }
    }
}
