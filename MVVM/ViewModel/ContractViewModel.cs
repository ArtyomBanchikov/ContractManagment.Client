using ContractManagment.Client.Commands.Contract;
using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.Records;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class ContractViewModel : ViewModelBase
    {
        public ObservableCollection<ContractModel> Contracts { get; set; }
        public ObservableCollection<RecordKeyModel> RecordKeys { get; set; }
        public ICommand AddContractCommand { get; set; }
        public ICommand DeleteContractCommand { get; set; }
        public ICommand GenerateContractCommand { get; set; }
        public ICommand RefreshContractCommand { get; set; }


        private ContractModel _selectedContract;
        public ContractModel SelectedContract
        {
            get { return _selectedContract; }
            set
            {
                _selectedContract = value;
                OnPropertyChanged(nameof(SelectedContract));
            }
        }

        public ContractViewModel()
        {
            AddContractCommand = new AddContractCommandAsync();
            DeleteContractCommand = new DeleteContractCommandAsync();
            GenerateContractCommand = new GenerateContractCommandAsync();
            RefreshContractCommand = new RefreshContractCommandAsync();
        }
    }
}
