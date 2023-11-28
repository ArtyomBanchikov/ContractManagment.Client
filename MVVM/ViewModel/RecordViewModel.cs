using ContractManagment.Client.Commands.Contract;
using ContractManagment.Client.Core;
using ContractManagment.Client.State.Navigators;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class RecordViewModel : ExportToContractViewModelBase
    {
        public ICommand ExprotToContractCommand { get; set; }
        public RecordViewModel(INavigator navigator)
            : base()
        {
            ExprotToContractCommand = new ExportToContractCommandAsync(navigator, this);
        }
    }
}
