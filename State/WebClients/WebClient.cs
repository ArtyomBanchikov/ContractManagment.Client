using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.Services.XmlServices;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            //var response = Client.PostAsJsonAsync($"/login", user).Result;
            //LoginUserModel loginUser = response.Content.ReadFromJsonAsync<LoginUserModel>().Result;
            LoginUserModel loginUser = await Client.PostAsJsonAsync("/login", user).Result.Content.ReadFromJsonAsync<LoginUserModel>();
            if (loginUser != null)
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginUser.Token);
            return loginUser;
        }

        public void Logout()
        {
            Client.DefaultRequestHeaders.Clear();
        }

        public async Task<LoginUserModel> TokenInfo(string token)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            LoginUserModel user = Client.GetFromJsonAsync<LoginUserModel>($"/userinfo/").Result;
            return user;
        }
    }
}
