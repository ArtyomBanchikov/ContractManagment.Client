using ContractManagment.Client.Commands.Contract;
using ContractManagment.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Office.Interop.Word;
using System.Collections.ObjectModel;
using ContractManagment.Client.MVVM.Model;

namespace ContractManagment.Client.MVVM.ViewModel.Contract
{
    public class NewContractViewModel : ViewModelBase
    {
        public byte[] NewDocData { get; set; }
        public ObservableCollection<KeyModel> Keys { get; set; }
        public ObservableCollection<KeyModel> FindedKeys { get; set; }
        public ObservableCollection<string> UnfindedKeys { get; set; }
        public ICommand ChooseContractFileCommand { get; set; }
        public ICommand AddNewContractCommand { get; set; }
        public Document NewDoc { get; set; }
        private string _newDocPath;
        public string NewDocPath
        {
            get { return _newDocPath; }
            set
            {
                _newDocPath = value;
                OnPropertyChanged(nameof(NewDocPath));
            }
        }

        private string _contractName;
        public string ContractName
        {
            get { return _contractName; }
            set
            {
                _contractName = value;
                OnPropertyChanged(nameof(ContractName));
            }
        }
        public NewContractViewModel()
        {
            AddNewContractCommand = new AddContractCommandAsync(this);
            ChooseContractFileCommand = new ChooseContractFileCommand(this);
            UnfindedKeys = new ObservableCollection<string>();
            FindedKeys = new ObservableCollection<KeyModel>();
        }
    }
}
