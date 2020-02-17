using CyberSurfer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CyberSurfer.Data.Implementations
{
    public class SearchService : ISearchService
    {
        protected IConfigurationProvider configurationProvider;
        protected ISearchUrlBuilder searchUrlBuilder;
        protected ISearchWebClient searchWebClient;
        protected ISearchParser searchParser;

        public SearchService() { }

        public SearchService(ISearchUrlBuilder searchUrlBuilder, ISearchWebClient searchWebClient, ISearchParser searchParser)
        {
            this.searchUrlBuilder = searchUrlBuilder;
            this.searchWebClient = searchWebClient;
            this.searchParser = searchParser;
        }

        public IEnumerable<ISearchResult> Search(string search, int page)
        {
            try
            {
                //Build search url
                var searchUrl = searchUrlBuilder.BuildSearchUrl(search, page);

                //Get the plane Html result
                var searchHtmlResult = searchWebClient.Search(searchUrl);

                //Parse html and convert it to Model
                IEnumerable<ISearchResult> searchResults = searchParser.Parse(searchHtmlResult);

                SetIncrementalId(searchResults);

                return searchResults;
            }
            catch (Exception ex)
            {
                return new List<ISearchResult>
                {
                    new SearchResult
                    {
                        Id = 1,
                        Title= $"Error on page {page}",
                        Summary = ex.Message
                    }
                };
            }
        }

        public IEnumerable<ISearchResult> SearchFull(string search, int maxResults = 100)
        {
            var fullSearchResults = new List<ISearchResult>();

            var startPage = 1;
            while (fullSearchResults.Count() < maxResults)
            {
                var currentResults = Search(search, startPage++);

                if (currentResults != null && currentResults.Count() > 0)
                {
                    fullSearchResults.AddRange(currentResults);
                }
                else
                {
                    break;
                }
            }

            fullSearchResults = fullSearchResults.Take(maxResults).ToList();

            SetIncrementalId(fullSearchResults);

            return fullSearchResults;
        }

        public string SearchDebug(string search, int page)
        {
            //Build search url
            var searchUrl = searchUrlBuilder.BuildSearchUrl(search, page);

            //Get the plane Html result
            var searchHtmlResult = searchWebClient.Search(searchUrl);

            return searchHtmlResult;
        }

        private void SetIncrementalId(IEnumerable<ISearchResult> results)
        {
            //TODO: find better solution to incremental id
            var counter = 1;
            results.ToList().ForEach(r => r.Id = counter++);
        }
    }
}
