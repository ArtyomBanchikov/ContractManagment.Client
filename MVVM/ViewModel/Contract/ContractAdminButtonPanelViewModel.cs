using ContractManagment.Client.Commands;
using ContractManagment.Client.Commands.Contract;
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

namespace ContractManagment.Client.MVVM.ViewModel.Contract
{
    public class ContractAdminButtonPanelViewModel : ViewModelBase
    {
        private ContractViewModel _contractVM;
        public ICommand UpdateCurrentViewModel { get; set; }
        public ICommand GenerateContractCommand { get; set; }
        public ICommand DeleteContractCommand { get; set; }
        public ICommand RefreshContractCommand { get; set; }
        public ContractAdminButtonPanelViewModel(ContractViewModel contractVM)
        {
            _contractVM = contractVM;
            UpdateCurrentViewModel = new UpdateCurrentViewModelCommandAsync(ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>());
            GenerateContractCommand = new GenerateContractCommandAsync(contractVM);
            DeleteContractCommand = new DeleteContractCommandAsync(contractVM);
            RefreshContractCommand = new RefreshContractCommandAsync(contractVM);
        }
    }
}
