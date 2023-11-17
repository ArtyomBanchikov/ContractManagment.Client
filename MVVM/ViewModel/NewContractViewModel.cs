using ContractManagment.Client.Commands.Contract;
using ContractManagment.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class NewContractViewModel : ViewModelBase
    {
        public ICommand AddNewContractCommand { get; set; }
        public NewContractViewModel()
        {
            AddNewContractCommand = new AddContractCommandAsync();
        }
    }
}
