using ContractManagment.Client.Core;
using System.Windows.Input;

namespace ContractManagment.Client.State.Navigators
{
    public enum ViewType
    {
        Contracts,
        Users,
        Keys,
        ClientsInternet,
        ClientsDigital,
        ClientsIPTV,
        Requests,
        History,
        NewKey,
        NewContract,
        NewUser
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
