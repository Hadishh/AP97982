using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class XsvFormatter : ILogFormatter
    {
        protected char Separator;

        public XsvFormatter(char separator)
        {
            Separator = separator;
        }
        /// <summary>
        /// joins each header with separated character
        /// </summary>
        public string Header => string.Join(Separator.ToString(), "level", " date", " source", " threadId", " ProcessId", " message", " name: value pairs");

        public string Footer => string.Empty;

        public virtual string FileExtention => null;
        /// <summary>
        /// Format line for writing on streamer
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public string Format(LogEntry entry)
            =>  string.Join(Separator.ToString(), 
                $"{entry.Level.ToString()}", 
                $"{entry.DateTime.ToString()}", 
                $"{entry.Source.ToString()}",
                $"{entry.ThreadId.ToString()}", 
                $"{entry.ProcessId}", $"{entry.Message}",
                string.Join(Separator.ToString(), entry.NameValuePairs.Select(v => $"'{v.name}':'{v.value}'")));
    }
}
