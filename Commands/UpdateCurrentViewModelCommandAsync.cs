using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.Client;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.MVVM.ViewModel.Contract;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ContractManagment.Client.Commands
{
    public class UpdateCurrentViewModelCommandAsync : AsyncBaseCommand
    {
        private INavigator _navigator;
        public UpdateCurrentViewModelCommandAsync(INavigator navigator)
        {
            _navigator = navigator;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Contracts:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<ContractViewModel>();
                        if (((ContractViewModel)_navigator.CurrentViewModel).Contracts == null)
                        {
                            IReadWriteClient<ContractModel> contractClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<ContractModel>>();
                            ((ContractViewModel)_navigator.CurrentViewModel).Contracts = new ObservableCollection<ContractModel>();
                            ((ContractViewModel)_navigator.CurrentViewModel).ContractsNames = new ObservableCollection<string>();
                            List<ContractModel> contracts = await contractClient.GetAll();
                            contracts.ForEach(contract => ((ContractViewModel)_navigator.CurrentViewModel).Contracts.Add(contract));
                            contracts.ForEach(contract => ((ContractViewModel)_navigator.CurrentViewModel).ContractsNames.Add(contract.Name));
                        }
                        break;

                    case ViewType.NewContract:
                        {
                            _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<NewContractViewModel>();
                            IReadWriteClient<KeyModel> keyClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<KeyModel>>();
                            ((NewContractViewModel)_navigator.CurrentViewModel).Keys = new ObservableCollection<KeyModel>();
                            List<KeyModel> keys = await keyClient.GetAll();
                            keys.ForEach(key => ((NewContractViewModel)_navigator.CurrentViewModel).Keys.Add(key));
                            break;
                        }
                    case ViewType.Users:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<UserViewModel>();
                        break;

                    case ViewType.Keys:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<KeyViewModel>();
                        if(((KeyViewModel)_navigator.CurrentViewModel).Keys == null)
                        {
                            IReadWriteClient<KeyModel> keyClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<KeyModel>>();
                            ((KeyViewModel)_navigator.CurrentViewModel).Keys = new ObservableCollection<KeyModel>();
                            List<KeyModel> keys = await keyClient.GetAll();
                            keys.ForEach(key => ((KeyViewModel)_navigator.CurrentViewModel).Keys.Add(key));
                        }
                        break;

                    case ViewType.NewKey:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<NewKeyViewModel>();
                        break;

                    case ViewType.Clients:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<ClientViewModel>();
                        break;

                    case ViewType.Requests:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<RequestViewModel>();
                        break;

                    case ViewType.History:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<HistoryViewModel>();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
