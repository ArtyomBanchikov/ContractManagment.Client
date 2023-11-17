using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients
{
    public interface IReadClient<T> where T : class
    {
        public IWebClient Client { get; }
        public Task<T> GetById(int id);
        public Task<List<T>> GetAll();
    }
}
