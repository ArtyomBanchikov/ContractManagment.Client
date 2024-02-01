using ContractManagment.Client.MVVM.Model.ClientIPTV;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientIPTV
{
    public class AccountTariffIPTVClient : IReadClient<AccountTariffIPTVModel>
    {
        private IWebClient _webClient;

        public AccountTariffIPTVClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<AccountTariffIPTVModel>> GetAll()
        {
            List<AccountTariffIPTVModel> list = await _webClient.Client.GetFromJsonAsync<List<AccountTariffIPTVModel>>("/AccountTariffIPTV");
            return list;
        }

        public async Task<AccountTariffIPTVModel> GetById(int id)
        {
            return await _webClient.Client.GetFromJsonAsync<AccountTariffIPTVModel>($"/AccountTariffIPTV/{id}");
        }
    }
}
