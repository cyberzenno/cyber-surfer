using CyberSurfer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CyberSurfer.Data.Implementations
{
    public class SearchWebClient : ISearchWebClient
    {
        public string Search(string searchUrl)
        {
            var client = new WebClient();
            var content = client.DownloadString(searchUrl);
            return content;
        }
    }
}