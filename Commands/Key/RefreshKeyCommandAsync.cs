using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ContractManagment.Client.Commands.Key
{
    public class RefreshKeyCommandAsync : AsyncBaseCommand
    {
        private KeyViewModel _viewModel;
        public RefreshKeyCommandAsync(KeyViewModel keyViewModel)
        {
            _viewModel = keyViewModel;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            IReadWriteClient<KeyModel> keyClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<KeyModel>>();
            _viewModel.Keys.Clear();
            List<KeyModel> keys = await keyClient.GetAll();
            keys.ForEach(key => _viewModel.Keys.Add(key));
        }
    }
}
