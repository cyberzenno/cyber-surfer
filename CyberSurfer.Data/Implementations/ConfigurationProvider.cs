using CyberSurfer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSurfer.Data.Implementations
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public string BingSearchBaseUrl
        {
            //TODO: implement via App.config or similar
            get { return "https://www.bing.com/search"; }
        }
    }
}
