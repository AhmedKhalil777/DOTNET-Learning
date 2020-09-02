using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using TreeViews.Demo.Contracts;
using TreeViews.Demo.Processors;

namespace TreeViews.Demo
{
    [ValueConversion(typeof(string) ,  typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

      
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            string image = (string)value;
            
            return new BitmapImage(new Uri($"/Images/{image}.png" , UriKind.Relative));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
