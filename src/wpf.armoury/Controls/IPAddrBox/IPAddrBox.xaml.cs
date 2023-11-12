using System;
using System.Windows;
using System.Windows.Controls;

namespace wpf.armoury.Controls;

[TemplatePart(Name = "Part1TextBoxElement", Type = typeof(TextBox))]
[TemplatePart(Name = "Part2TextBoxElement", Type = typeof(TextBox))]
[TemplatePart(Name = "Part3TextBoxElement", Type = typeof(TextBox))]
[TemplatePart(Name = "Part4TextBoxElement", Type = typeof(TextBox))]
public class IPAddrBox : Control
{
    public TextBox Part1TextBoxElement { get; private set; }
    public TextBox Part2TextBoxElement { get; private set; }
    public TextBox Part3TextBoxElement { get; private set; }
    public TextBox Part4TextBoxElement { get; private set; }

    static IPAddrBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(IPAddrBox), new FrameworkPropertyMetadata(typeof(IPAddrBox)));
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        Part1TextBoxElement = (TextBox)GetTemplateChild("Part1TextBox");
        Part2TextBoxElement = (TextBox)GetTemplateChild("Part2TextBox");
        Part3TextBoxElement = (TextBox)GetTemplateChild("Part3TextBox");
        Part4TextBoxElement = (TextBox)GetTemplateChild("Part4TextBox");
        this.Part1TextBoxElement.GotFocus += PartTextBoxElement_GotFocus;
    }

    private void PartTextBoxElement_GotFocus(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox tb)
        {
            tb.SelectAll();
        }
    }

    internal String Part1
    {
        get { return (String)GetValue(Part1Property); }
        set { SetValue(Part1Property, value); }
    }

    internal static readonly DependencyProperty Part1Property =
        DependencyProperty.Register("Part1", typeof(string), typeof(IPAddrBox), new PropertyMetadata(string.Empty, OnPartChanged));


    internal String Part2
    {
        get { return (String)GetValue(Part2Property); }
        set { SetValue(Part2Property, value); }
    }

    internal static readonly DependencyProperty Part2Property =
        DependencyProperty.Register("Part2", typeof(String), typeof(IPAddrBox), new PropertyMetadata(String.Empty, OnPartChanged));



    internal String Part3
    {
        get { return (String)GetValue(Part3Property); }
        set { SetValue(Part3Property, value); }
    }

    internal static readonly DependencyProperty Part3Property =
        DependencyProperty.Register("Part3", typeof(String), typeof(IPAddrBox), new PropertyMetadata(String.Empty, OnPartChanged));




    internal String Part4
    {
        get { return (String)GetValue(Part4Property); }
        set { SetValue(Part4Property, value); }
    }

    internal static readonly DependencyProperty Part4Property =
        DependencyProperty.Register("Part4", typeof(String), typeof(IPAddrBox), new PropertyMetadata(String.Empty, OnPartChanged));

    private static void OnPartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if(d is IPAddrBox box)
        {
            if (e.NewValue is not null)
            {
                String newVaule;
                if (((String)e.NewValue).Contains('.'))
                {
                    newVaule = ((String)e.NewValue).Replace(".", "");
                    switch (e.Property.Name)
                    {
                        case nameof(Part1):
                            {
                                box.Part1 = String.IsNullOrEmpty(newVaule) ? (String)e.OldValue : newVaule;
                                box.Part2TextBoxElement.Focus();
                                box.Part2TextBoxElement.SelectAll();
                            }
                            break;
                        case nameof(Part2):
                            {
                                box.Part2 = String.IsNullOrEmpty(newVaule) ? (String)e.OldValue : newVaule;
                                box.Part3TextBoxElement.Focus();
                                box.Part3TextBoxElement.SelectAll();
                            }
                            break;
                        case nameof(Part3):
                            {
                                box.Part3 = String.IsNullOrEmpty(newVaule) ? (String)e.OldValue : newVaule;
                                box.Part4TextBoxElement.Focus();
                                box.Part4TextBoxElement.SelectAll();
                            }
                            break;
                        case nameof(Part4):
                            {
                                box.Part4 = String.IsNullOrEmpty(newVaule) ? (String)e.OldValue : newVaule;
                                box.Part1TextBoxElement.Focus();
                                box.Part1TextBoxElement.SelectAll();
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    newVaule = (String)e.NewValue;
                    if (newVaule.Length > 2)
                    {
                        switch (e.Property.Name)
                        {
                            case nameof(Part1):
                                {
                                    box.Part2TextBoxElement?.Focus();
                                    box.Part2TextBoxElement?.SelectAll();
                                }
                                break;
                            case nameof(Part2):
                                {
                                    box.Part3TextBoxElement?.Focus();
                                    box.Part3TextBoxElement?.SelectAll();
                                }
                                break;
                            case nameof(Part3):
                                {
                                    box.Part4TextBoxElement?.Focus();
                                    box.Part4TextBoxElement?.SelectAll();
                                }
                                break;
                            case nameof(Part4):
                                {
                                    box.Part1TextBoxElement?.Focus();
                                    box.Part1TextBoxElement?.SelectAll();
                                }
                                break;
                            default:
                                break;
                        }
                        
                    }
                }
            }

            box.IPAddr = $"{box.Part1}.{box.Part2}.{box.Part3}.{box.Part4}";
        }
    }





    public String IPAddr
    {
        get { return (String)GetValue(IPAddrProperty); }
        set { SetValue(IPAddrProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IPAddr.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IPAddrProperty =
        DependencyProperty.Register("IPAddr", typeof(String), typeof(IPAddrBox), new PropertyMetadata(String.Empty, OnIPAddrChanged));

    private static void OnIPAddrChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is not null)
        {
            if (e.NewValue is String ipaddr)
            {
                var addrs = ipaddr.Split(".");
                if (addrs.Length == 4)
                {
                    if (d is IPAddrBox box)
                    {
                        box.Part1 = addrs[0];
                        box.Part2 = addrs[1];
                        box.Part3 = addrs[2];
                        box.Part4 = addrs[3];
                    }
                }
            }
        }
    }
}
