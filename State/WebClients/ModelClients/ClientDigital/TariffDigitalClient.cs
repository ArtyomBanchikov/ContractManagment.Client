using ContractManagment.Client.MVVM.Model.ClientDigital;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientDigital
{
    public class TariffDigitalClient : IReadClient<TariffDigitalModel>
    {
        private IWebClient _webClient;

        public TariffDigitalClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<TariffDigitalModel>> GetAll()
        {
            List<TariffDigitalModel> list = await _webClient.Client.GetFromJsonAsync<List<TariffDigitalModel>>("/TariffDigital");
            return list;
        }

        public async Task<TariffDigitalModel> GetById(int id)
        {
            return await _webClient.Client.GetFromJsonAsync<TariffDigitalModel>($"/TariffDigital/{id}");
        }
    }
}
