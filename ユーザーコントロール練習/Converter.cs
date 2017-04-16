using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ユーザーコントロール練習 {
    class Converter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            int res;
            if (int.TryParse((string)value, out res)) {
                return res;
            }else {
                return null;
            }
        }
    }
}
