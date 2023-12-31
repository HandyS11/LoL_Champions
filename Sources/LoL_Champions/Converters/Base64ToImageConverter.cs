﻿using System.Globalization;
using CommunityToolkit.Maui.Converters;

namespace LoL_Champions.Converters
{
    public class Base64ToImageConverter : ByteArrayToImageSourceConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var base64 = value as string;
            if (base64 == null) return null;
            try
            {
                var bytes = System.Convert.FromBase64String(base64);
                return ConvertFrom(bytes);
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageSource = value as ImageSource;
            if (imageSource == null) return null;
            try
            {
                var bytes = ConvertBackTo(imageSource);
                return System.Convert.ToBase64String(bytes);
            }
            catch
            {
                return null;
            }
        }
    }
}
