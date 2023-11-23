using ContractManagment.Client.MVVM.Model.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Client
{
    public class AdditionalParameterClient : IReadClient<AdditionalParameterModel>
    {
        private IWebClient _webClient;

        public AdditionalParameterClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<AdditionalParameterModel>> GetAll()
        {
            List<AdditionalParameterModel> list = await _webClient.Client.GetFromJsonAsync<List<AdditionalParameterModel>>("/AdditionalParameter");
            return list;
        }

        public Task<AdditionalParameterModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
