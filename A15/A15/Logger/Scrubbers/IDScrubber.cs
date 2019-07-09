using System.Text.RegularExpressions;

namespace Logger
{
    public class IDScrubber : AbstractScrubber
    {
        private IDScrubber() { }

        private static IDScrubber _Instance;

        public static IDScrubber Instance => _Instance ?? (_Instance = new IDScrubber());

        /// <summary>
        /// Regular expression for ID:
        /// 521-32-1212
        /// </summary>
        protected override Regex PIIRegEx => new Regex(@"(\d{9}-\d{1})|(\d{3}-\d{2}-\d{4})");

        public override string Scrub(string content) => this.MaskPII(content, this.MaskNumbers);
    }
}