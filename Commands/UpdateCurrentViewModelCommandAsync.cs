using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.Client;
using ContractManagment.Client.MVVM.ViewModel;
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
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<ContractsViewModel>();
                        break;
                    case ViewType.Users:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<UsersViewModel>();
                        break;
                    case ViewType.Keys:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<KeysViewModel>();
                        if(((KeysViewModel)_navigator.CurrentViewModel).Keys == null)
                        {
                            IReadWriteClient<KeyModel> keyClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<KeyModel>>();
                            ((KeysViewModel)_navigator.CurrentViewModel).Keys = new ObservableCollection<KeyModel>();
                            List<KeyModel> keys = await keyClient.GetAll();
                            keys.ForEach(key => ((KeysViewModel)_navigator.CurrentViewModel).Keys.Add(key));
                        }
                        break;
                    case ViewType.Clients:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<ClientsViewModel>();
                        break;
                    case ViewType.Requests:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<RequestsViewModel>();
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
