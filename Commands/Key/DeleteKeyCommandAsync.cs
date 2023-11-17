using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContractManagment.Client.Commands.Key
{
    public class DeleteKeyCommandAsync : AsyncBaseCommand
    {
        private KeyViewModel _viewModel;

        public DeleteKeyCommandAsync(KeyViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            if (_viewModel.IsKeySelected)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить ключ?", "", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        KeyModel deletedKey = _viewModel.SelectedKey;
                        IReadWriteClient<KeyModel> keyClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<KeyModel>>();
                        await keyClient.DeleteById(deletedKey.Id);
                        _viewModel.SelectedKey = null;
                        _viewModel.Keys.Remove(deletedKey);
                        break;
                    default:
                        break;
                }
            }
            else
                MessageBox.Show("Выберите ключ для удаления");
        }
    }
}
