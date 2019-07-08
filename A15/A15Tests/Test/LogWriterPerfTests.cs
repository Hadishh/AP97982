using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Logger.Tests
{
    [TestClass()]
    public class LogWriterPerfTests
    {

        /* Threads Number:                  1         2       5      10      20      50       100
         * Locked Log Writer Time:        0.482     0.610   0.392   2.354   8.628   60.87   193.924
         * Concurrent Log Writee Time:    0.572     0.197   0.365   0.987   2.110   30.288  17.005 
         * Locked Queue Log Writer Time:  0.593     0.625   0.459   2.492   8.434   39.393  168.014
         * Concurrent log writer is faster because in locked log writer we use many threads to 
         * write on file and when a thread writing another threads can't access file till 
         * current thread finished but in concurrent writer class we have a cocurrent queue that all 
         * threads can add strings to it (like InterLock.Increment) and just one thread write strings in queue to file
         * so we need lock on queue and concurrent queue do this for us!
         */
        [TestMethod()]
        public void LockedLogWriterPerfTest()
        {
            var time = PerfTest<LockedLogWriter>(threadCount:25, linePerThread:1000);
        }
        
        [TestMethod()]
        public void ConcurrentLogWriterPerfTest()
        {
            var time = PerfTest<ConcurrentLogWriter>(threadCount: 25, linePerThread: 1000);
            
        }
        [TestMethod()]
        public void LockedQueueLogWriterPerfTest()
        {
            var time = PerfTest<LockedLogWriter>(threadCount: 25, linePerThread: 1000);
        }
        /// <summary>
        /// Becaue we have no lock on our threads and too many threads wants to access file and write on it. This means many text writes wants to access the file
        /// and if one writer (a) takes access to the file no other text writes can access to it till text writer a do it's work completely and Dispose.
        /// so when many text writers trying to access and they can't, it causes this exception !!
        /// </summary>
        //[TestMethod()]
        //public void NoLockPerfTest()
        //{
        //    var time = PerfTest<NoLockLogWriter>(threadCount: 25, linePerThread: 1000);
        //}

        private string PerfTest<_LogWriter>(int threadCount, int linePerThread)
            where _LogWriter: GuardedLogWriter, new()
        {
            string logDir = Path.GetTempFileName();
            File.Delete(logDir);
            string logPrefix = "sauleh_all";
            string time = string.Empty;
            using (FileLogger<_LogWriter> logger = new FileLogger<_LogWriter>(
                    XmlLogFormatter.Instance,
                    new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                    new TimeBasedLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
                    LogLevels.All,
                    LogSources.All,
                    false))
            {
                var threads = Enumerable.Range(0, threadCount)
                                        .Select(n => new Thread(
                                            new ThreadStart(() => LogRandomMessages(linePerThread, logger))))
                                        .ToList();

                Stopwatch sw = Stopwatch.StartNew();
                threads.ForEach(t => t.Start());
                threads.ForEach(t => t.Join());
                sw.Stop();

                time = sw.Elapsed.TotalSeconds.ToString();
                
            }

            int actualLogLines = CountLogLines(logDir, pattern: $"{logPrefix}*.{XmlLogFormatter.Instance.FileExtention}");

            Assert.AreEqual(linePerThread * threadCount + 2, actualLogLines); // plus 2 for header and footer

            return time;
        }

        private int CountLogLines(string logDir, string pattern)
        {
            return Directory.GetFiles(logDir, pattern).Sum(f => File.ReadAllLines(f).Length);
        }

        private void LogRandomMessages(int count, ILogger logger)
        {
            for (int i=0; i<count; i++)
            {
                LogEntry logEntry = new LogEntry(LogSource.Client, LogLevel.Debug,
                    $"student {i} created", ("FirstName", $"Pegah_{i}"), ("LastName", $"Ayati_{i}"));
                logger.Log(logEntry);
            }
        }
    }
}