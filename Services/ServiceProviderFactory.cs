using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.View;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services.StartServices;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients.ModelClients;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.Services
{
    public static class ServiceProviderFactory
    {
        public static IServiceProvider ServiceProvider { get; }

        static ServiceProviderFactory()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IXmlService, XmlService>();
            services.AddSingleton<IWebClient, WebClient>();
            services.AddSingleton<IReadWriteClient<UserModel>, UserClient>();
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<ClientsViewModel>();
            services.AddSingleton<ContractsViewModel>();
            services.AddSingleton<HistoryViewModel>();
            services.AddSingleton<KeysViewModel>();
            services.AddSingleton<RequestsViewModel>();
            services.AddSingleton<UsersViewModel>();
            services.AddScoped<IStartService, StartService>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
