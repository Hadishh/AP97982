using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E2
{

    public static class Threading
    {
        public static void MakeItFaster(params Action[] actions)
        {
            List<Task> allTasks = new List<Task>();
            foreach(var action in actions)
            {
                Task task = new Task(action);
                task.Start();
                allTasks.Add(task);
            }
            Task.WaitAll(allTasks.ToArray());

        }
    }
}