using CyberSurfer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSurfer.Data.Interfaces
{
    public interface ISearchAnalyser
    {
        IDictionary<string, int> CountWordsOccurences();
        IDictionary<string, int> CountDomainsOccurences();
    }
}
