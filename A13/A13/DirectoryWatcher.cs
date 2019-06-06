using System;
using System.IO;

namespace A13
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        private Action<string> CreatedActions;
        private Action<string> DeletedActions;
        private FileSystemWatcher Watcher;
        public DirectoryWatcher(string dirPath)
        {
            Watcher = new FileSystemWatcher(dirPath);
            Watcher.EnableRaisingEvents = true;
            Watcher.Created += Watcher_Created;
            Watcher.Deleted += Watcher_Deleted;
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if(DeletedActions != null)
                DeletedActions(e.FullPath);
            return;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            if(CreatedActions != null)
                CreatedActions(e.FullPath);
            return;
        }
        public void Register(Action<string> action, ObserverType observer)
        {
            if (observer == ObserverType.Create)
                CreatedActions += action;
            else
                DeletedActions += action;
        }
        public void Unregister(Action<string> action, ObserverType observer)
        {
            if (observer == ObserverType.Create)
                CreatedActions -= action;
            else
                DeletedActions -= action;
        }
        public void Dispose()
        {
            Watcher.Dispose();
            return;
        }
    }
}