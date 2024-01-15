using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ContractManagment.Client.MVVM.View.Factories
{
    public static class MainWindowFactory
    {
        public static MainWindow Window { get; private set; }
        static MainWindowFactory()
        {
            IAuthenticator authenticator = ServiceProviderFactory.ServiceProvider.GetRequiredService<IAuthenticator>();
            INavigator navigator = ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>();
            IXmlService xmlService = ServiceProviderFactory.ServiceProvider.GetRequiredService<IXmlService>();
            MainViewModel mainVM = new MainViewModel(authenticator, navigator, xmlService);
            Window = new MainWindow(mainVM);
        }
        public static MainWindow NewWindow()
        {
            IAuthenticator authenticator = ServiceProviderFactory.ServiceProvider.GetRequiredService<IAuthenticator>();
            INavigator navigator = ServiceProviderFactory.ServiceProvider.GetRequiredService<INavigator>();
            IXmlService xmlService = ServiceProviderFactory.ServiceProvider.GetRequiredService<IXmlService>();
            MainViewModel mainVM = new MainViewModel(authenticator, navigator, xmlService);
            Window = new MainWindow(mainVM);
            return Window;
        }
    }
}
