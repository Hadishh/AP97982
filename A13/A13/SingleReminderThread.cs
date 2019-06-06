using System;
using System.Threading;

namespace A13
{
    public class SingleReminderThread : ISingleReminder
    {

        Thread ReminderThread = null;

        public int Delay { get; set; }

        public string Msg { get; set; }

        public event Action<string> Reminder;

        public SingleReminderThread(string msg, int delay)
        {
            Msg = msg;
            Delay = delay;
        }
        public void Start()
        {
            foreach(var func in Reminder.GetInvocationList())
            {
                ReminderThread = new Thread(() => func.DynamicInvoke(Msg));
                ReminderThread.Start();
                ReminderThread.Join();
                Thread.Sleep(Delay);
            }
            return;
        }
    }
}   