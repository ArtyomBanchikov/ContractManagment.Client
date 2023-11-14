using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public ICommand LoginCommand { get; set; }
        private IAuthenticator _authenticator;
        private IPasswordHasher passwordHasher;
        private IXmlService _xmlProvider;
        public IServiceProvider ServiceProvider { get; set; }
        public LoginView(LoginViewModel viewModel, IAuthenticator authenticator, IXmlService xmlProvider)
        {
            DataContext = viewModel;
            LoginCommand = viewModel.LoginCommand;
            _authenticator = authenticator;
            passwordHasher = new PasswordHasher();
            _xmlProvider = xmlProvider;
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginBox.Text))
            {
                MessageBox.Show("Введите имя пользователя");
                LoginBox.Focus();
            }
            else if(string.IsNullOrEmpty(password_box.Password))
            {
                MessageBox.Show("Введите пароль");
                password_box.Focus();
            }
            else 
            {
                if (LoginCommand != null)
                {
                    LoginCommand.Execute(passwordHasher.HashPassword(password_box.Password));
                    if (_authenticator != null && _authenticator.IsLoggedIn)
                    {
                        if ((bool)RememberCheck.IsChecked)
                        {
                            _xmlProvider.IsRemember = true;
                            _xmlProvider.Token = _authenticator.CurrentUser.Token;
                        }
                        else if(_xmlProvider.IsRemember)
                        {
                            _xmlProvider.IsRemember=false;
                            _xmlProvider.Token = "";
                        }
                        MainWindow window = ServiceProvider.GetRequiredService<MainWindow>();
                        window.Show();
                        Close();
                    }
                    else
                        MessageBox.Show("Неправильный пароль или имя пользователя");
                }
            }
        }
    }
}
