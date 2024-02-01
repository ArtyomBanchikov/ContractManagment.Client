using ContractManagment.Client.MVVM.Model.ClientIPTV;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientIPTV
{
    public class ClientIPTVAddParamClient : IReadClient<ClientIPTVAddParamModel>
    {
        private IWebClient _webClient;

        public ClientIPTVAddParamClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<ClientIPTVAddParamModel>> GetAll()
        {
            List<ClientIPTVAddParamModel> list = await _webClient.Client.GetFromJsonAsync<List<ClientIPTVAddParamModel>>("/ClientIPTVAddParam");
            return list;
        }

        public Task<ClientIPTVAddParamModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
