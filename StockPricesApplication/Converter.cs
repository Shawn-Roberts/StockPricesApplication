using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace StockPricesApplication
{

    public class MultiStockColourConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var openingPrice = (double)values[0];
            var closingPrice  = (double)values[1];

            if(openingPrice < closingPrice)
            {
                return new SolidColorBrush(Colors.LightGreen);
            }
            else if (closingPrice < openingPrice)
            {
                return new SolidColorBrush(Colors.LightSalmon);
            }
            else
            {
                return new SolidColorBrush(Colors.Beige);
            }

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
