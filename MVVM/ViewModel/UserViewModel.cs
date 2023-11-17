using ContractManagment.Client.Commands;
using ContractManagment.Client.Core;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        public ICommand UpdateCurrentViewModel {  get; set; }
        public UserViewModel()
        {
            UpdateCurrentViewModel = new UpdateCurrentViewModelCommandAsync(ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>());
        }
    }
}
