using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.WebClients.ModelClients.Record;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractManagment.Client.Commands
{
    public class HistorySearchCommandAsync : AsyncBaseCommand
    {
        private RecordsViewModelBase _recordsVM;
        public HistorySearchCommandAsync(RecordsViewModelBase recordsVM)
        {
            _recordsVM = recordsVM;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            IRecordClient recordClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IRecordClient>();
            List<LongRecordModel> records;
            _recordsVM.FullRecords.Clear();
            if (!string.IsNullOrEmpty(_recordsVM.SelectedKeyName) && !string.IsNullOrEmpty(_recordsVM.SearchString))
            {
                records = await recordClient.GetByFilter(_recordsVM.SelectedKeyName, _recordsVM.SearchString);
            }
            else
            {
                records = await recordClient.GetAll();
            }

            foreach (LongRecordModel record in records)
            {
                _recordsVM.FullRecords.Add(record);
            }
        }
    }
}
