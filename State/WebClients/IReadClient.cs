using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients
{
    public interface IReadClient<T> where T : class
    {
        public Task<T> GetById(int id);
        public Task<List<T>> GetAll();
    }
}
