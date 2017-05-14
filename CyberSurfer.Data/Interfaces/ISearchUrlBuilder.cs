using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyberSurfer.Data.Interfaces
{
    public interface ISearchUrlBuilder
    {
        string BuildSearchUrl(string search, int page = 1);
    }
}
