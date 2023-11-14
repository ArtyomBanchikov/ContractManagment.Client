using ContractManagment.Client.MVVM.View;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace ContractManagment.Client.Services.StartServices
{
    public class StartService : IStartService
    {
        private IXmlService _xmlProvider;
        private IAuthenticator _authenticator;

        public StartService(IXmlService xmlProvider, IAuthenticator authenticator)
        {
            _xmlProvider = xmlProvider;
            _authenticator = authenticator;
        }

        public void Start(IServiceProvider provider)
        {
            Window window;
            if (_xmlProvider.IsRemember)
            {
                try
                {
                    _authenticator.TokenCheck(_xmlProvider.Token);
                    window = provider.GetRequiredService<MainWindow>();
                    window.Show();
                }
                catch (Exception ex)
                {
                    window = provider.GetRequiredService<LoginView>();
                    ((LoginView)window).ServiceProvider = provider;
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                window = provider.GetRequiredService<LoginView>();
                ((LoginView)window).ServiceProvider = provider;
            }
            window.Show();
        }
    }
}
