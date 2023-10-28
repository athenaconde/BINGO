using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace BingoManager.SystemManager.Converter
{
   public class BoolToColorConverter:IValueConverter


    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter != null && parameter.ToString().Equals("reverse"))
            {
                if (value.Equals(true))

                { return System.Windows.Media.Brushes.Black; }
                return System.Windows.Media.Brushes.White;
            }

            if (value.Equals(true))
                
            { return System.Windows.Media.Brushes.White; }
            return System.Windows.Media.Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

