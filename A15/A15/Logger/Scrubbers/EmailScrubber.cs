using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Logger
{
    public class EmailScrubber : AbstractScrubber
    {
        /// <summary>
        /// Scrub first part of email
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public override string Scrub(string content)
            => PIIRegEx.Replace(content, MaskLetters).Replace("@", ".");
        private static EmailScrubber _Instance;

        public static EmailScrubber Instance => _Instance ?? (_Instance = new EmailScrubber());
        protected override Regex PIIRegEx => new Regex(@"([A-Z0-9._%+-]+)(@)([A-Z0-9.-]+\.[A-Z]{2,})", RegexOptions.IgnoreCase);
    }
}
