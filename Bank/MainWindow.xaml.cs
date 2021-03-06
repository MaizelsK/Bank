﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using Newtonsoft.Json;
using Bank.Entities;

namespace Bank
{
    public partial class MainWindow : Window
    {
        private User CurrentUser { get; set; }

        public MainWindow(User signedUser)
        { 
            CurrentUser = signedUser;

            InitializeComponent();
            InitializeExchangeList();
            AccountList.ItemsSource = CurrentUser.Accounts;

            this.DataContext = CurrentUser;
        }

        // Инициализация списка курсов валют
        private void InitializeExchangeList()
        {
            // Создание потока
            Thread thread = new Thread(new ParameterizedThreadStart(FillExchangeValues));
            thread.Start(ExchangeList);
        }

        // Получения данных с egov.kz
        public void FillExchangeValues(object listView)
        {
            ListView tempView = listView as ListView;
            string data;

            using (var client = new WebClient())
            {
                var json = client.DownloadString("http://data.egov.kz/api/v2/valutalar_bagamdary4/v310?pretty");

                data = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(json));
            }

            Dispatcher.Invoke(() =>
            {
                List<ExRate> rates = JsonConvert.DeserializeObject<List<ExRate>>(data);
                tempView.ItemsSource = rates;
            });
        }

        // Обработка нажатия по счету в списке счетов
        private void AccountButtonClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Account acc = clickedButton.DataContext as Account;

            AccountInfo.DataContext = acc;
        }

        // Кнопка выйти
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();

            this.Close();
        }
    }
}
