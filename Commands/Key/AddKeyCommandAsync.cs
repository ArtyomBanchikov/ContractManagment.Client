using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows;

namespace ContractManagment.Client.Commands.Key
{
    public class AddKeyCommandAsync : AsyncBaseCommand
    {
        private INavigator _navigator;
        private KeyViewModel _keyViewModel;
        private NewKeyViewModel _newKeyViewModel;
        private IReadWriteClient<KeyModel> _client;

        public AddKeyCommandAsync(INavigator navigator, NewKeyViewModel newKeyViewModel, IReadWriteClient<KeyModel> client)
        {
            _navigator = navigator;
            _keyViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<KeyViewModel>();
            _newKeyViewModel = newKeyViewModel;
            _client = client;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            KeyModel newKey = new KeyModel { Key = _newKeyViewModel.Key.Trim(), Name = _newKeyViewModel.Name.Trim() };
            if (string.IsNullOrEmpty(newKey.Key))
            {
                MessageBox.Show("Введите ключ");
            }
            else if (string.IsNullOrEmpty(newKey.Name))
            {
                MessageBox.Show("Введите расшифровку ключа");
            }
            else if (newKey.Key.Contains(' '))
            {
                MessageBox.Show("Некорректный ввод ключа");
            }
            else
            {
                await _client.Create(newKey);
                _newKeyViewModel.Name = "";
                _newKeyViewModel.Key = "";
                _keyViewModel.Keys.Add(newKey);
                _navigator.CurrentViewModel = _keyViewModel;
            }

        }
    }
}
