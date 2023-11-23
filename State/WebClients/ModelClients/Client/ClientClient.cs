using ContractManagment.Client.MVVM.Model.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Client
{
    public class ClientClient : IReadClient<ClientModel>
    {
        private IWebClient _webClient;

        public ClientClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<ClientModel>> GetAll()
        {
            List<ClientModel> list = await _webClient.Client.GetFromJsonAsync<List<ClientModel>>("/Client");
            return list;
        }

        public async Task<ClientModel> GetById(int account)
        {
            return await _webClient.Client.GetFromJsonAsync<ClientModel>($"/Client/{account}");
        }
    }
}
