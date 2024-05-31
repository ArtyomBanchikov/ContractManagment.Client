using ContractManagment.Client.MVVM.View.Factories;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
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

            viewModel.LoginSuccessful += (sender, e) =>
            {
                MainWindow window = MainWindowFactory.NewWindow();

                window.Show();
                Close();
                Application.Current.MainWindow = window;
            };
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
