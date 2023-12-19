using AutoUpdaterDotNET;
using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.View.Factories;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
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
        
        public void Start()
        {
            AutoUpdater.Start("http:///ContractManagment.Client.xml");
            Window window;
            if (_xmlProvider.IsRemember)
            {
                try
                {
                    LoginUserModel loginUser = _authenticator.TokenCheck(_xmlProvider.Token).Result;
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
