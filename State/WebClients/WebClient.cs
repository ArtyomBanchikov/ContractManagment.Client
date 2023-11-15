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

        public LoginUserModel Login(ShortUserModel user)
        {
            var response = Client.PostAsJsonAsync($"/login", user).Result;
            LoginUserModel loginUser = response.Content.ReadFromJsonAsync<LoginUserModel>().Result;
            if (loginUser != null)
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginUser.Token);
            return loginUser;
        }

        public async Task<bool> Logout()
        {
            var response = await Client.GetAsync("/logout");
            Client.DefaultRequestHeaders.Clear();
            return true;
        }

        public LoginUserModel TokenInfo(string token)
        {
            try
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                LoginUserModel user = Client.GetFromJsonAsync<LoginUserModel>($"/userinfo/").Result;
                return user;
            }
            catch (Exception ex) when (ex.InnerException.Message == "Response status code does not indicate success: 404 (Not Found).")
            {
                throw new Exception("Ранее сохранённый пользователь больше не действителен");
            }
            catch (Exception ex) when (ex.InnerException.Message == "Response status code does not indicate success: 401 (Unauthorized).")
            {
                throw new Exception("Срок авторизации истёк");
            }
            catch
            {
                throw new Exception("Не удалось подключиться к серверу");
            }
        }
    }
}
