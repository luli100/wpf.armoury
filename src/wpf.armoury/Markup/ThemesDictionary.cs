using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpf.armoury.Appearance;

namespace wpf.armoury;

public class ThemesDictionary : ResourceDictionary
{
    
    public ApplicationTheme Theme
    {
        set => SetSelectedTheme(value);
    }

    public void SetSelectedTheme(ApplicationTheme selectedTheme)
    {
        if (ApplicationThemeManager.CurrentTheme != selectedTheme)
        {
            ApplicationThemeManager.CurrentTheme = selectedTheme;
            var themeName = selectedTheme switch
            {
                ApplicationTheme.Dark => nameof(ApplicationTheme.Dark),
                ApplicationTheme.Light => nameof(ApplicationTheme.Light),
                _ => nameof(ApplicationTheme.Light)
            };

            Source = new Uri($"{ApplicationThemeManager.GetThemesDictionary()}{themeName}.xaml", UriKind.Absolute);
        }
    }

    public ThemesDictionary()
    {
        SetSelectedTheme(ApplicationTheme.Dark);
    }
}
