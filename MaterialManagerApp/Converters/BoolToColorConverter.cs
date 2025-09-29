using System.Globalization;
using Microsoft.Maui.Controls;

namespace MaterialManagerApp.Converters;

public class BoolToColorConverter : IValueConverter
{
    public Color TrueColor { get; set; } = Color.FromArgb("#B00020");
    public Color FalseColor { get; set; } = Color.FromArgb("#1B5E20");

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool flag)
        {
            return flag ? TrueColor : FalseColor;
        }

        return FalseColor;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
}
