using ContractManagment.Client.MVVM.View.Factories;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.Services.XmlServices;
using ContractManagment.Client.State.Authenticators;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public bool Exitable { get; set; } = true;
        public ICommand LoginCommand { get; set; }
        public LoginView(LoginViewModel viewModel)
        {
            DataContext = viewModel;
            LoginCommand = viewModel.LoginCommand;
            InitializeComponent();

            viewModel.LoginSuccessful += (sender, e) =>
            {
                MainWindow window = MainWindowFactory.NewWindow();

                window.Show();
                Application.Current.MainWindow = window;
                Exitable = false;
                Close();
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
        protected override void OnClosing(CancelEventArgs e)
        {
            if (Exitable)
            {
                e.Cancel = true;
                Application.Current.Shutdown();
            }
            else
            {
                base.OnClosing(e);
            }
        }
    }
}
