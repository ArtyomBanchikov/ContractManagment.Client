using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.MVVM.ViewModel.Contract;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ContractManagment.Client.Commands.Contract
{
    public class ExportToContractCommandAsync : AsyncBaseCommand
    {
        private INavigator _navigator;
        private ExportToContractViewModelBase _viewModel;

        public ExportToContractCommandAsync(INavigator navigator, ExportToContractViewModelBase viewModel)
        {
            _navigator = navigator;
            _viewModel = viewModel;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            ContractViewModel contractVM = ServiceProviderFactory.ServiceProvider.GetRequiredService<ContractViewModel>();
            _navigator.CurrentViewModel = contractVM;
            contractVM.AllKeys.Clear();
            contractVM.RecordKeys.Clear();
            if (contractVM.SelectedContractName != null)
            {
                contractVM.SelectedContractName = null;
                foreach (RecordKeyModel recordoredKey in contractVM.RecordKeys)
                {
                    if (!string.IsNullOrEmpty(recordoredKey.Value.Trim()))
                    {
                        RecordKeyModel oldRecord = contractVM.AllKeys.FirstOrDefault(old => old.Key == recordoredKey.Key);
                        if (oldRecord == null)
                            contractVM.AllKeys.Add(recordoredKey);
                        else
                            oldRecord.Value = recordoredKey.Value;
                    }
                }
                contractVM.RecordKeys.Clear();
            }

            if (contractVM.Contracts == null)
            {
                IReadWriteClient<ContractModel> contractClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<ContractModel>>();
                contractVM.Contracts = new ObservableCollection<ContractModel>();
                contractVM.ContractsNames = new ObservableCollection<string>();
                List<ContractModel> contracts = await contractClient.GetAll();
                contracts.ForEach(contract => contractVM.Contracts.Add(contract));
                contracts.ForEach(contract => contractVM.ContractsNames.Add(contract.Name));
            }

            foreach(RecordKeyModel record in _viewModel.RecordKeys)
            {
                if(!string.IsNullOrEmpty(record.Value))
                {
                    contractVM.RecordKeys.Add(record);
                }
            }
        }
    }
}
