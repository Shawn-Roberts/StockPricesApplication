using StockPricesRepository.CSV;
using StockPricesRepository.Factory;
using StockPricesRepository.Interface;
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

namespace StockPricesApplication
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


        /* ON CLICKS */
        private void CsvFetchButton_Click(object sender, RoutedEventArgs e)
        {
            PopulateListBox("CSV");
        }

        private void ServiceFetchButton_Click(object sender, RoutedEventArgs e)
        {
            PopulateListBox("API");
        }


        /* Processing */
        private void PopulateListBox(string repositoryType)
        {
            ClearListBox();
            IStockPricesRepository repository = RepositoryFactory.GetRepository(repositoryType);
            
            var prices = repository.GetStockPrice();

            foreach (var price in prices)
            {
                StockListBox.Items.Add(price);
            }

            ShowTicketText();
        }

        /* Additional Tasks */
        private void ClearListBox()
        {
            StockListBox.Items.Clear();
        }

        public void ShowTicketText()
        {
            TickerTextBlock.Text = "Lulu Lemon (LULU)";
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }
    }
}
