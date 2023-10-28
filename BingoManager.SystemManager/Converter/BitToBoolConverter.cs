using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace BingoManager.SystemManager.Converter
{
 public   class BitToBoolConverter:IValueConverter

    {


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (System.Convert.ToBoolean(value) == false)
            { return 0; }
            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (System.Convert.ToInt16(value) == 0)
            { return false; }
            return true;
        }
    }
}
