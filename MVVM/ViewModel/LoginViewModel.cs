using ContractManagment.Client.Commands;
using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.View;
using ContractManagment.Client.State.Authenticators;
using System.Windows;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
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

        public ICommand LoginCommand { get; }

        public LoginViewModel(IAuthenticator authenticator)
        {
            LoginCommand = new LoginCommand(authenticator, this);
        }
    }
}
