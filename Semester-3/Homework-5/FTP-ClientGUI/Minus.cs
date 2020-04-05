using System;
using System.Windows.Data;

namespace FtpClientGUI
{
    /// <summary>
    /// Converter which substracts 2
    /// </summary>
    public class Minus : IValueConverter
    {
        /// <summary>
        /// Substracts 2
        /// </summary>
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo culture)
        {
            return (int)value - 2;
        }

        /// <summary>
        /// Substracts 2
        /// </summary>
        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo culture)
        {
            return (int)value - 2;
        }
    }
}