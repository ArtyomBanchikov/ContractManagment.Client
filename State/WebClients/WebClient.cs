using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.Services.XmlServices;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients
{
    public class WebClient : IWebClient
    {
        public HttpClient Client { get; }
        public string Token { get; }

        public WebClient(IXmlService xmlProvider)
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            Client = new HttpClient(handler);
            Client.BaseAddress = new Uri(xmlProvider.ServerAddress);
        }

        public async Task<LoginUserModel> Login(ShortUserModel user)
        {
            var response = await Client.PostAsJsonAsync("/login", user);
            LoginUserModel loginUser = await response.Content.ReadFromJsonAsync<LoginUserModel>();
            if (loginUser != null &&
                loginUser.Name != null &&
                loginUser.Token != null &&
                loginUser.Role != null)
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginUser.Token);
            else
                throw new Exception("Неверный логин/пароль");
            return loginUser;
        }

        public void Logout()
        {
            Client.DefaultRequestHeaders.Clear();
        }

        public async Task<LoginUserModel> TokenInfo(string token)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            LoginUserModel user = await Client.GetFromJsonAsync<LoginUserModel>($"/userinfo/");
            return user;
        }
    }
}
