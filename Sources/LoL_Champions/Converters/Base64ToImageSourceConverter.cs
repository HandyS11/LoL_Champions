using System.Globalization;

namespace LoL_Champions.Converters
{
    public class Base64ToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.FromStream(() => new MemoryStream(System.Convert.FromBase64String(value as string)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
