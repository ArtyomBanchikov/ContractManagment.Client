using ContractManagment.Client.MVVM.Model.ClientIPTV;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientIPTV
{
    public class IPTVAddParamClient : IReadClient<IPTVAddParamModel>
    {
        private IWebClient _webClient;

        public IPTVAddParamClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<IPTVAddParamModel>> GetAll()
        {
            List<IPTVAddParamModel> list = await _webClient.Client.GetFromJsonAsync<List<IPTVAddParamModel>>("/IPTVAddParam");
            return list;
        }

        public Task<IPTVAddParamModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
