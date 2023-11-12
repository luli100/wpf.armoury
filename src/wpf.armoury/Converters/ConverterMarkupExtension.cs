using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace wpf.armoury.Converters;

public abstract class ConverterMarkupExtension<T> : MarkupExtension, IValueConverter where T : class, new()
{
    private static T _converter = null;
    public override Object ProvideValue(IServiceProvider serviceProvider)
    {
        return _converter ?? (_converter = new T());
    }

    public abstract Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture);


    public abstract Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture);
}
