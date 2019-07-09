using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class FileLoggerFactory
    {
        private static XsvFormatter XsvFormatterInstance;
        public static FileLogger<NoLockLogWriter> NoLockAllScrubberIncrementalCvsLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            CsvLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new IncrementalLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockAllScrubberIncrementalConsoleLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            ConsoleLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new IncrementalLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockAllScrubberIncrementalXmlLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            XmlLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new IncrementalLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockAllScrubberIncrementalXsvLogWriter(string logDir, string logPrefix, char separator) => new FileLogger<NoLockLogWriter>(
            XsvFormatterInstance = new XsvFormatter(separator),
            PrivacyScrubberFactory.ScrubAll(),
            new IncrementalLogFileName(logDir, logPrefix, XsvFormatterInstance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockAllScrubberTimeBasedCvsLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            CsvLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new TimeBasedLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockAllScrubberTimeBasedConsoleLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            ConsoleLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new TimeBasedLogFileName(logDir, logPrefix, ConsoleLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockAllScrubberTimeBasedXmlLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            XmlLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new TimeBasedLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockAllScrubberTimeBasedXsvLogWriter(string logDir, string logPrefix, char separator) => new FileLogger<NoLockLogWriter>(
            XsvFormatterInstance = new XsvFormatter(separator),
            PrivacyScrubberFactory.ScrubAll(),
            new TimeBasedLogFileName(logDir, logPrefix, XsvFormatterInstance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockNullScrubberIncrementalCvsLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            CsvLogFormatter.Instance,
            new PrivacyScrubber(),
            new IncrementalLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockNullScrubberIncrementalConsoleLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            ConsoleLogFormatter.Instance,
            new PrivacyScrubber(),
            new IncrementalLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockNulllScrubberIncrementalXmlLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            XmlLogFormatter.Instance,
            new PrivacyScrubber(),
            new IncrementalLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockNullScrubberIncrementalXsvLogWriter(string logDir, string logPrefix, char separator) => new FileLogger<NoLockLogWriter>(
            XsvFormatterInstance = new XsvFormatter(separator),
            new PrivacyScrubber(),
            new IncrementalLogFileName(logDir, logPrefix, XsvFormatterInstance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);

        public static FileLogger<NoLockLogWriter> NoLockNullScrubberTimeBasedCvsLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            CsvLogFormatter.Instance,
            new PrivacyScrubber(),
            new TimeBasedLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockNullScrubberTimeBasedConsoleLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            ConsoleLogFormatter.Instance,
            new PrivacyScrubber(),
            new TimeBasedLogFileName(logDir, logPrefix, ConsoleLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockNullScrubberTimeBasedXmlLogWriter(string logDir, string logPrefix) => new FileLogger<NoLockLogWriter>(
            XmlLogFormatter.Instance,
            new PrivacyScrubber(),
            new TimeBasedLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<NoLockLogWriter> NoLockNullScrubberTimeBasedXsvLogWriter(string logDir, string logPrefix, char separator) => new FileLogger<NoLockLogWriter>(
            XsvFormatterInstance = new XsvFormatter(separator),
            new PrivacyScrubber(),
            new TimeBasedLogFileName(logDir, logPrefix, XsvFormatterInstance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllScrubberIncrementalCvsLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            CsvLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new IncrementalLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllScrubberIncrementalConsoleLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            ConsoleLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new IncrementalLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllScrubberIncrementalXmlLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            XmlLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new IncrementalLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllScrubberIncrementalXsvLogWriter(string logDir, string logPrefix, char separator) => new FileLogger<ConcurrentLogWriter>(
            XsvFormatterInstance = new XsvFormatter(separator),
            PrivacyScrubberFactory.ScrubAll(),
            new IncrementalLogFileName(logDir, logPrefix, XsvFormatterInstance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllScrubberTimeBasedCvsLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            CsvLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new TimeBasedLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllScrubberTimeBasedConsoleLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            ConsoleLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new TimeBasedLogFileName(logDir, logPrefix, ConsoleLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllScrubberTimeBasedXmlLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            XmlLogFormatter.Instance,
            PrivacyScrubberFactory.ScrubAll(),
            new TimeBasedLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllScrubberTimeBasedXsvLogWriter(string logDir, string logPrefix, char separator) => new FileLogger<ConcurrentLogWriter>(
            XsvFormatterInstance = new XsvFormatter(separator),
            PrivacyScrubberFactory.ScrubAll(),
            new TimeBasedLogFileName(logDir, logPrefix, XsvFormatterInstance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullScrubberIncrementalCvsLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            CsvLogFormatter.Instance,
            new PrivacyScrubber(),
            new IncrementalLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullScrubberIncrementalConsoleLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            ConsoleLogFormatter.Instance,
            new PrivacyScrubber(),
            new IncrementalLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNulllScrubberIncrementalXmlLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            XmlLogFormatter.Instance,
            new PrivacyScrubber(),
            new IncrementalLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullScrubberIncrementalXsvLogWriter(string logDir, string logPrefix, char separator) => new FileLogger<ConcurrentLogWriter>(
            XsvFormatterInstance = new XsvFormatter(separator),
            new PrivacyScrubber(),
            new IncrementalLogFileName(logDir, logPrefix, XsvFormatterInstance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);

        public static FileLogger<ConcurrentLogWriter> ConcurrentNullScrubberTimeBasedCvsLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            CsvLogFormatter.Instance,
            new PrivacyScrubber(),
            new TimeBasedLogFileName(logDir, logPrefix, CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullScrubberTimeBasedConsoleLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            ConsoleLogFormatter.Instance,
            new PrivacyScrubber(),
            new TimeBasedLogFileName(logDir, logPrefix, ConsoleLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullScrubberTimeBasedXmlLogWriter(string logDir, string logPrefix) => new FileLogger<ConcurrentLogWriter>(
            XmlLogFormatter.Instance,
            new PrivacyScrubber(),
            new TimeBasedLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullScrubberTimeBasedXsvLogWriter(string logDir, string logPrefix, char separator) => new FileLogger<ConcurrentLogWriter>(
            XsvFormatterInstance = new XsvFormatter(separator),
            new PrivacyScrubber(),
            new TimeBasedLogFileName(logDir, logPrefix, XsvFormatterInstance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);
    }
}
