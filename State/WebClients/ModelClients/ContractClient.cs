using ContractManagment.Client.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients
{
    public class ContractClient : IReadWriteClient<ContractModel>
    {
        public Task Create(ContractModel obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContractModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContractModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ContractModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
