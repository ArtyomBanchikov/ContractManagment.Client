using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients
{
    public interface IReadWriteClient<T> where T : class
    {
        public IWebClient Client { get; }
        public T GetById(int id);
        public List<T> GetAll();
        public void DeleteById(int id);
        public void Create(T obj);
        public void Update(T obj);
    }
}
