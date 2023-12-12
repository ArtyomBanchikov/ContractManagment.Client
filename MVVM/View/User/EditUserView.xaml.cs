using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.MVVM.ViewModel.User;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContractManagment.Client.MVVM.View.User
{
    /// <summary>
    /// Логика взаимодействия для EditUserView.xaml
    /// </summary>
    public partial class EditUserView : UserControl
    {
        private IPasswordHasher _passwordHasher;
        public EditUserView()
        {
            _passwordHasher = new PasswordHasher();
            InitializeComponent();
        }

        private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ConfirmPasswordBox.Password) && !string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Подтвердите пароль");
            }
            else if (PasswordBox.Password != ConfirmPasswordBox.Password)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else
            {
                string password = "";
                if (!string.IsNullOrEmpty(PasswordBox.Password))
                    password = _passwordHasher.HashPassword(PasswordBox.Password);
                ((EditUserViewModel)DataContext).UpdateUserCommand.Execute(password);
            }
        }
        private void FioTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PasswordBox.Focus();
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmPasswordBox.Focus();
            }
        }
    }
}
