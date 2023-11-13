using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model.User;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContractManagment.Client.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private LoginUserModel _currentUser;
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

        private HttpClient _client;

        public Authenticator()
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            _client = new HttpClient(handler);
            XDocument document = XDocument.Load("appsettings.xml");
            XElement? settings = document.Element("settings");
            XElement? address = settings.Element("ServerAddress");
            _client.BaseAddress = new Uri(address.Value);
        }


        public async Task<bool> Login(string username, string password)
        {
            try
            {
                ShortUserModel loginUser = new() { Name = username, Password = password };
                CurrentUser = await _client.PostAsJsonAsync("/login", loginUser).Result.Content.ReadAsAsync<LoginUserModel>();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
