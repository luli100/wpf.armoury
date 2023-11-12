using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpf.armoury.Appearance
{
    public static class ApplicationThemeManager
    {
        public static ApplicationTheme CurrentTheme { get; set; } = ApplicationTheme.Unknown;
        private const String _themesDictionaryPath = "pack://application:,,,/wpf.armoury;component/Themes/";
        public static String GetThemesDictionary()
        {
            return _themesDictionaryPath;
        }

        public static void Apply(ApplicationTheme theme)
        {
            var dics = Application.Current.Resources.MergedDictionaries;
            foreach (var dic in dics)
            {
                if (dic is ThemesDictionary)
                {
                    if (ApplicationThemeManager.CurrentTheme != theme)
                    {
                        ApplicationThemeManager.CurrentTheme = theme;
                        var themeName = theme switch
                        {
                            ApplicationTheme.Dark => nameof(ApplicationTheme.Dark),
                            ApplicationTheme.Light => nameof(ApplicationTheme.Light),
                            _ => nameof(ApplicationTheme.Light)
                        };

                        dic.Source = new Uri($"{_themesDictionaryPath}{themeName}.xaml", UriKind.Absolute);
                    }

                    return;
                }
            }
        }
    }
}
