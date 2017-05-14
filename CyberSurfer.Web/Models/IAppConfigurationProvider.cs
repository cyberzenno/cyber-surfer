using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberSurfer.Web.Models
{
    public interface IAppConfigurationProvider
    {
        string AppDataFolderPath { get; }
        string CsvSearchResultFileName { get; }
        int VirtualPageSize { get; }
        int MaxResults { get; }
    }
}