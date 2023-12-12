using ContractManagment.Client.MVVM.Model.Post;
using ContractManagment.Client.MVVM.Model.Records;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Post
{
    public interface IPostClient
    {
        Task<List<LongRecordModel>> GetByFilter(string key, string keyValue);
        public Task<PostModel> GetById(int id);
        public Task<List<LongRecordModel>> GetAll();
    }
}
