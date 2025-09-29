using System.Globalization;
using Microsoft.Maui.Controls;

namespace MaterialManagerApp.Converters;

public class NullToBoolConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }

        return value is not null;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
}
