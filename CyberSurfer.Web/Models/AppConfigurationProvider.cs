using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberSurfer.Web.Models
{
    public class AppConfigurationProvider : IAppConfigurationProvider
    {
        public string CsvSearchResultFileName
        {
            //TODO: define a better policy for the file name
            get { return "SearchResult.csv"; }
        }

        public string AppDataFolderPath
        {
            get { return "~/App_Data/"; }
        }


        public int VirtualPageSize
        {
            get { return 30; }
        }

        public int MaxResults
        {
            get { return 200; }
        }
    }
}