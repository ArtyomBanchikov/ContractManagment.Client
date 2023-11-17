using ContractManagment.Client.Commands;
using ContractManagment.Client.Commands.Key;
using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class KeyViewModel : ViewModelBase
    {
        public ObservableCollection<KeyModel> Keys { get; set; }
        public ICommand UpdateCurrentViewModel { get; set; }
        public ICommand DeleteKeyCommand { get; set; }
        public ICommand RefreshKeyCommand { get; set; }
        public bool IsKeySelected => SelectedKey != null;

        private KeyModel _selectedKey;
        public KeyModel SelectedKey
        {
            get { return _selectedKey; }
            set
            {
                _selectedKey = value;
                OnPropertyChanged(nameof(SelectedKey));
                OnPropertyChanged(nameof(IsKeySelected));
            }
        }

        public KeyViewModel()
        {
            UpdateCurrentViewModel = new UpdateCurrentViewModelCommandAsync(ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>());
            RefreshKeyCommand = new RefreshKeyCommandAsync(this);
            DeleteKeyCommand = new DeleteKeyCommandAsync(this);
        }
    }
}
