using ContractManagment.Client.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients
{
    public class KeyClient : IReadWriteClient<KeyModel>
    {
        private IWebClient _webClient;

        public KeyClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public Task Create(KeyModel obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<KeyModel>> GetAll()
        {
            List<KeyModel> list = await _webClient.Client.GetFromJsonAsync<List<KeyModel>>("/Key");
            return list;
        }

        public Task<KeyModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(KeyModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
