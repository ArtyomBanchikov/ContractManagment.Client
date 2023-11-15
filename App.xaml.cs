using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.View;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services.StartServices;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients;
using ContractManagment.Client.State.WebClients.ModelClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Windows;

namespace ContractManagment.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            IStartService startService = serviceProvider.GetRequiredService<IStartService>();
            startService.Start(serviceProvider);
            //MainViewModel mainVM = serviceProvider.GetRequiredService<MainViewModel>();
            //mainVM.Panel = new AdminPanelViewModel();
            //mainVM.CurrentUser = new LoginUserModel { Name = "test", Role = "admin" };
            //Window window = new MainWindow(mainVM);
            //window.Show();
            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IXmlService, XmlService>();
            services.AddSingleton<IWebClient, WebClient>();
            services.AddSingleton<IReadWriteClient<UserModel>, UserClient>();
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<LoginViewModel>();
            //services.AddSingleton<LoginView>(w => new LoginView(w.GetRequiredService<LoginViewModel>(), w.GetRequiredService<IAuthenticator>(), w.GetRequiredService<MainWindow>()));
            services.AddSingleton<LoginView>();
            services.AddScoped<IStartService, StartService>();
            return services.BuildServiceProvider();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if(e.Exception.InnerException != null)
            {
                if(e.Exception.InnerException is SocketException || e.Exception.InnerException is HttpRequestException)
                {
                    MessageBox.Show("Не удалось подключиться к серверу");
                }
            }
            else
            {
                MessageBox.Show(e.Exception.Message);
            }
            e.Handled = true;
        }
    }
}
