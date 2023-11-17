using ContractManagment.Client.MVVM.Model.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Post
{
    public class PostMetaClient : IReadClient<PostMetaModel>
    {
        public Task<List<PostMetaModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PostMetaModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
