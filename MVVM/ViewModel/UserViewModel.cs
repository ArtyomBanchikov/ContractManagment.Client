﻿using ContractManagment.Client.Commands;
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
        public ICommand UpdateCurrentViewModel {  get; set; }
        public ObservableCollection<UserModel> Users { get; set; }
        public UserViewModel()
        {
            UpdateCurrentViewModel = new UpdateCurrentViewModelCommandAsync(ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>());
            Users = new ObservableCollection<UserModel>();
        }
    }
}
