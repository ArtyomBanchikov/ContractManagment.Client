using ContractManagment.Client.MVVM.Model.ClientDigital;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientDigital
{
    class ClientDigitalClient : IReadClient<ClientDigitalModel>
    {
        private IWebClient _webClient;

        public ClientDigitalClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<ClientDigitalModel>> GetAll()
        {
            List<ClientDigitalModel> list = await _webClient.Client.GetFromJsonAsync<List<ClientDigitalModel>>("/ClientDigital");
            return list;
        }

        public async Task<ClientDigitalModel> GetById(int account)
        {
            return await _webClient.Client.GetFromJsonAsync<ClientDigitalModel>($"/ClientDigital/{account}");
        }
    }
}
