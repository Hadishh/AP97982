using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A12
{
    public class AppAnalysis
    {
        public List<AppData> Apps;
        private AppAnalysis() {
            Apps = new List<AppData>();
        }
        public static AppAnalysis AppAnalysisFactory(string appDataPath)
        {
            //TODO
            return null;
        }
        public long AllAppsCount()
        {
            //TODO
            return 0;
        }
        public long AppsAboveXRatingCount(double x)
        {
            //TODO
            return 0;
        }
        public long RecentlyUpdatedCount(DateTime boundary)
        {
            //TODO
            return 0;
        }
        public string RecentlyUpdatedFreqCat(DateTime boundry)
        {
            //TODO
            return null;
        }
        public List<string> MostRatedGategories(double ratingBoundry, int n)
        {
            //TODO
            return null;
        }

    }
}
