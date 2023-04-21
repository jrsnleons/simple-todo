using System;
using Xamarin.Forms;

namespace Todo
{
    public class TextDecorationsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return TextDecorations.Strikethrough;
            }
            else
            {
                return TextDecorations.None;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
