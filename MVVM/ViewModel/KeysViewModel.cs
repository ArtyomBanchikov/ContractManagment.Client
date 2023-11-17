using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class KeysViewModel : ViewModelBase  
    {
        public ObservableCollection<KeyModel> Keys { get; set; }
    }
}
