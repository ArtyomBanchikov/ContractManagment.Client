using ContractManagment.Client.MVVM.Model.ClientInternet;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientInternet
{
    public class InternetAddParamClient : IReadClient<InternetAddParamModel>
    {
        private IWebClient _webClient;

        public InternetAddParamClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<InternetAddParamModel>> GetAll()
        {
            List<InternetAddParamModel> list = await _webClient.Client.GetFromJsonAsync<List<InternetAddParamModel>>("/InternetAddParam");
            return list;
        }

        public Task<InternetAddParamModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
