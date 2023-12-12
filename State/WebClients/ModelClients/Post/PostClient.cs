using ContractManagment.Client.MVVM.Model.Post;
using ContractManagment.Client.MVVM.Model.Records;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Post
{
    public class PostClient : IPostClient
    {
        private IWebClient _webClient;

        public PostClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<LongRecordModel>> GetByFilter(string key, string keyValue)
        {
            return await _webClient.Client.GetFromJsonAsync<List<LongRecordModel>>($"/Post/{key}/{keyValue}");
        }

        public Task<PostModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LongRecordModel>> GetAll()
        {
            return await _webClient.Client.GetFromJsonAsync<List<LongRecordModel>>("/Post");
        }
    }
}
