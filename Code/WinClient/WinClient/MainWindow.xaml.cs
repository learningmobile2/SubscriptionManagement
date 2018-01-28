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
using Winclient.Models;
using WinClient.Controls;
using WPF.MDI;

namespace WinClient
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Container.Children.Add(new MdiChild
            //{
            //    Title = "Customer Master",
            //    Content = new Customer(),
            //    Width = 300,
            //    Height = 400,
            //    Position = new Point(300, 80)
            //});

            var pageContainer = new PageContainer();
            pageContainer.ControlPlaceholder.Children.Add(new Customer());
            pageContainer.ListLoader += LoadCustomer;
           

            Container.Children.Add(new MdiChild
            {
                Title = "Customer Master",
                Content = pageContainer,
                Width = 500,
                Height = 500,
                Position = new Point(300, 80)
            });

        }

        public async void LoadCustomer(object sender, EventArgs e)
        {
            var webClient = new WebApiClient(@"http://localhost:49411/");
            var result = await webClient.FindAllCustomers<CustomerModel>();
            var list = result.Select(c => new { Id = c.Id, Name = c.Alias, Description = c.FirstName }).ToList();
            ((ListView)sender).ItemsSource = list;
        }
    }
}
