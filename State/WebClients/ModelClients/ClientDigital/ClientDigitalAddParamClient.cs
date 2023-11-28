using ContractManagment.Client.MVVM.Model.ClientDigital;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientDigital
{
    public class ClientDigitalAddParamClient : IReadClient<ClientDigitalAddParamModel>
    {
        private IWebClient _webClient;

        public ClientDigitalAddParamClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<ClientDigitalAddParamModel>> GetAll()
        {
            List<ClientDigitalAddParamModel> list = await _webClient.Client.GetFromJsonAsync<List<ClientDigitalAddParamModel>>("/ClientDigitalAddParam");
            return list;
        }

        public Task<ClientDigitalAddParamModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
