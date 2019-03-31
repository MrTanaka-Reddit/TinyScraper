using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Scraper
{
    class FoundFile
    {
        public bool Select { get; set; }

        public string Name { get; set; }
        public string Url { get; set; }        
    }
}
