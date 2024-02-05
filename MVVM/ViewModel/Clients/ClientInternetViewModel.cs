using ContractManagment.Client.Commands.Clients;
using ContractManagment.Client.Commands.Contract;
using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model.ClientInternet;
using ContractManagment.Client.State.Navigators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel.Clients
{
    public class ClientInternetViewModel : ExportToContractViewModelBase
    {
        private ClientInternetModel _findedClient;
        public ClientInternetModel FindedClient
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
        public ObservableCollection<ClientInternetModel> Clients { get; set; }
        public ICommand ClientInternetSearchCommand { get; set; }
        public ICommand ExprotToContractCommand { get; set; }
        public ClientInternetViewModel(INavigator navigator)
            :base()
        {
            ClientInternetSearchCommand = new ClientInternetSearchCommandAsync(this);
            ExprotToContractCommand = new ExportToContractCommandAsync(navigator, this);
        }
    }
}
