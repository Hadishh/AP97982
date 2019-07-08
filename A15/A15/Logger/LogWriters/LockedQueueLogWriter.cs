using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Logger
{
    class LockedQueueLogWriter : GuardedLogWriter
    {
        protected Queue<string> WriterQueue = new Queue<string>();
        private bool Disposed = false;
        public LockedQueueLogWriter(TextWriter writer)
            : base(writer)
        {
            Thread queueHandler = new Thread(new ThreadStart(WriteOnFile));
            queueHandler.Start();
        }

        public override GuardedLogWriter CreateInstance(TextWriter writer)
            => new LockedQueueLogWriter(writer);

        protected void WriteOnFile()
        {
            while (!Disposed)
            {
                string s;
                lock (this)
                {
                    if ((s = WriterQueue.Dequeue()) != null)
                    {
                        Writer.WriteLine(s);
                    }
                }
            }
        }

        public override void Dispose()
        {
            lock (this)
            {
                Writer.Dispose();
            }
            Disposed = true;
        }

        public override void WriteLine(string line)
        {
            lock (this)
            {
                WriterQueue.Enqueue(line);
            }
        }
    }
}
