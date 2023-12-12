using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.WebClients.ModelClients.Post;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractManagment.Client.Commands
{
    public class PostSearchCommandAsync : AsyncBaseCommand
    {
        private RecordsViewModelBase _recordsVM;

        public PostSearchCommandAsync(RecordsViewModelBase recordsVM)
        {
            _recordsVM = recordsVM;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            IPostClient postClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IPostClient>();
            List<LongRecordModel> records;
            _recordsVM.FullRecords.Clear();
            if (!string.IsNullOrEmpty(_recordsVM.SelectedKeyName) && !string.IsNullOrEmpty(_recordsVM.SearchString))
            {
                records = await postClient.GetByFilter(_recordsVM.SelectedKeyName, _recordsVM.SearchString);
            }
            else
            {
                records = await postClient.GetAll();
            }

            foreach (LongRecordModel record in records)
            {
                _recordsVM.FullRecords.Add(record);
            }
        }
    }
}
