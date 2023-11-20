using ContractManagment.Client.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients
{
    public class ContractClient : IReadWriteClient<ContractModel>
    {
        private IWebClient _webClient;

        public ContractClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task Create(ContractModel obj)
        {
            await _webClient.Client.PostAsJsonAsync("/Contract", obj);
        }

        public async Task DeleteById(int id)
        {
            await _webClient.Client.DeleteAsync($"/Contract/{id}");
        }

        public async Task<List<ContractModel>> GetAll()
        {
            List<ContractModel> list = await _webClient.Client.GetFromJsonAsync<List<ContractModel>>("/Contract");
            return list;
        }

        public Task<ContractModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ContractModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
