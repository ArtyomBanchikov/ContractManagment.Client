using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.View;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.WebClients;
using ContractManagment.Client.State.WebClients.ModelClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace ContractManagment.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window;
            XDocument document = XDocument.Load("appsettings.xml");
            XElement? settings = document.Element("settings");
            XElement? isRemember = settings.Element("IsRemember");
            IServiceProvider serviceProvider = CreateServiceProvider();
            if (isRemember != null && isRemember.Value == "true")
            {
                window = serviceProvider.GetRequiredService<MainWindow>();
            }
            else
            {
                window = serviceProvider.GetRequiredService<LoginView>();
            }
            window.Show();
            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IWebClient, WebClient>();
            services.AddSingleton<IReadWriteClient<UserModel>, UserClient>();

            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<LoginView>(w => new LoginView(w.GetRequiredService<LoginViewModel>(), w.GetRequiredService<IAuthenticator>(), w.GetRequiredService<MainWindow>()));
            return services.BuildServiceProvider();
        }
    }
}
