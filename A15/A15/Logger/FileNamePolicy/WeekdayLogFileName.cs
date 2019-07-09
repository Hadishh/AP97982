using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    public class WeekdayLogFileName : LogFileNamePolicy
    {
        public WeekdayLogFileName(string logDir, string logPrefix, string logExt) 
            : base(logDir, logPrefix, logExt) { }
        /// <summary>
        /// Generate next Day File Name
        /// </summary>
        /// <returns></returns>
        public override string NextFileName()
         => Path.Combine(LogDir, $"{LogPrefix}_{DateTime.Today.DayOfWeek.ToString()}.{LogExt}");

    }
}
