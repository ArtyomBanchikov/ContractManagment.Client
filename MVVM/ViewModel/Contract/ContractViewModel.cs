using ContractManagment.Client.Commands;
using ContractManagment.Client.Commands.Contract;
using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.MVVM.View.Contract;
using ContractManagment.Client.Services;
using ContractManagment.Client.Services.DialogServices;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel.Contract
{
    public class ContractViewModel : ViewModelBase
    {
        public ObservableCollection<RecordKeyModel> AllKeys { get; set; }
        public ObservableCollection<ContractModel> Contracts { get; set; }
        public ObservableCollection<string> ContractsNames { get; set; }
        public ObservableCollection<RecordKeyModel> RecordKeys { get; set; }
        public ObservableCollection<KeyModel> Keys { get; set; }
        public ICommand SelectContractCommand { get; set; }
        public bool ComboboxChangedTrigger { get; set; }
        private ViewModelBase _buttonPanel;
        public ViewModelBase ButtonPanel
        {
            get { return _buttonPanel; }
            set
            {
                _buttonPanel = value;
                OnPropertyChanged();
            }
        }

        private string _selectedContractName;
        public string SelectedContractName
        {
            get { return _selectedContractName; }
            set
            {
                _selectedContractName = value;
                if (value != null)
                    SelectedContract = Contracts[ContractsNames.IndexOf(value)];
                else
                    SelectedContract = null;
                OnPropertyChanged(nameof(SelectedContractName));
            }
        }

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

        public ContractViewModel(IAuthenticator authenticator, IReadWriteClient<ContractModel> contractClient)
        {
            SelectContractCommand = new SelectContractCommandAsync(this);
            RecordKeys = new ObservableCollection<RecordKeyModel>();
            AllKeys = new ObservableCollection<RecordKeyModel>();
            ComboboxChangedTrigger = true;
            if(authenticator.IsLoggedIn)
            {
                if(authenticator.CurrentUser.Role == "admin")
                {
                    ButtonPanel = new ContractAdminButtonPanelViewModel(this);

                }
                else if(authenticator.CurrentUser.Role == "user")
                {
                    ButtonPanel = new ContractUserButtonPanelViewModel(this);
                }
            }
        }
    }
}
