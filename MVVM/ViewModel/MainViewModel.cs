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
        private object _panel;
        public object Panel
        {
            get { return _panel; }
            set
            {
                _panel = value;
                OnPropertyChanged();
            }
        }
        public IAuthenticator Authenticator { get; set; }
        public INavigator Navigator { get; set; }
        private LoginUserModel _currentUser;

        public LoginUserModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(IAuthenticator authenticator, INavigator navigator)
        {
            Navigator = navigator;
            Authenticator = authenticator;
            if (Authenticator.IsLoggedIn)
            {
                if (Authenticator.CurrentUser.Role == "user")
                {
                    Panel = new UserPanelViewModel();
                }
                else if (Authenticator.CurrentUser.Role == "admin")
                {
                    Panel = new AdminPanelViewModel();
                }
            }

        }
    }
}
