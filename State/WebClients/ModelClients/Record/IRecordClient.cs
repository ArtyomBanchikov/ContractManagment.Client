using ContractManagment.Client.MVVM.Model.Records;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients.Record
{
    public interface IRecordClient
    {
        Task<List<LongRecordModel>> GetByFilter(string key, string keyValue);
        public Task<RecordModel> GetById(int id);
        public Task<List<LongRecordModel>> GetAll();
        public Task DeleteById(int id);
        public Task Create(RecordModel obj);
        public Task Update(RecordModel obj);
    }
}
