using ContractManagment.Client.Commands;
using ContractManagment.Client.Commands.Contract;
using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.Client;
using ContractManagment.Client.State.Navigators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class ClientViewModel : ExportToContractViewModelBase
    {
        private ClientModel _findedClient;
        public ClientModel FindedClient
        {
            get { return _findedClient; }
            set
            {
                _findedClient = value;
                OnPropertyChanged(nameof(FindedClient));
            }
        }

        private string _accountSearch;
        public string AccountSearch
        {
            get { return _accountSearch; }
            set
            {
                _accountSearch = value;
                OnPropertyChanged(nameof(AccountSearch));
            }
        }
        public ObservableCollection<ClientModel> Clients { get; set; }
        public ICommand ClientSearchCommand { get; set; }
        public ICommand ExprotToContractCommand { get; set; }
        public ClientViewModel(INavigator navigator)
            :base()
        {
            ClientSearchCommand = new ClientSearchCommandAsync(this);
            ExprotToContractCommand = new ExportToContractCommandAsync(navigator, this);
        }
    }
}
