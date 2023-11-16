using ContractManagment.Client.Commands;
using ContractManagment.Client.Core;
using ContractManagment.Client.State.Authenticators;
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

        public ICommand LoginCommand { get; }

        public LoginViewModel(IAuthenticator authenticator)
        {
            LoginCommand = new LoginCommandAsync(authenticator, this);
        }
    }
}
