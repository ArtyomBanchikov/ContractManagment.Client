using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

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
