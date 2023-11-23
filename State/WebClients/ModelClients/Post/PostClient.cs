using ContractManagment.Client.MVVM.Model.Post;
using ContractManagment.Client.MVVM.Model.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Post
{
    public class PostClient : IReadClient<PostModel>
    {
        private IWebClient _webClient;

        public PostClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<List<PostModel>> GetAll()
        {
            List<PostModel> list = await _webClient.Client.GetFromJsonAsync<List<PostModel>>("/Post");
            return list;
        }

        public Task<PostModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
