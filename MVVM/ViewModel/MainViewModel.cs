using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public IAuthenticator Authenticator { get; set; }
        public INavigator Navigator { get; set; }
        private LoginUserModel _user;

        public LoginUserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(IAuthenticator authenticator, INavigator navigator)
        {
            Navigator = navigator;
            Authenticator = authenticator;
            User = Authenticator.CurrentUser;
        }
    }
}
