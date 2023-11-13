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
                        XDocument document = XDocument.Load("UserInfo.xml");
                        XElement? userInfo = document.Element("userinfo");
                        XElement? isRemember = userInfo.Element("IsRemember");
                        XElement? token = userInfo.Element("Token");

                        if ((bool)RememberCheck.IsChecked)
                        {
                            isRemember.Value = "true";
                            byte[] plaintextBytes = _authenticator.CurrentUser.Token.ToByteArray();
                            byte[] encodedBytes = ProtectedData.Protect(plaintextBytes, null, DataProtectionScope.CurrentUser);
                            token.Value = encodedBytes.InString();
                            document.Save("UserInfo.xml");
                        }
                        else if(isRemember.Value == "true")
                        {
                            isRemember.Value = "";
                            token.Value = "";
                            document.Save("UserInfo.xml");
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
