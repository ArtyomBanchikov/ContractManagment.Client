using ContractManagment.Client.Services.StartServices;
using ContractManagment.Client.Services.XmlServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.View
{
    public partial class ServerAddressView : Window
    {
        private IXmlService _xmlProvider;
        private IStartService _startService;
        private string protocol = string.Empty;
        public ServerAddressView(IXmlService xmlProvider, IStartService startService)
        {
            _startService = startService;
            _xmlProvider = xmlProvider;
            InitializeComponent();
        }

        private void ApplyServerAddressButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(AddressTextBox.Text))
            {
                MessageBox.Show("Введите адресс сервера");
            }
            else if(string.IsNullOrEmpty(protocol))
            {
                MessageBox.Show("Выберите протокол HTTP или HTTPS");
            }
            else
            {
                _xmlProvider.ServerAddress = $"{protocol}://{AddressTextBox.Text}";
                _startService.WindowOpen();
                Close();
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            protocol = pressed.Content.ToString();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
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
    }
}
