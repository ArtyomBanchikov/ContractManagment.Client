using ContractManagment.Client.Commands;
using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.ViewModel.Panel;
using ContractManagment.Client.Services;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private int _windowHeight;
        
        private int _windowWidth;

        public int WindowHeight
        {
            get { return _windowHeight; } set
            {
                _windowHeight = value;
                OnPropertyChanged(nameof(WindowHeight));
            }
        }
        public int WindowWidth
        {
            get { return _windowWidth; }
            set
            {
                _windowWidth = value;
                OnPropertyChanged(nameof(WindowWidth));
            }
        }

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
        private ICommand _logoutCommand;
        public ICommand LogoutCommand
        {
            get { return _logoutCommand; }
            set
            {
                _logoutCommand = value;
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
        public MainViewModel(IAuthenticator authenticator, INavigator navigator, IXmlService xmlService)
        {
            if ((int)System.Windows.SystemParameters.PrimaryScreenHeight < xmlService.Height)
                WindowHeight = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
            else
                WindowHeight = xmlService.Height;

            WindowWidth = xmlService.Width;
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
                else if (Authenticator.CurrentUser.Role == "manager")
                {
                    Panel = new ManagerPanelViewModel();
                }
            }
            LogoutCommand = new LogoutCommand(authenticator, ServiceProviderFactory.ServiceProvider.GetRequiredService<IXmlService>());
        }
    }
}
