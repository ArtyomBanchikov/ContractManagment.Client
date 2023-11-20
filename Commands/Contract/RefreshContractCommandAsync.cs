using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.ViewModel.Contract;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractManagment.Client.Commands.Contract
{
    public class RefreshContractCommandAsync : AsyncBaseCommand
    {
        private ContractViewModel _contractVM;

        public RefreshContractCommandAsync(ContractViewModel contractVM)
        {
            _contractVM = contractVM;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            IReadWriteClient<ContractModel> contractClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<ContractModel>>();
            _contractVM.Contracts.Clear();
            _contractVM.ContractsNames.Clear();
            List<ContractModel> contracts = await contractClient.GetAll();
            contracts.ForEach(contract => _contractVM.Contracts.Add(contract));
            contracts.ForEach(contract => _contractVM.ContractsNames.Add(contract.Name));
            _contractVM.RecordKeys.Clear();
        }
    }
}
