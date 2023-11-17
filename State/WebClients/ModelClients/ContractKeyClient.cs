using ContractManagment.Client.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients
{
    public class ContractKeyClient : IReadWriteClient<ContractKeyModel>
    {
        public Task Create(ContractKeyModel obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContractKeyModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContractKeyModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ContractKeyModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
