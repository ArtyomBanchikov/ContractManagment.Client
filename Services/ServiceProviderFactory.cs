using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services.StartServices;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients.ModelClients;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using ContractManagment.Client.MVVM.Model.Client;
using ContractManagment.Client.State.WebClients.ModelClients.Client;
using ContractManagment.Client.MVVM.Model.Post;
using ContractManagment.Client.State.WebClients.ModelClients.Post;
using ContractManagment.Client.MVVM.Model;

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
            services.AddSingleton<IReadClient<AdditionalParameterModel>, AdditionalParameterClient>();
            services.AddSingleton<IReadClient<ClientAddParamModel>, ClientAddParamClient>();
            services.AddSingleton<IReadClient<ClientModel>, ClientClient>();
            services.AddSingleton<IReadClient<PostModel>, PostClient>();
            services.AddSingleton<IReadClient<PostMetaModel>, PostMetaClient>();
            services.AddSingleton<IReadWriteClient<ContractModel>, ContractClient>();
            services.AddSingleton<IReadWriteClient<ContractKeyModel>, ContractKeyClient>();
            services.AddSingleton<IReadWriteClient<KeyModel>, KeyClient>();
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
