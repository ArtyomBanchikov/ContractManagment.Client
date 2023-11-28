using ContractManagment.Client.MVVM.ViewModel;
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

namespace ContractManagment.Client.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для NewUserView.xaml
    /// </summary>
    public partial class NewUserView : UserControl
    {
        private IPasswordHasher _passwordHasher;
        public NewUserView()
        {
            _passwordHasher = new PasswordHasher();
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Введите имя пользователя");
            }
            else if(string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите пароль");
            }
            else if(string.IsNullOrEmpty(ConfirmPasswordBox.Password))
            {
                MessageBox.Show("Подтвердите пароль");
            }
            else if(PasswordBox.Password != ConfirmPasswordBox.Password)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else
            {
                ((NewUserViewModel)DataContext).AddUserCommand.Execute(_passwordHasher.HashPassword(PasswordBox.Password));
            }
        }

        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                FioTextBox.Focus();
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
