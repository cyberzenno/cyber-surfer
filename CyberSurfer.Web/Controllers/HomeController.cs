using CyberSurfer.Data.Utilities;
using CyberSurfer.Data.Interfaces;
using CyberSurfer.Web.Models;
using CyberSurfer.Data.Searchers.BingSearcher;
using System.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using CyberSurfer.Data.Implementations;

namespace CyberSurfer.Web.Controllers
{
    public class HomeController : Controller
    {
        private IAppConfigurationProvider appConfig = new AppConfigurationProvider();
        private ISearchService bingSearchService = new BingSearchService();
        private ISearchAnalyser searchAnalyser;


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string search, string searchProvider = "Bing")
        {
            IEnumerable<ISearchResult> results = new List<ISearchResult>();

            switch (searchProvider)
            {
                case "Bing":
                    results = bingSearchService.SearchFull(search, appConfig.MaxResults);
                    break;

                default:
                    break;
            }

            SaveLastSearch(results);

            var viewModel = new SearchResultsViewModel(search, results, searchProvider, appConfig.VirtualPageSize);

            return View(viewModel);
        }

        public ActionResult SearchDebug(string search)
        {
            var result = bingSearchService.SearchDebug(search);

            return Content(result);
        }

        public ActionResult Analyze()
        {
            var lastSearch = GetLastSearch();
            var summaryBlob = lastSearch.Select(r => r.Summary).Aggregate((x, y) => x + " " + y);

            searchAnalyser = new SearchAnalyser(summaryBlob);
            var wordsOccurrences = searchAnalyser.CountWordsOccurences();

            var model = new SearchAnalysisViewModel();
            model.WordsOccurences = wordsOccurrences;

            return View(model);
        }

        /// <summary>
        /// Download the last saved search from App_Data/SearchResult.csv
        /// </summary>
        /// <returns></returns>
        public ActionResult SaveToCsv()
        {
            var lastSearchResults = GetLastSearch();

            var csvExporter = new CsvExport();
            csvExporter.AddRows<ISearchResult>(lastSearchResults);
            var resultsAsCsv = csvExporter.Export();

            return File(new System.Text.UTF8Encoding().GetBytes(resultsAsCsv), "text/csv", "SearchResult.csv");
        }

        //TODO: not good AT ALL to save in the session
        private void SaveLastSearch(IEnumerable<ISearchResult> results)
        {
            Session["LastSearch"] = results;
        }

        private IEnumerable<ISearchResult> GetLastSearch()
        {
            var results = (IEnumerable<ISearchResult>)Session["LastSearch"];
            return results;
        }

    }
}