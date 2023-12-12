using ContractManagment.Client.MVVM.Model.ClientInternet;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientInternet
{
    public class TariffInternetClient : IReadClient<TariffInternetModel>
    {
        private IWebClient _webClient;

        public TariffInternetClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<TariffInternetModel>> GetAll()
        {
            List<TariffInternetModel> list = await _webClient.Client.GetFromJsonAsync<List<TariffInternetModel>>("/TariffInternet");
            return list;
        }

        public async Task<TariffInternetModel> GetById(int id)
        {
            return await _webClient.Client.GetFromJsonAsync<TariffInternetModel>($"/TariffInternet/{id}");
        }
    }
}
