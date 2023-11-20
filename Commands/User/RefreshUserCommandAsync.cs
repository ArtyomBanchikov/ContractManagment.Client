using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.Commands.User
{
    class RefreshUserCommandAsync : AsyncBaseCommand
    {
        private UserViewModel _userVM;

        public RefreshUserCommandAsync(UserViewModel userVM)
        {
            _userVM = userVM;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            IReadWriteClient<UserModel> userClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<UserModel>>();
            _userVM.Users.Clear();
            List<UserModel> users = await userClient.GetAll();
            users.ForEach(user => _userVM.Users.Add(user));
        }
    }
}
