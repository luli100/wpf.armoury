using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace wpf.armoury.Converters;

[ValueConversion(typeof(Boolean), typeof(Visibility))]
internal class InvertBooleanToVisibilityConverter : ConverterMarkupExtension<InvertBooleanToVisibilityConverter>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is true? Visibility.Collapsed : Visibility.Visible;
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Convert(value, targetType, parameter, culture);
    }
}
