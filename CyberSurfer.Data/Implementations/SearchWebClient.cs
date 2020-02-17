using CyberSurfer.Data.Interfaces;
using System;
using System.IO;
using System.Net;

namespace CyberSurfer.Data.Implementations
{
    public class SearchWebClient : ISearchWebClient
    {
        public string Search(string searchUrl)
        {
            var client = new WebClient();

            //todo: temporary workaround to fix Bing issue
            var proxy = GetRandomPRoxyFromFile();

            client.Proxy = new WebProxy(proxy[0], int.Parse(proxy[1]));

            try
            {
                var content = client.DownloadString(searchUrl);

                return content;
            }
            catch
            {
                throw new Exception($"Empty for result for {proxy[0]}");
            }
        }

        private string[] GetRandomPRoxyFromFile()
        {
            var binFolderPath = AppDomain.CurrentDomain.RelativeSearchPath;
            var proxyListPath = Path.Combine(binFolderPath, "ProxyData", "ProxyList.txt");
            var proxyList = File.ReadAllLines(proxyListPath);

            var n = DateTime.Now.Ticks % proxyList.Length;

            var selectedProxy = proxyList[n].Split('_');
            return selectedProxy;
        }
    }
}