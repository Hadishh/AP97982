using System;
using System.Threading;
using System.Threading.Tasks;

namespace A13
{
    public class SingleReminderTask : ISingleReminder
    {
        Task ReminderTask = null;

        public int Delay { get; set; }

        public string Msg { get; set; }

        public event Action<string> Reminder;

        public SingleReminderTask(string msg, int delay)
        {
            Msg = msg;
            Delay = delay;
        }        
        public void Start()
        {
            foreach(var item in Reminder.GetInvocationList())
            {
                ReminderTask = new Task(() => {
                    item.DynamicInvoke(Msg);
                    Thread.Sleep(Delay);
                });
                ReminderTask.Start();
                ReminderTask.Wait();
                
            }
        }
    }
}