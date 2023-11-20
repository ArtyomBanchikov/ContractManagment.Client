using ContractManagment.Client.MVVM.Model.Records;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Record
{
    public class RecordKeyClient : IReadWriteClient<RecordKeyModel>
    {
        public Task Create(RecordKeyModel obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RecordKeyModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RecordKeyModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(RecordKeyModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
