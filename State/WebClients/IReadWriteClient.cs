using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients
{
    public interface IReadWriteClient<T> where T : class
    {
        public IWebClient Client { get; }
        public Task<T> GetById(int id);
        public Task<List<T>> GetAll();
        public Task DeleteById(int id);
        public Task Create(T obj);
        public Task Update(T obj);
    }
}
