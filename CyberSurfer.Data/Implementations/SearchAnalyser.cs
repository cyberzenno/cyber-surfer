using CyberSurfer.Data.Interfaces;
using CyberSurfer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSurfer.Data.Implementations
{
    public class SearchAnalyser : ISearchAnalyser
    {
        private string blobToAnalyze = "";

        public SearchAnalyser(string blobToAnalyze)
        {
            this.blobToAnalyze = blobToAnalyze.ToLower();
        }

        //TODO: a lot of logic in here. Improve and refactor analyser structure
        public IDictionary<string, int> CountWordsOccurences()
        {
            var skipWordsLessThan = 3;
            var takeTop = 20;

            //quick cleanup
            var cleanedBlob = quickCleanUp(blobToAnalyze);

            var blobSplit = cleanedBlob.Split(' ');

            var wordsOccurences = (from word in blobSplit
                                   group word by word into g
                                   where g.Key.Length > skipWordsLessThan
                                   select new KeyValuePair<string, int>(g.Key, g.Count()))
                                   .OrderByDescending(w => w.Value).Take(takeTop);


            var wordsOccurencesDictionary = wordsOccurences.ToDictionary(w => w.Key, w => w.Value);
            return wordsOccurencesDictionary;
        }

        public IDictionary<string, int> CountDomainsOccurences()
        {
            throw new NotImplementedException();
        }

        private string quickCleanUp(string blob)
        {
            var cleanedBlob = blob.Replace(",", " ");
            cleanedBlob = cleanedBlob.Replace(".", " ");
            cleanedBlob = cleanedBlob.Replace("?", " ");
            cleanedBlob = cleanedBlob.Replace("!", " ");

            //etc

            return cleanedBlob;
        }
    }
}
