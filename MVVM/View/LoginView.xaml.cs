using ContractManagment.Client.MVVM.View.Factories;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
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
        private IXmlService _xmlProvider;
        public LoginView(LoginViewModel viewModel, IAuthenticator authenticator, IXmlService xmlProvider)
        {
            DataContext = viewModel;
            LoginCommand = viewModel.LoginCommand;
            _authenticator = authenticator;
            _xmlProvider = xmlProvider;
            InitializeComponent();
            if(!string.IsNullOrEmpty(xmlProvider.LastLogin))
                LoginBox.Text = xmlProvider.LastLogin;
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
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
                    LoginCommand.Execute(password_box.Password);
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
                        _xmlProvider.LastLogin = LoginBox.Text;
                        MainWindow window = MainWindowFactory.NewWindow();

                        window.Show();
                        this.Close();
                        Application.Current.MainWindow = window;
                    }
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                password_box.Focus();
            }
        }
    }
}
