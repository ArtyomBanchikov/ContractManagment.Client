using ContractManagment.Client.MVVM.Model.ClientInternet;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientInternet
{
    public class AccountTariffInternetClient : IReadClient<AccountTariffInternetModel>
    {
        private IWebClient _webClient;

        public AccountTariffInternetClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<AccountTariffInternetModel>> GetAll()
        {
            List<AccountTariffInternetModel> list = await _webClient.Client.GetFromJsonAsync<List<AccountTariffInternetModel>>("/AccountTariffInternet");
            return list;
        }

        public async Task<AccountTariffInternetModel> GetById(int id)
        {
            return await _webClient.Client.GetFromJsonAsync<AccountTariffInternetModel>($"/AccountTariffInternet/{id}");
        }
    }
}
