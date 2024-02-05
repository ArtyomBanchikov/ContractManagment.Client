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
using ContractManagment.Client.MVVM.Model.Post;
using ContractManagment.Client.State.WebClients.ModelClients.Post;
using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.Services.DialogServices;
using ContractManagment.Client.MVVM.ViewModel.Contract;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.State.WebClients.ModelClients.Record;
using ContractManagment.Client.MVVM.Model.ClientInternet;
using ContractManagment.Client.State.WebClients.ModelClients.ClientInternet;
using ContractManagment.Client.MVVM.Model.ClientDigital;
using ContractManagment.Client.State.WebClients.ModelClients.ClientDigital;
using ContractManagment.Client.MVVM.ViewModel.User;
using ContractManagment.Client.MVVM.ViewModel.Clients;
using ContractManagment.Client.MVVM.Model.ClientIPTV;
using ContractManagment.Client.State.WebClients.ModelClients.ClientIPTV;

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

            services.AddSingleton<IReadClient<AccountTariffInternetModel>, AccountTariffInternetClient>();
            services.AddSingleton<IReadClient<TariffInternetModel>, TariffInternetClient>();
            services.AddSingleton<IReadClient<InternetAddParamModel>, InternetAddParamClient>();
            services.AddSingleton<IReadClient<ClientInternetAddParamModel>, ClientInternetAddParamClient>();
            services.AddSingleton<IReadClient<ClientInternetModel>, ClientInternetClient>();

            services.AddSingleton<IReadClient<AccountTariffDigitalModel>, AccountTariffDigitalClient>();
            services.AddSingleton<IReadClient<TariffDigitalModel>, TariffDigitalClient>();
            services.AddSingleton<IReadClient<DigitalAddParamModel>, DigitalAddParamClient>();
            services.AddSingleton<IReadClient<ClientDigitalAddParamModel>, ClientDigitalAddParamClient>();
            services.AddSingleton<IReadClient<ClientDigitalModel>, ClientDigitalClient>();

            services.AddSingleton<IReadClient<AccountTariffIPTVModel>, AccountTariffIPTVClient>();
            services.AddSingleton<IReadClient<TariffIPTVModel>, TariffIPTVClient>();
            services.AddSingleton<IReadClient<IPTVAddParamModel>, IPTVAddParamClient>();
            services.AddSingleton<IReadClient<ClientIPTVAddParamModel>, ClientIPTVAddParamClient>();
            services.AddSingleton<IReadClient<ClientIPTVModel>, ClientIPTVClient>();

            services.AddSingleton<IPostClient, PostClient>();
            services.AddSingleton<IReadClient<PostMetaModel>, PostMetaClient>();

            services.AddSingleton<IReadWriteClient<ContractModel>, ContractClient>();
            services.AddSingleton<IReadWriteClient<ContractKeyModel>, ContractKeyClient>();
            services.AddSingleton<IReadWriteClient<KeyModel>, KeyClient>();

            services.AddSingleton<IReadWriteClient<UserModel>, UserClient>();

            services.AddSingleton<IRecordClient, RecordClient>();
            services.AddSingleton<IReadWriteClient<RecordKeyModel>, RecordKeyClient>();

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();

            services.AddSingleton<HistoryViewModel>();
            services.AddSingleton<PostsViewModel>();

            services.AddSingleton<ClientInternetViewModel>();
            services.AddSingleton<ClientDigitalViewModel>();
            services.AddSingleton<ClientIPTVViewModel>();

            services.AddSingleton<ContractViewModel>();
            services.AddTransient<NewContractViewModel>();
            services.AddSingleton<RecordViewModel>();
            services.AddSingleton<KeyViewModel>();
            services.AddSingleton<NewKeyViewModel>();
            services.AddSingleton<UserViewModel>();
            services.AddTransient<NewUserViewModel>();
            services.AddTransient<EditUserViewModel>();


            services.AddScoped<IStartService, StartService>();

            services.AddSingleton<IDialogService, DialogService>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
