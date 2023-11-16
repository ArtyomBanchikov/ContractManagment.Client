using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.MVVM.View.Factories
{
    public static class MainWindowFactory
    {
        public static MainWindow Window { get; private set; }
        static MainWindowFactory()
        {
            IAuthenticator authenticator = ServiceProviderFactory.ServiceProvider.GetRequiredService<IAuthenticator>();
            INavigator navigator = ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>();
            MainViewModel mainVM = new MainViewModel(authenticator, navigator);
            Window = new MainWindow(mainVM);
        }
        public static MainWindow NewWindow()
        {
            IAuthenticator authenticator = ServiceProviderFactory.ServiceProvider.GetRequiredService<IAuthenticator>();
            INavigator navigator = ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>();
            MainViewModel mainVM = new MainViewModel(authenticator, navigator);
            Window = new MainWindow(mainVM);
            return Window;
        }
    }
}
