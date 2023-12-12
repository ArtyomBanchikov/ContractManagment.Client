using ContractManagment.Client.Commands;
using ContractManagment.Client.Core;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel.Panel
{
    public class AdminPanelViewModel : ViewModelBase
    {
        public ICommand UpdateCurrentViewModel { get; set; }
        public AdminPanelViewModel()
        {
            UpdateCurrentViewModel = new UpdateCurrentViewModelCommandAsync(ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>());
        }
    }
}
