using AutoUpdaterDotNET;
using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.View;
using ContractManagment.Client.MVVM.View.Factories;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace ContractManagment.Client.Services.StartServices
{
    public class StartService : IStartService
    {
        private IXmlService _xmlProvider;

        public StartService(IXmlService xmlProvider)
        {
            _xmlProvider = xmlProvider;
        }
        
        public void Start()
        {
            AutoUpdater.ShowSkipButton = false;
            ServerAddressCheck();
        }
        private void ServerAddressCheck()
        {
            if (string.IsNullOrEmpty(_xmlProvider.ServerAddress))
            {
                Window setAddressWindow = new ServerAddressView(_xmlProvider, this);
                setAddressWindow.Show();
            }
            else
            {
                WindowOpen();
            }
        }
        public async Task WindowOpen()
        {
            Window window;
            if (_xmlProvider.IsRemember)
            {
                try
                {
                    IAuthenticator authenticator = ServiceProviderFactory.ServiceProvider.GetRequiredService<IAuthenticator>();
                    LoginUserModel loginUser = await authenticator.TokenCheck(_xmlProvider.Token);
                    window = MainWindowFactory.Window;
                    window.Show();
                }
                catch (Exception ex)
                {
                    window = LoginWindowFactory.Window;
                    window.Show();
                    throw ex;
                }
            }
            else
            {
                window = LoginWindowFactory.Window;
                window.Show();
            }
            Application.Current.MainWindow = window;
        }
    }
}
