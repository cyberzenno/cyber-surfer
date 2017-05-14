using CyberSurfer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSurfer.Data.Implementations
{
    public class WordCountResult : IWordCountResult
    {
        public string Word { get; set; }

        public int Count { get; set; }
    }
}
