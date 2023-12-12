using ContractManagment.Client.Commands;
using ContractManagment.Client.Commands.User;
using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        private UserModel _selectedUser;
        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public ICommand RefreshUserCommand { get; set; }
        public ICommand UpdateCurrentViewModel {  get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
        public ObservableCollection<UserModel> Users { get; set; }
        public UserViewModel()
        {
            UpdateCurrentViewModel = new UpdateCurrentViewModelCommandAsync(ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>());
            RefreshUserCommand = new RefreshUserCommandAsync(this);
            DeleteUserCommand = new DeleteUserCommandAsync(this);
            EditUserCommand = new EditUserCommand(this);
        }
    }
}
