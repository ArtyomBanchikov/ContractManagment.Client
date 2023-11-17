using ContractManagment.Client.MVVM.Model.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Post
{
    public class PostClient : IReadClient<PostModel>
    {
        public Task<List<PostModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PostModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
