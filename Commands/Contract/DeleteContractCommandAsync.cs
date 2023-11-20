using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.ViewModel.Contract;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContractManagment.Client.Commands.Contract
{
    public class DeleteContractCommandAsync : AsyncBaseCommand
    {
        private ContractViewModel _contractVM;

        public DeleteContractCommandAsync(ContractViewModel contractVM)
        {
            _contractVM = contractVM;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            if(_contractVM.SelectedContract == null)
            {
                MessageBox.Show("Выберите документ для удаления");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить документ?", "", MessageBoxButton.YesNo);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        ContractModel contractToDelete = new ContractModel { Id = _contractVM.SelectedContract.Id, Name = _contractVM.SelectedContract.Name, Value = _contractVM.SelectedContract.Value };
                        IReadWriteClient<ContractModel> contractClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<ContractModel>>();
                        await contractClient.DeleteById(contractToDelete.Id);
                        _contractVM.Contracts.Remove(contractToDelete);
                        _contractVM.ContractsNames.Remove(contractToDelete.Name);
                        _contractVM.RecordKeys.Clear();
                        break;
                    case MessageBoxResult.No:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
