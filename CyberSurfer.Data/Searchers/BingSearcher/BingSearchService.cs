using CyberSurfer.Data.Searchers.BingSearcher;
using CyberSurfer.Data.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSurfer.Data.Searchers.BingSearcher
{
    public class BingSearchService : SearchService
    {
        public BingSearchService()
        {
            this.configurationProvider = new ConfigurationProvider();
            this.searchUrlBuilder = new BingSearchUrlBuilder(configurationProvider);
            this.searchWebClient = new SearchWebClient();
            this.searchParser = new BingSearchParser();
        }
    }
}
