using ContractManagment.Client.Commands;
using ContractManagment.Client.Core;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class UserPanelViewModel : ViewModelBase
    {
        public ICommand UpdateCurrentViewModel { get; set; }
        public UserPanelViewModel()
        {
            UpdateCurrentViewModel = new UpdateCurrentViewModelCommandAsync(ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>());
        }
    }
}
