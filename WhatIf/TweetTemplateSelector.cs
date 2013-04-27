using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WhatIf
{
    public class TweetTemplateSelector : DataTemplateSelector
    {
        public static readonly Random Random = new Random();

        public DataTemplate EvenTemplate { get; set; }
        public DataTemplate OddTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var index = Random.Next(0, 3);

            if (index % 2 == 0)
                return EvenTemplate;
            else
                return OddTemplate;
        }
    }
}
