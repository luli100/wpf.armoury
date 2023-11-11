using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace wpf.armoury.Converters;

[ValueConversion(typeof(Boolean), typeof(Visibility))]
internal class BooleanToVisibilityConverter : ConverterMarkupExtension<BooleanToVisibilityConverter>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is Boolean ? Visibility.Visible : Visibility.Collapsed;
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Convert(value, targetType, parameter, culture);
    }
}
