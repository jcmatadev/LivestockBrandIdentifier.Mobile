using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace LivestockBrandIdentifier.Mobile
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var base64string = value == null || (string)value == null || string.IsNullOrWhiteSpace(((string)value)) ?
                throw new ArgumentNullException("Invalid value") :
                (string)value;

            var imageData = base64string.Split(',')[1];

            return ImageSource.FromStream(() => new MemoryStream(System.Convert.FromBase64String(imageData)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
