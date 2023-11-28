using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.Records;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.Core
{
    public class ExportToContractViewModelBase : ViewModelBase
    {
        public ObservableCollection<RecordKeyModel> RecordKeys { get; set; }
        public ExportToContractViewModelBase()
        {
            RecordKeys = new ObservableCollection<RecordKeyModel>();
        }
    }
}
