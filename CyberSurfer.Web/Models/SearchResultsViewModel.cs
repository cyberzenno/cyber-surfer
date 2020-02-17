using CyberSurfer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace CyberSurfer.Web.Models
{
    public class SearchResultsViewModel
    {
        public string Search { get; set; }
        public string SearchProvider { get; private set; }
        public int TotalResults { get; private set; }

        public IEnumerable<ISearchResult> Column1 { get; private set; }
        public IEnumerable<ISearchResult> Column2 { get; private set; }
        public IEnumerable<ISearchResult> Column3 { get; private set; }
        public IEnumerable<ISearchResult> Column4 { get; private set; }

        public SearchResultsViewModel(string search, IEnumerable<ISearchResult> results, string searchProvider, int pageSize = 10)
        {
            Search = search;
            SearchProvider = searchProvider;
            TotalResults = results.Count();

            Column1 = results.ToPagedList(1, pageSize);
            Column2 = results.ToPagedList(2, pageSize);
            Column3 = results.ToPagedList(3, pageSize);
            Column4 = results.ToPagedList(4, pageSize);
        }

    }
}