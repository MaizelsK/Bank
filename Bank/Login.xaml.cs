using Bank.Entities;
using Bank.ViewModels;
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
using System.Windows.Shapes;

namespace Bank
{
    public partial class Login : Window
    {
        private LoginViewModel model;

        public Login()
        {
            InitializeComponent();

            model = new LoginViewModel();
            this.DataContext = model;
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            Window registration = new Registration();
            registration.ShowDialog();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            User loginUser;

            using (var context = new BankContext())
            {
                loginUser = context.Users.Include("Accounts") // Eager loading
                    .SingleOrDefault(u => u.Login == model.Login && u.Password == PasswordText.Password);
            }

            if (loginUser != null)
            {
                MainWindow mainWindow = new MainWindow(loginUser);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль");
            }
        }
    }
}
