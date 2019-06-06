using System;
using System.Threading;

namespace A13
{
    public class SingleReminderThreadPool : ISingleReminder
    {
        public int Delay { get; set; }
        public string Msg { get; set; }
        public  event Action<string> Reminder;
        public SingleReminderThreadPool(string msg, int delay)
        {
            Msg = msg;
            Delay = delay;
        }
        public void Start()
        {
            foreach(var item in Reminder.GetInvocationList())
            {
                ThreadPool.QueueUserWorkItem((o) => {
                    string msg = (string)o;
                    item.DynamicInvoke(msg);
                    Thread.Sleep(Delay);
                }, Msg);
            }
            return;
        }
    }
}