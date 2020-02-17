using CyberSurfer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSurfer.Data.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<ISearchResult> Search(string search, int page = 1);
        IEnumerable<ISearchResult> SearchFull(string search, int maxResults = 40);

        string SearchDebug(string search, int page = 1);
    }
}
