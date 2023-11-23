using ContractManagment.Client.MVVM.Model.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Client
{
    public class ClientAddParamClient : IReadClient<ClientAddParamModel>
    {
        private IWebClient _webClient;

        public ClientAddParamClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<ClientAddParamModel>> GetAll()
        {
            List<ClientAddParamModel> list = await _webClient.Client.GetFromJsonAsync<List<ClientAddParamModel>>("/ClientAddParam");
            return list;
        }

        public Task<ClientAddParamModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
