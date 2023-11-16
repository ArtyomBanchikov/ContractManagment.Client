using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.State.WebClients;
using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContractManagment.Client.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private LoginUserModel _currentUser;
        private IWebClient _webClient;
        public LoginUserModel CurrentUser {
            get
            {
                return _currentUser;
            }
            private set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
                OnPropertyChanged(nameof(IsLoggedIn));
            } 
        }
        public bool IsLoggedIn => CurrentUser != null;

        public Authenticator(IWebClient client)
        {
            _webClient = client;
        }


        public async Task<bool> Login(string username, string password)
        {
            ShortUserModel loginUser = new() { Name = username, Password = password };
            CurrentUser = await _webClient.Login(loginUser);
            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
            _webClient.Logout();
        }

        public async Task<LoginUserModel> TokenCheck(string token)
        {
            LoginUserModel loginUser = await _webClient.TokenInfo(token);
            CurrentUser = loginUser;
            return loginUser;
        }
    }
}
