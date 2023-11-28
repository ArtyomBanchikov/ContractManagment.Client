using ContractManagment.Client.MVVM.Model.ClientDigital;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientDigital
{
    public class DigitalAddParamClient : IReadClient<DigitalAddParamModel>
    {
        private IWebClient _webClient;

        public DigitalAddParamClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<DigitalAddParamModel>> GetAll()
        {
            List<DigitalAddParamModel> list = await _webClient.Client.GetFromJsonAsync<List<DigitalAddParamModel>>("/DigitalAddParam");
            return list;
        }

        public Task<DigitalAddParamModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
