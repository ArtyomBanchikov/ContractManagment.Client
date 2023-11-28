using ContractManagment.Client.MVVM.Model.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Post
{
    public class PostMetaClient : IReadClient<PostMetaModel>
    {
        private IWebClient _webClient;

        public PostMetaClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<PostMetaModel>> GetAll()
        {
            List<PostMetaModel> list = await _webClient.Client.GetFromJsonAsync<List<PostMetaModel>>("/PostMeta");
            return list;
        }

        public Task<PostMetaModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
