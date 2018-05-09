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
    public partial class Registration : Window
    {
        private RegisterViewModel model;

        public Registration()
        {
            InitializeComponent();

            model = new RegisterViewModel();
            this.DataContext = model;
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            if (model.IsValid)
            {
                User newUser = new User
                {
                    Id = Guid.NewGuid(),
                    FisrtName = model.FirstName,
                    MiddleName = model.MiddleName,
                    SurName = model.SurName,
                    BirthDate = model.BirthDate,
                    RegisterDate = DateTime.Now,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    Login = model.Login,
                    Password = model.Password
                };

                using (var context = new BankContext())
                {
                    context.Users.Add(newUser);
                    context.SaveChanges();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля правильно!");
            }
        }
    }
}
