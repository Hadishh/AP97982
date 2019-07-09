namespace Logger
{
    public static class PrivacyScrubberFactory
    {
        public static IPrivacyScrubber ScrubAll() => new PrivacyScrubber(
                PhoneNumberScrubber.Instance,
                IDScrubber.Instance,
                FullNameScrubber.Instance,
                CCScrubber.Instance,
                EmailScrubber.Instance
            );
        /// <summary>
        /// return class with interface IprivacyScrubber to scrub phone numbers and id and card numbers
        /// </summary>
        /// <returns></returns>
        public static IPrivacyScrubber ScrubNumbers() => new PrivacyScrubber(
                PhoneNumberScrubber.Instance,
                IDScrubber.Instance,
                CCScrubber.Instance
            );
        /// <summary>
        /// return class with interface IprivacyScrubber to scrub Emails and Names
        /// </summary>
        /// <returns></returns>
        public static IPrivacyScrubber ScrubLetters() => new PrivacyScrubber(
                EmailScrubber.Instance,
                FullNameScrubber.Instance
            );
    }
}