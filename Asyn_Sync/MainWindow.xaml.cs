using System;
using System.Collections.Generic;
using System.IO;
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

namespace Asyn_Sync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            //DownloadHtmlAsync("https://www.google.com");

            //var html = GetHtml("https://www.google.com");
            var html = await GetHtmlAsync("https://www.google.com");
            MessageBox.Show(html.Substring(0, 50));
        }

        // The Task is an object that encapsulates the state of an asynchronous operation.
        private async Task DownloadHtmlAsync(string url)
        {
            #pragma warning disable SYSLIB0014 // Type or member is obsolete
            var webClient = new WebClient();
            #pragma warning restore SYSLIB0014 // Type or member is obsolete
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(@"d:\result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }

        private void DownloadHtml(string url)
        {
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var webClient = new WebClient();
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(@"d:\result.html"))
            {
                streamWriter.Write(html);
            }
        }

        private async Task<string> GetHtmlAsync(string url)
        {
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var webClient = new WebClient();
#pragma warning restore SYSLIB0014 // Type or member is obsolete

            return await webClient.DownloadStringTaskAsync(url);
        }

        private string GetHtml(string url)
        {
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var webClient = new WebClient();
#pragma warning restore SYSLIB0014 // Type or member is obsolete

            return webClient.DownloadString(url);
        }
    }
}
