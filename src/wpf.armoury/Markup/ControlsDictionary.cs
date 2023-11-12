using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace wpf.armoury;

[Localizability(LocalizationCategory.Ignore)]
[Ambient]
[UsableDuringInitialization(true)]
public class ControlsDictionary : ResourceDictionary
{
    private const String _dictionaryUri = "pack://application:,,,/wpf.armoury;component/Resources/Generic.xaml";
    public ControlsDictionary() 
    {
        Source = new Uri(_dictionaryUri, UriKind.Absolute);
    }
}
