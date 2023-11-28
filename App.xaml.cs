using ContractManagment.Client.Services;
using ContractManagment.Client.Services.StartServices;
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
            IStartService startService = ServiceProviderFactory.ServiceProvider.GetRequiredService<IStartService>();
            startService.Start();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            ContractManagment.Client.Properties.Settings.Default.Save();
            base.OnExit(e);
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
