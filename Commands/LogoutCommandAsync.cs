using ContractManagment.Client.MVVM.View;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ContractManagment.Client.Commands
{
    public class LogoutCommandAsync : AsyncBaseCommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly IXmlService _xmlService;
        private readonly IServiceProvider _serviceProvider;

        public LogoutCommandAsync(IAuthenticator authenticator, IXmlService xmlService, IServiceProvider serviceProvider)
        {
            _authenticator = authenticator;
            _xmlService = xmlService;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            bool success = await _authenticator.Logout();
            _xmlService.IsRemember = false;
            _xmlService.Token = "";
            MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            LoginView loginView = _serviceProvider.GetRequiredService<LoginView>();
            loginView.Show();
            mainWindow.Close();
        }
    }
}
