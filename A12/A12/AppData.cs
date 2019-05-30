using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace A12
{
    public class AppData
    {
        public string Name;
        public string Category; 
        public double Rating;
        public long Reviews;
        public double Size;
        public long Installs;
        public bool IsFree;
        public double Price;
        public string ContentRating;
        public List<string> Genres;
        public DateTime LastUpdate;
        public string CurrentVersion;
        public string AndroidVersion;
        public AppData(string[] fields)
        {
            Genres = new List<string>();
            Name = fields[0];
            Category = fields[1];
            if(!double.TryParse(fields[2], out Rating))
                Rating = 0.0;
            if (!long.TryParse(fields[3], out Reviews))
                Reviews = 0;
            if (!double.TryParse(fields[4].Trim('M'), out Size))
                Size = 0;
            if (!long.TryParse(fields[5].Trim('+', '"').Replace(",", string.Empty), out Installs))
                Installs = 0;
            IsFree = fields[6].Contains("Free");
            if (!double.TryParse(fields[7].Trim('$'), out Price))
                Price = 0.0;
            ContentRating = fields[8];
            Genres.AddRange(fields[9].Split(';'));
            try
            {
                LastUpdate = DateTime.ParseExact(fields[10], new string[] { "dd-MMM-yy", "d-MMM-yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
            catch (FormatException)
            {
                LastUpdate = DateTime.Today;
            }
            CurrentVersion = fields[11];
            AndroidVersion = fields[12];
        }
    }
}
