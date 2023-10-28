using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace BingoManager.SystemManager.Converter
{
   public class FormatNumberConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter.ToString().ToLower().Equals("numberformat"))
            {
                return Microsoft.VisualBasic.Strings.FormatNumber(value, 0);
            }
            return Microsoft.VisualBasic.Strings.Format(value, parameter.ToString());
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
