using ContractManagment.Client.Commands.Contract;
using ContractManagment.Client.Core;
using ContractManagment.Client.State.Navigators;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContractManagment.Client.MVVM.Model.ClientDigital;
using ContractManagment.Client.Commands.Clients;

namespace ContractManagment.Client.MVVM.ViewModel.Clients
{
    public class ClientDigitalViewModel : ExportToContractViewModelBase
    {
        private ClientDigitalModel _findedClient;
        public ClientDigitalModel FindedClient
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
        public ObservableCollection<ClientDigitalModel> Clients { get; set; }
        public ICommand ClientDigitalSearchCommand { get; set; }
        public ICommand ExprotToContractCommand { get; set; }
        public ClientDigitalViewModel(INavigator navigator)
            :base()
        {
            ClientDigitalSearchCommand = new ClientDigitalSearchCommandAsync(this);
            ExprotToContractCommand = new ExportToContractCommandAsync(navigator, this);
        }
    }
}
