using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logger
{
    public class CCScrubber : AbstractScrubber
    {
        /// <summary>
        /// return regex for filtering
        /// </summary>
        protected override Regex PIIRegEx => new Regex(@"\d{4}-\d{4}-\d{4}-\d{4}");


        /// <summary>
        /// how to scrub text
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public override string Scrub(string content)
            => PIIRegEx.Replace(content, MaskNumbers);

        /// <summary>
        /// Singleton pattern
        /// </summary>
        private static CCScrubber _Instance;

        public static CCScrubber Instance => _Instance ?? (_Instance = new CCScrubber());
    }
}
