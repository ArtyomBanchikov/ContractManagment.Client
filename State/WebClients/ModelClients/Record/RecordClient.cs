using ContractManagment.Client.MVVM.Model.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Record
{
    public class RecordClient : IReadWriteClient<RecordModel>
    {
        public Task Create(RecordModel obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RecordModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<RecordModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(RecordModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
