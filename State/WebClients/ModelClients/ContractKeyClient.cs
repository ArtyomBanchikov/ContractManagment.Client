using ContractManagment.Client.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients
{
    public class ContractKeyClient : IReadWriteClient<ContractKeyModel>
    {
        private IWebClient _webClient;

        public ContractKeyClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public Task Create(ContractKeyModel obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContractKeyModel>> GetAll()
        {
            List<ContractKeyModel> list = await _webClient.Client.GetFromJsonAsync<List<ContractKeyModel>>("/ContractKey");
            return list;
        }

        public Task<ContractKeyModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ContractKeyModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
