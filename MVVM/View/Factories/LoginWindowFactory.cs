using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContractManagment.Client.MVVM.View.Factories
{
    public static class LoginWindowFactory
    {
        public static LoginView Window { get; private set; }
        static LoginWindowFactory()
        {
            IXmlService xmlService = ServiceProviderFactory.ServiceProvider.GetRequiredService<IXmlService>();
            IAuthenticator authenticator = ServiceProviderFactory.ServiceProvider.GetRequiredService<IAuthenticator>();
            LoginViewModel loginVM = new LoginViewModel(authenticator);
            Window = new LoginView(loginVM, authenticator, xmlService);
        }
        public static LoginView NewWindow()
        {
            IXmlService xmlService = ServiceProviderFactory.ServiceProvider.GetRequiredService<IXmlService>();
            IAuthenticator authenticator = ServiceProviderFactory.ServiceProvider.GetRequiredService<IAuthenticator>();
            LoginViewModel loginVM = new LoginViewModel(authenticator);
            Window = new LoginView(loginVM, authenticator, xmlService);
            return Window;
        }
    }
}
