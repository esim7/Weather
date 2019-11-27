using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using MaterialDesignThemes;

namespace Weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rootobject RootObject { get; set; }
        string Url = @"https://api.openweathermap.org/data/2.5/forecast?q=Astana&units=metric&appid=d90a95289bca705ac3617d2c0fadb97c";
        public MainWindow()
        {
            InitializeComponent();
            RootObject = new Rootobject();
            using (WebClient client = new WebClient())
            {
                var json = client.DownloadString(Url);
                var result = JsonConvert.DeserializeObject<Rootobject>(json);
                RootObject = result;
                textBox_dateFirstDay.Text = result.list[0].dt_txt;
                textBox_tempFirstDay.Text = result.list[0].main.temp.ToString();
                textBox_dateSecondDay.Text = result.list[8].dt_txt;
                textBox_tempSecondDay.Text = result.list[8].main.temp.ToString();
                textBox_dateThirdDay.Text = result.list[16].dt_txt;
                textBox_tempThirdDay.Text = result.list[16].main.temp.ToString();


            }
        }
    }
}
