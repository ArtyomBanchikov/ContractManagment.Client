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
            try
            {
                ShortUserModel loginUser = new() { Name = username, Password = password };
                CurrentUser = _webClient.Login(loginUser);
                return true;
            }
            catch(SocketException ex)
            {
                throw ex;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Logout()
        {
            CurrentUser = null;
            await _webClient.Logout();
            return true;
        }

        public async Task<LoginUserModel> TokenCheck(string token)
        {
            LoginUserModel loginUser = _webClient.TokenInfo(token);
            CurrentUser = loginUser;
            return loginUser;
        }
    }
}
