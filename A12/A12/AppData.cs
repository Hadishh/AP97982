using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A12
{
    public class AppData
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Rating { get; set; }
        public long Reviews { get; set; }
        public double Size { get; set; }
        public long Installs { get; set; }
        public long IsFree { get; set; }
        public double Price { get; set; }
        public string ContentRating { get; set; }
        public List<string> Genres { get; set; }
        public DateTime LastUpdate { get; set; }
        public string CurrentVersion { get; set; }
        public string AndroidVersion { get; set; }
    }
}
