using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.ViewModel.Contract;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
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
    public class AddContractCommandAsync : AsyncBaseCommand
    {
        private NewContractViewModel _viewModel;

        public AddContractCommandAsync(NewContractViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            if(string.IsNullOrEmpty(_viewModel.ContractName))
            {
                MessageBox.Show("Введите имя документа");
            }
            else if(_viewModel.NewDocData == null)
            {
                MessageBox.Show("Отсутствуют данные документа");    
            }
            else
            {
                IReadWriteClient<ContractModel> contractClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<ContractModel>>();
                ContractModel newContract = new ContractModel();
                newContract.Name = _viewModel.ContractName;
                newContract.Value = _viewModel.NewDocData;
                newContract.Keys = new List<KeyModel>();
                _viewModel.FindedKeys.ToList().ForEach(key => newContract.Keys.Add(key));
                await contractClient.Create(newContract);
                INavigator navigator = ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>();
                navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<ContractViewModel>();
                ((ContractViewModel)navigator.CurrentViewModel).Contracts.Add(newContract);
                ((ContractViewModel)navigator.CurrentViewModel).ContractsNames.Add(newContract.Name);
            }
        }
    }
}
