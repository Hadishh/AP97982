using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static AppAnalysis AppAnalysisFactory(string csvAddress)
        {
             var appAnalysis = new AppAnalysis();
             using (TextFieldParser parser = new TextFieldParser(csvAddress))
             {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();
                while (! parser.EndOfData)
                 {
                     fields = parser.ReadFields();
                     appAnalysis.AppendApp(fields);
                 }
             }
             return appAnalysis;
        }

        private void AppendApp(string[] fields)
        {
            Apps.Add(new AppData(fields));
            return;
        }

        public long AllAppsCount()
            => Apps.Count();
        public long AppsAboveXRatingCount(double x)
            => Apps.Where(d => d.Rating >= x).Count();
        public long RecentlyUpdatedCount(DateTime boundary)
            => Apps.Where(d => d.LastUpdate >= boundary).Count();
        public string RecentlyUpdatedFreqCat(DateTime boundry)
            => Apps.Where(d => d.LastUpdate >= boundry)
                .GroupBy(d => d.Category)
                .OrderByDescending(g => g.Count())
                .First().Key;
        public List<string> MostRatedCategories(double ratingBoundry, int n)
           => Apps.Where(d => d.Rating > ratingBoundry)
                .GroupBy(d => d.Category)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(n)
                .ToList();
        public double TopQuarterBoundary()
            => Apps.Where(d => d.Category == "PHOTOGRAPHY")
                .OrderBy(d => d.Rating)
                .GroupBy(d => d.Category)
                .Select(g => (g.ElementAt(g.Count() * 3 / 4))).First().Rating;
        public Tuple<string , string> ExtremeMeanUpdateElapse(DateTime today)
        {
            var sortedItems = Apps.GroupBy(d => d.Category)
            .OrderBy(g => g.Average(d => (today - d.LastUpdate).TotalHours));
            return Tuple.Create(sortedItems.First().Key, sortedItems.Last().Key);
        }
        public List<string> XMostProfitables(int x)
            => Apps.Where(d => !d.IsFree)
                   .OrderByDescending(d => d.Installs * d.Price)
                   .ThenByDescending(d => d.Rating)
                   .Take(x).Select(d => d.Name)
                   .ToList();
        
        public List<string> XCoolestApps(int x, Func<AppData, double> criteria)
           => Apps.OrderBy(criteria).Take(x).Select(d => d.Name).ToList();
    }
}