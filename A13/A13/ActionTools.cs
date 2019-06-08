using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace A13
{
    public static class ActionTools
    {
        public static long CallSequential(params Action[] actions)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach(var item in actions)
            {
                Task task = new Task(item);
                task.Start();
                task.Wait();
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        public static long CallParallel(params Action[] actions)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            List<Task> allTasks = new List<Task>();
            foreach (var item in actions)
            {
                Task task = new Task(item);
                task.Start();
                allTasks.Add(task);
            }
            Task.WaitAll(allTasks.ToArray());
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for(int i = count; i > 0; i--)
            {
                List<Task> allTasks = new List<Task>();
                object synchronizer = new object();
                foreach (var action in actions)
                {
                    Task task = new Task(() =>
                    {
                        lock (synchronizer)
                        {
                            action();
                        }
                        
                    });
                    task.Start();
                    allTasks.Add(task);
                }
                Task.WaitAll(allTasks.ToArray());
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach(var action in actions)
            {
                await Task.Run(action);
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            List<Task> allTasks = new List<Task>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach(var action in actions)
            {
                Task t = new Task(action);
                allTasks.Add(t);
                t.Start();
            }
            await Task.WhenAll(allTasks.ToArray());
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = count; i > 0; i--) 
            {
                List<Task> allTasks = new List<Task>();
                object synchronizer = new object();
                foreach(var action in actions)
                {
                    Task task = new Task(() =>
                    {
                        lock (synchronizer)
                        {
                            action();
                        }
                    });
                    allTasks.Add(task);
                    task.Start();
                }
                await Task.WhenAll(allTasks.ToArray());
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
    }
}