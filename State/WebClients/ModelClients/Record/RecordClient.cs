using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Record
{
    public class RecordClient : IReadWriteClient<RecordModel>
    {
        private IWebClient _webClient;

        public RecordClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task Create(RecordModel obj)
        {
            await _webClient.Client.PostAsJsonAsync("/Record", obj);
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RecordModel>> GetAll()
        {
            List<RecordModel> list = await _webClient.Client.GetFromJsonAsync<List<RecordModel>>("/Record");
            return list;
        }

        public Task<RecordModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(RecordModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
