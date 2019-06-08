using System;
using System.IO;

namespace A13
{

    public class SingleFileWatcher: IDisposable
    {
        private FileSystemWatcher Watcher;

        private Action DoingWork;
        public SingleFileWatcher(string filePath)
        {
           
            Watcher = new FileSystemWatcher(Path.GetDirectoryName(filePath), Path.GetFileName(filePath));
            Watcher.Changed += Watcher_Changed;
            Watcher.EnableRaisingEvents = true;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if(DoingWork != null)
                DoingWork();
            return;
        }

        public void Register(Action action)
        {
            DoingWork += action;
            return;
        }
        public void Unregister(Action action)
        {
            DoingWork -= action;
            return;
        }
		public void Dispose()
        {
            Watcher.Dispose();
            return;
        }
    }
}