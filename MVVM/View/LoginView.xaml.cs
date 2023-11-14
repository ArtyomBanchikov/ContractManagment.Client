using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.State;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.XmlProviders;
using Microsoft.AspNet.Identity;
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
        private MainWindow _mainWindow;
        private IPasswordHasher passwordHasher;
        private IXmlProvider _xmlProvider;
        public LoginView(LoginViewModel viewModel, IAuthenticator authenticator, MainWindow mainWindow, IXmlProvider xmlProvider)
        {
            DataContext = viewModel;
            LoginCommand = viewModel.LoginCommand;
            _authenticator = authenticator;
            _mainWindow = mainWindow;
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
                            _xmlProvider.IsRemember = "true";
                            byte[] plaintextBytes = _authenticator.CurrentUser.Token.ToByteArray();
                            byte[] encodedBytes = ProtectedData.Protect(plaintextBytes, null, DataProtectionScope.CurrentUser);
                            _xmlProvider.Token = encodedBytes.InString();
                        }
                        else if(_xmlProvider.IsRemember == "true")
                        {
                            _xmlProvider.IsRemember="false";
                            _xmlProvider.Token = "";
                        }
                        _mainWindow.Show();
                        Close();
                    }
                    else
                        MessageBox.Show("Неправильный пароль или имя пользователя");
                }
            }
        }
    }
}
