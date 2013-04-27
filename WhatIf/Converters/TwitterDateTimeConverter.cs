using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WhatIf.Converters
{
    public class TwitterDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            const string format = "ddd, dd MMM yyyy HH:mm:ss zzzz";
            return DateTime.ParseExact(value.ToString(), format, System.Globalization.CultureInfo.InvariantCulture).ToLocalTime().ToString("hh:mm tt - dd MMM yy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((DateTime)value).ToString("ddd, dd MMM yyyy HH:mm:ss zzzz");
        }
    }
}