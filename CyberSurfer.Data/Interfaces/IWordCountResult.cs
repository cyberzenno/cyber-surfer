using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSurfer.Data.Interfaces
{
    public interface IWordCountResult
    {
        string Word { get; set; }
        int Count { get; set; }
    }
}
