using ContractManagment.Client.MVVM.Model.ClientIPTV;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.ClientIPTV
{
    public class TariffIPTVClient : IReadClient<TariffIPTVModel>
    {
        private IWebClient _webClient;

        public TariffIPTVClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<TariffIPTVModel>> GetAll()
        {
            List<TariffIPTVModel> list = await _webClient.Client.GetFromJsonAsync<List<TariffIPTVModel>>("/TariffIPTV");
            return list;
        }

        public async Task<TariffIPTVModel> GetById(int id)
        {
            return await _webClient.Client.GetFromJsonAsync<TariffIPTVModel>($"/TariffIPTV/{id}");
        }
    }
}
