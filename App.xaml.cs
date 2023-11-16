using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.View;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.Services.StartServices;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients;
using ContractManagment.Client.State.WebClients.ModelClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
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
            IStartService startService = ServiceProviderFactory.ServiceProvider.GetRequiredService<IStartService>();
            startService.Start();

            //Window window = ServiceProviderFactory.ServiceProvider.GetRequiredService<MainWindow>();
            //MainViewModel mainVM = (MainViewModel)window.DataContext;
            //mainVM.CurrentUser = new LoginUserModel { Name = "test", Role = "admin" };
            //mainVM.Panel = new AdminPanelViewModel();
            //window.Show();
            base.OnStartup(e);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Exception exception = e.Exception;
            while(exception.InnerException!=null && exception is AggregateException)
            {
                exception = exception.InnerException;
            }
            if(exception is HttpRequestException)
            {
                if(((HttpRequestException)exception).StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Ошибка авторизации");
                }
            }
            else if (exception is SocketException || exception is HttpRequestException)
            {
                MessageBox.Show("Не удалось подключиться к серверу");
            }
            else
            {
                MessageBox.Show(exception.Message);
            }
            e.Handled = true;
        }
    }
}
