using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.MVVM.ViewModel.Contract;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients;
using ContractManagment.Client.State.WebClients.ModelClients;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows;

namespace ContractManagment.Client.Commands.User
{
    class AddUserCommandAsync : AsyncBaseCommand
    {
        private NewUserViewModel _newUserVM;

        public AddUserCommandAsync(NewUserViewModel newUserVM)
        {
            _newUserVM = newUserVM;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            if(string.IsNullOrEmpty(_newUserVM.Role))
            {
                MessageBox.Show("Выберите роль");
            }
            else
            {
                IReadWriteClient<UserModel> userClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<UserModel>>();
                UserModel newUser = new UserModel { Name = _newUserVM.Name, Role = _newUserVM.Role, Password = parameter.ToString() };
                await userClient.Create(newUser);
                INavigator navigator = ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>();
                navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<UserViewModel>();
                ((UserViewModel)navigator.CurrentViewModel).Users.Add(newUser);
            }
        }
    }
}
