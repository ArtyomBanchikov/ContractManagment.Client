using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ContractManagment.Client.Commands
{
    public class LoginCommandAsync : AsyncBaseCommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly IXmlService _xmlProvider;
        public LoginViewModel _loginVM;

        public LoginCommandAsync(IAuthenticator authenticator, LoginViewModel loginVM, IXmlService xmlProvider)
        {
            _authenticator = authenticator;
            _loginVM = loginVM;
            _xmlProvider = xmlProvider;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox?.Password;
            await _authenticator.Login(_loginVM.Login, password);
            if (_loginVM.IsRemember)
            {
                _xmlProvider.IsRemember = true;
                _xmlProvider.Token = _authenticator.CurrentUser.Token;
            }
            else if (_xmlProvider.IsRemember)
            {
                _xmlProvider.IsRemember = false;
                _xmlProvider.Token = "";
            }
            _xmlProvider.LastLogin = _loginVM.Login;
            _loginVM.OnLoginSuccessful();
        }
    }
}
