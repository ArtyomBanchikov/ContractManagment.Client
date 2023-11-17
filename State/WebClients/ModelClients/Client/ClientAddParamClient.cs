using ContractManagment.Client.MVVM.Model.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Client
{
    public class ClientAddParamClient : IReadClient<ClientAddParamModel>
    {
        public Task<List<ClientAddParamModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ClientAddParamModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
