using System;
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

namespace Bank
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeExchangeList();

        }

        // Инициализация списка курсов валют
        private void InitializeExchangeList()
        {
            var gridView = new GridView();
            ExchangeList.View = gridView;

            gridView.Columns.Add(new GridViewColumn { Header = "Валюта", DisplayMemberBinding = new Binding("Code"), Width = 45 });
            gridView.Columns.Add(new GridViewColumn { Header = "Курс", DisplayMemberBinding = new Binding("Exchange") { StringFormat = "{0:0.000}" }, Width = 40 });

            FillExchangeValues(ExchangeList);
            // Создание потока
            //Thread thread = new Thread(new ParameterizedThreadStart(FillExchangeValues));
            //thread.Start(ExchangeList);
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

            List<ExRate> rates = JsonConvert.DeserializeObject<List<ExRate>>(data);
            tempView.ItemsSource = rates;
        }
    }
}
