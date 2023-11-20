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
using System.Windows;

namespace ContractManagment.Client.Commands.User
{
    class DeleteUserCommandAsync : AsyncBaseCommand
    {
        private UserViewModel _userVM;

        public DeleteUserCommandAsync(UserViewModel userVM)
        {
            _userVM = userVM;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            if (_userVM.SelectedUser != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить ключ?", "", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        UserModel deletedUser = _userVM.SelectedUser;
                        IReadWriteClient<UserModel> userClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<UserModel>>();
                        await userClient.DeleteById(deletedUser.Id);
                        _userVM.SelectedUser = null;
                        _userVM.Users.Remove(deletedUser);
                        break;
                    default:
                        break;
                }
            }
            else
                MessageBox.Show("Выберите пользователя для удаления");
        }
    }
}
