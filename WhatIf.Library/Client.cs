using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WhatIf.Library
{
    public class Client
    {
        public const int ResultsPerPage = 100;

        public async Task<RootObject> Get(int page = 1)
        {
            if (page <= 0)
                page = 1;

            const string baseUrl = "http://search.twitter.com/search.json?rpp=100&q=%22What%20if%22";
            string url = string.Format(baseUrl, page, ResultsPerPage);

            using (var webClient = new HttpClient())
            {
                var json = await webClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<RootObject>(json);
            }
        }
    }
}