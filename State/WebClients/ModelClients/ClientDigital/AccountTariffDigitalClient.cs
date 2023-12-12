using ContractManagment.Client.MVVM.Model.ClientDigital;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientDigital
{
    public class AccountTariffDigitalClient : IReadClient<AccountTariffDigitalModel>
    {
        private IWebClient _webClient;

        public AccountTariffDigitalClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<AccountTariffDigitalModel>> GetAll()
        {
            List<AccountTariffDigitalModel> list = await _webClient.Client.GetFromJsonAsync<List<AccountTariffDigitalModel>>("/AccountTariffDigital");
            return list;
        }

        public async Task<AccountTariffDigitalModel> GetById(int id)
        {
            return await _webClient.Client.GetFromJsonAsync<AccountTariffDigitalModel>($"/AccountTariffDigital/{id}");
        }
    }
}
