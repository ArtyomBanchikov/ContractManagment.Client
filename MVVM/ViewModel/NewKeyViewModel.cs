using ContractManagment.Client.Commands;
using ContractManagment.Client.Commands.Key;
using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class NewKeyViewModel : ViewModelBase
    {
        private string _key;
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ICommand AddKeyCommand { get; set; }
        public NewKeyViewModel()
        {
            INavigator navigator = ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>();
            IReadWriteClient<KeyModel> client = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<KeyModel>>();
            AddKeyCommand = new AddKeyCommandAsync(navigator, this, client);
        }

    }
}
