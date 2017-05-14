using CyberSurfer.Data.Interfaces;
using CyberSurfer.Data.Implementations;
using CyberSurfer.Data.Utilities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CyberSurfer.Data.Searchers.BingSearcher
{
    public class BingSearchParser : ISearchParser
    {
        public IEnumerable<ISearchResult> Parse(string searchHtmlResult)
        {
            List<ISearchResult> results = new List<ISearchResult>();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(searchHtmlResult);

            var searchResultNodes = doc.DocumentNode.SelectNodes(".//li[@class='b_algo']");

            //Exit if no results
            if (searchResultNodes == null) return results;

            foreach (var node in searchResultNodes)
            {
                //TODO: implement exception handling
                var newResult = new SearchResult();

                try
                {
                    var url = node.SelectSingleNode(".//h2/a").GetAttributeValue("href", "");
                    var title = node.SelectSingleNode(".//h2/a/@href").InnerHtml;
                    var summary = node.SelectSingleNode(".//div[@class='b_caption']/p").InnerHtml;

                    newResult.Url = CustomUtlities.StripTagsRegexCompiled(url);
                    newResult.Title = CustomUtlities.StripTagsRegexCompiled(title);
                    newResult.Summary = CustomUtlities.StripTagsRegexCompiled(summary);

                    results.Add(newResult);
                }
                catch (Exception ex)
                {
                    newResult.Title = "Error in parsing";
                    newResult.Summary = ex.Message;
                }
            }

            return results;
        }
    }
}