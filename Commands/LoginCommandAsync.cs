using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.State.Authenticators;
using System.Threading.Tasks;

namespace ContractManagment.Client.Commands
{
    public class LoginCommandAsync : AsyncBaseCommand
    {
        private readonly IAuthenticator _authenticator;
        public LoginViewModel _loginVM;

        public LoginCommandAsync(IAuthenticator authenticator, LoginViewModel loginVM)
        {
            _authenticator = authenticator;
            _loginVM = loginVM;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            bool succes = await _authenticator.Login(_loginVM.Login, parameter.ToString());
        }
    }
}
