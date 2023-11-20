using ContractManagment.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContractManagment.Client.State.Navigators
{
    public enum ViewType
    {
        Contracts,
        Users,
        Keys,
        Clients,
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
