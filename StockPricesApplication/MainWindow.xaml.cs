using StockPricesRepository.CSV;
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

        private void CsvFetchButton_Click(object sender, RoutedEventArgs e)
        {
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            ClearListBox();
            IStockPricesRepository repository = new CSVRepository();
            var prices = repository.GetStockPrice();

            foreach (var price in prices)
            {
                StockListBox.Items.Add(price);
            }

            ShowTicketText();
        }

        private void ClearListBox()
        {
            StockListBox.Items.Clear();
        }

        public void ShowTicketText()
        {
            TickerTextBlock.Text = "Lulu Lemon (LULU)";
        }
    }
}
