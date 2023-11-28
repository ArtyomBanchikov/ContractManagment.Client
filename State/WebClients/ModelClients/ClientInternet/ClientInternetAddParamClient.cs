using ContractManagment.Client.MVVM.Model.ClientInternet;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientInternet
{
    public class ClientInternetAddParamClient : IReadClient<ClientInternetAddParamModel>
    {
        private IWebClient _webClient;

        public ClientInternetAddParamClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<ClientInternetAddParamModel>> GetAll()
        {
            List<ClientInternetAddParamModel> list = await _webClient.Client.GetFromJsonAsync<List<ClientInternetAddParamModel>>("/ClientInternetAddParam");
            return list;
        }

        public Task<ClientInternetAddParamModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
