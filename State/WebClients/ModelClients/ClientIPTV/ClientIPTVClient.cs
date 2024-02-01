using ContractManagment.Client.MVVM.Model.ClientIPTV;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientIPTV
{
    public class ClientIPTVClient : IReadClient<ClientIPTVModel>
    {
        private IWebClient _webClient;

        public ClientIPTVClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<ClientIPTVModel>> GetAll()
        {
            List<ClientIPTVModel> list = await _webClient.Client.GetFromJsonAsync<List<ClientIPTVModel>>("/ClientIPTV");
            return list;
        }

        public async Task<ClientIPTVModel> GetById(int account)
        {
            return await _webClient.Client.GetFromJsonAsync<ClientIPTVModel>($"/ClientIPTV/{account}");
        }
    }
}
