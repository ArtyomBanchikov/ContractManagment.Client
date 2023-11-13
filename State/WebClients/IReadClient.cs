using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients
{
    public interface IReadClient<T> where T : class
    {
        public IWebClient Client { get; }
        public T GetById(int id);
        public List<T> GetAll();
    }
}
