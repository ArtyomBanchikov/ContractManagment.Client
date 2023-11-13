using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.State;
using ContractManagment.Client.State.Authenticators;
using Microsoft.AspNet.Identity;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

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
        public LoginView(object datacontext, IAuthenticator authenticator, MainWindow mainWindow)
        {
            DataContext = datacontext;
            LoginCommand = ((LoginViewModel)datacontext).LoginCommand;
            _authenticator = authenticator;
            _mainWindow = mainWindow;
            passwordHasher = new PasswordHasher();
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
                        XDocument userDoc = XDocument.Load("UserInfo.xml");
                        XDocument settingsDoc = XDocument.Load("appsettings.xml");
                        XElement? userInfo = userDoc.Element("userinfo");
                        XElement? settingsInfo = settingsDoc.Element("settings");
                        XElement? isRemember = settingsInfo.Element("IsRemember");
                        XElement? token = userInfo.Element("Token");

                        if ((bool)RememberCheck.IsChecked)
                        {
                            isRemember.Value = "true";
                            byte[] plaintextBytes = _authenticator.CurrentUser.Token.ToByteArray();
                            byte[] encodedBytes = ProtectedData.Protect(plaintextBytes, null, DataProtectionScope.CurrentUser);
                            token.Value = encodedBytes.InString();
                            userDoc.Save("UserInfo.xml");
                            settingsDoc.Save("appsettings.xml");
                        }
                        else if(isRemember.Value == "true")
                        {
                            isRemember.Value = "false";
                            token.Value = "";
                            userDoc.Save("UserInfo.xml");
                            settingsDoc.Save("appsettings.xml");
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
