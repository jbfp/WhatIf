using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WhatIf.Library;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace WhatIf
{
    public class TweetsCollection : ObservableCollection<Result>, ISupportIncrementalLoading
    {
        public async Task<LoadMoreItemsResult> Get(uint count)
        {
            if (App.HasInternet() == false)
                return new LoadMoreItemsResult { Count = 0 };

            const string baseUrl = "http://search.twitter.com/search.json?rpp={0}&max_id={1}&result_type=mixed&lang=en&q=%22What%20if%22";
            string url = string.Format(baseUrl, count, Count == 0 ? 0 : this.Min(tweet => tweet.id));

            using (var webClient = new HttpClient())
            {
                var json = await webClient.GetStringAsync(url);
                var root = JsonConvert.DeserializeObject<RootObject>(json);
                var countLoaded = Convert.ToUInt32(root.results.Count);

                foreach (var item in root.results)
                    Add(item);

                return new LoadMoreItemsResult { Count = countLoaded };
            }
        }

        public bool HasMoreItems
        {
            get { return true; }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return Get(count).AsAsyncOperation();
        }
    }
}
