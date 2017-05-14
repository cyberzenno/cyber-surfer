using CyberSurfer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberSurfer.Data.Implementations
{
    public class SearchResult : ISearchResult
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
    }
}