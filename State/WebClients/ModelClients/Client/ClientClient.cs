using ContractManagment.Client.MVVM.Model.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Client
{
    public class ClientClient : IReadClient<ClientModel>
    {
        public Task<List<ClientModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ClientModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
