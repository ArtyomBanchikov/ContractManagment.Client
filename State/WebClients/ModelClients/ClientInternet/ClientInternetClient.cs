using ContractManagment.Client.MVVM.Model.ClientInternet;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientInternet
{
    public class ClientInternetClient : IReadClient<ClientInternetModel>
    {
        private IWebClient _webClient;

        public ClientInternetClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<ClientInternetModel>> GetAll()
        {
            List<ClientInternetModel> list = await _webClient.Client.GetFromJsonAsync<List<ClientInternetModel>>("/ClientInternet");
            return list;
        }

        public async Task<ClientInternetModel> GetById(int account)
        {
            return await _webClient.Client.GetFromJsonAsync<ClientInternetModel>($"/ClientInternet/{account}");
        }
    }
}
