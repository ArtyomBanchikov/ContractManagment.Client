using ContractManagment.Client.MVVM.Model.User;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Xml.Linq;

namespace ContractManagment.Client.State.WebClients
{
    public class WebClient : IWebClient
    {
        public HttpClient Client { get; }
        public string Token { get; }

        public WebClient()
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            Client = new HttpClient(handler);
            XDocument document = XDocument.Load("appsettings.xml");
            XElement? settings = document.Element("settings");
            XElement? address = settings.Element("ServerAddress");
            Client.BaseAddress = new Uri(address.Value);
        }

        public LoginUserModel Login(ShortUserModel user)
        {
            var response = Client.PostAsJsonAsync($"/login", user).Result;
            LoginUserModel loginUser = response.Content.ReadFromJsonAsync<LoginUserModel>().Result;
            if (loginUser != null)
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginUser.Token);
            return loginUser;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public LoginUserModel TokenInfo()
        {
            LoginUserModel user = Client.GetFromJsonAsync<LoginUserModel>($"/tokeninfo/token").Result;
            return user;
        }
    }
}
