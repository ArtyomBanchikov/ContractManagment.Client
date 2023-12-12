using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.MVVM.ViewModel.User;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows;

namespace ContractManagment.Client.Commands.User
{
    public class UpdateUserCommandAsync : AsyncBaseCommand
    {
        private EditUserViewModel _editUserVM;

        public UpdateUserCommandAsync(EditUserViewModel editUserVM)
        {
            _editUserVM = editUserVM;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            if(string.IsNullOrEmpty(_editUserVM.Role))
            {
                MessageBox.Show("Выберите роль");
            }
            else
            {
                IReadWriteClient<UserModel> userClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<UserModel>>();
                UserModel updateUser = new UserModel { Id = _editUserVM.Id, Name = _editUserVM.Name, Role = _editUserVM.Role };
                
                if (parameter is string && !string.IsNullOrEmpty((string)parameter))
                    updateUser.Password = parameter.ToString();
                
                if (!string.IsNullOrEmpty(_editUserVM.FIO))
                    updateUser.FIO = _editUserVM.FIO;

                await userClient.Update(updateUser);

                INavigator navigator = ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>();
                navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<UserViewModel>();
            }
        }
    }
}
