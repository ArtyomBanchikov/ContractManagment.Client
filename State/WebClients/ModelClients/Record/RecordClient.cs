using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.FilterParameters;
using ContractManagment.Client.MVVM.Model.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Record
{
    public class RecordClient : IRecordClient
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

        public async Task<List<LongRecordModel>> GetAll()
        {
            List<LongRecordModel> list = await _webClient.Client.GetFromJsonAsync<List<LongRecordModel>>("/Record");
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

        public async Task<List<LongRecordModel>> GetByFilter(string key, string keyValue)
        {
            return await _webClient.Client.GetFromJsonAsync<List<LongRecordModel>>($"/Record/{key}/{keyValue}");
        }
    }
}
