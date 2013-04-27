using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WhatIf.Converters
{
    public class HtmlDecoder : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return WebUtility.HtmlDecode(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return WebUtility.HtmlEncode(value.ToString());
        }
    }
}
