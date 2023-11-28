using ContractManagment.Client.MVVM.Model.Records;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Record
{
    public class RecordKeyClient : IReadWriteClient<RecordKeyModel>
    {
        private IWebClient _webClient;

        public RecordKeyClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task Create(RecordKeyModel obj)
        {
            await _webClient.Client.PostAsJsonAsync("/RecordKey", obj);
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RecordKeyModel>> GetAll()
        {
            List<RecordKeyModel> list = await _webClient.Client.GetFromJsonAsync<List<RecordKeyModel>>("/RecordKey");
            return list;
        }

        public Task<RecordKeyModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(RecordKeyModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
