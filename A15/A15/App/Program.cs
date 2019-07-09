using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Logger
{
    class Program
    {
        static int WarnCount = 0;
        static int InfoCount = 0;
        static int ErrorCount = 0;
        static int DebugCount = 0;
        static void Main(string[] args)
        {
            ConsoleLogger clogger = new ConsoleLogger();
            FileLogger<LockedLogWriter> errorLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "a13_error", CsvLogFormatter.Instance.FileExtention),
                LogLevels.ErrorOnly,
                LogSources.All,
                true);

            FileLogger<LockedLogWriter> allLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "a13_all", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);

            FileLogger<LockedLogWriter> uiLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "a13_ui", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.Create(LogSource.UI),
                true);

            FileLogger<LockedLogWriter> allLogger1 = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "a13_all", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
            FileLogger<LockedLogWriter> allLogger2 = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "a13_all", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.Create(LogSource.Client),
                true
               );
            Logger.Loggers.Add(errorLogger);
            Logger.Loggers.Add(allLogger);
            Logger.Loggers.Add(clogger);
            Logger.Loggers.Add(uiLogger);
            Logger.Loggers.Add(allLogger1);
            Logger.Loggers.Add(allLogger2);
            // Logger is set up and ready to use
            //FileLogger<LockedLogWriter> allLogger3 = new FileLogger<LockedLogWriter>(
            //    CsvLogFormatter.Instance,
            //    new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
            //    new WeekdayLogFileName(@"c:\log", "a13_all", CsvLogFormatter.Instance.FileExtention),
            //    LogLevels.All,
            //    LogSources.All,
            //    true);
            ///Logger.Loggers.Add(allLogger3);
            // درسته که همه این دستورات را پشت سر هم زدم
            // ولی شما فرض کنید که اینها در جاهای مختلف برنامه 
            // زده شده...
            Logger.OnLog += CountLogs;
            Logger.Instance.Debug(LogSource.UI, "Login button clicked");
            Logger.Instance.Debug(LogSource.Client, "User logged in", ("Name", "Mr. Ali Hassan"));
            Logger.Instance.Debug(LogSource.UI, "Add phone number cliecked");
            Logger.Instance.Info(LogSource.Client, "User number added", ("Name", "Mr. Ali Hassan"), ("PhoneNumber", "+9821 2543331"));
            Logger.Instance.Debug(LogSource.UI, "Add national ID cliecked");
            Logger.Instance.Warn(LogSource.Client, "User national ID added", ("ID", "232-12-1212"));
            Logger.Instance.Debug(LogSource.UI, "Display error to user");
            Logger.Instance.Error(LogSource.Client, "Unable to add user", ("ID", "232-12-1212"));
            Console.WriteLine($"{DebugCount} Debugs, {WarnCount} Warnings, {InfoCount} Info, {ErrorCount} Errors");
        }
        public static void CountLogs(LogEntry logEntry)
        {
            DebugCount += logEntry.Level == LogLevel.Debug ? 1 : 0;
            WarnCount += logEntry.Level == LogLevel.Warn ? 1 : 0;
            InfoCount += logEntry.Level == LogLevel.Info ? 1 : 0;
            ErrorCount += logEntry.Level == LogLevel.Error ? 1 : 0;
        }
    }
}
