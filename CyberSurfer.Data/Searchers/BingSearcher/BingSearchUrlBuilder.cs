using CyberSurfer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberSurfer.Data.Searchers.BingSearcher
{
    public class BingSearchUrlBuilder : ISearchUrlBuilder
    {
        private readonly IConfigurationProvider configurationProvider;

        public BingSearchUrlBuilder(IConfigurationProvider configurationProvider)
        {
            this.configurationProvider = configurationProvider;
        }

        public string BuildSearchUrl(string search, int page = 1)
        {
            var bingSearchBaseUrl = configurationProvider.BingSearchBaseUrl;
            var encodedSearch = HttpUtility.UrlEncode(search);
            var bingPageIndex = page * 10 - 9;

            var fullUrl = string.Format("{0}?q={1}&first={2}", bingSearchBaseUrl, encodedSearch, bingPageIndex);

            return fullUrl;
        }
    }
}