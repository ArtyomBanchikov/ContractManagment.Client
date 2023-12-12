using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.MVVM.ViewModel.User;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;

namespace ContractManagment.Client.Commands.User
{
    public class EditUserCommand : ICommand
    {
        private UserViewModel _userVM;
        private INavigator _navigator;

        public EditUserCommand(UserViewModel userVM)
        {
            _userVM = userVM;
            _navigator = ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>();
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(_userVM.SelectedUser  == null)
            {
                MessageBox.Show("Выберите пользователя");
            }
            else
            {
                EditUserViewModel editUserVM = ServiceProviderFactory.ServiceProvider.GetRequiredService<EditUserViewModel>();
                _navigator.CurrentViewModel = editUserVM;

                editUserVM.User = _userVM.SelectedUser;

                editUserVM.Name = _userVM.SelectedUser.Name;

                if (!string.IsNullOrEmpty(_userVM.SelectedUser.FIO))
                    editUserVM.FIO = _userVM.SelectedUser.FIO;

                editUserVM.Role = _userVM.SelectedUser.Role;

                editUserVM.Id = _userVM.SelectedUser.Id;
            }
        }
    }
}
