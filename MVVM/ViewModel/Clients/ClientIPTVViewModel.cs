using ContractManagment.Client.Commands.Contract;
using ContractManagment.Client.Core;
using ContractManagment.Client.State.Navigators;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContractManagment.Client.MVVM.Model.ClientIPTV;
using ContractManagment.Client.Commands.Clients;

namespace ContractManagment.Client.MVVM.ViewModel.Clients
{
    public class ClientIPTVViewModel : ExportToContractViewModelBase
    {
        private ClientIPTVModel _findedClient;
        public ClientIPTVModel FindedClient
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
        public ObservableCollection<ClientIPTVModel> Clients { get; set; }
        public ICommand ClientIPTVSearchCommand { get; set; }
        public ICommand ExprotToContractCommand { get; set; }
        public ClientIPTVViewModel(INavigator navigator)
            : base()
        {
            ClientIPTVSearchCommand = new ClientIPTVSearchCommandAsync(this);
            ExprotToContractCommand = new ExportToContractCommandAsync(navigator, this);
        }
    }
}
