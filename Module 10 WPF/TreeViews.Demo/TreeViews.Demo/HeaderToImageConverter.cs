using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TreeViews.Demo
{
    [ValueConversion(typeof(string) ,  typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

      
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = "file.png";

            
            var path = (string)value;
            var name = MainWindow.GetFileFolderName(path);
            if (path == null)
                return null;
            if (string.IsNullOrEmpty(name))
            {
                image = "Drive.png";
            }
            else if(path == "Open")
            {
                image = "folderOpen.png";
            }
            else if(new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            {
                image = "folder.png";
            }
            
            return new BitmapImage(new Uri($"E://Projects//DOTNET-Learning//Module 10 WPF//TreeViews.Demo//TreeViews.Demo//Images//{image}"));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
