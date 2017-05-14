using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyberSurfer.Data.Interfaces
{
    public interface ISearchResult
    {
        int Id { get; set; }
        string Url { get; set; }
        string Title { get; set; }
        string Summary { get; set; }
    }
}
