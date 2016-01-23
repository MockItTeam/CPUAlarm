using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CPUAlarm
{
    class Watcher
    {
        private PerformanceCounter cpuCounter;
        private int cpuThreshold;
        private Mailer mailer;
        private Timer timer;
        private readonly int TOLERANCE = 10;
        private int count;
        public Watcher(Timer timer, int cpuThreshold)
        {
            this.timer = timer;
            this.cpuThreshold = cpuThreshold;
            this.count = 0;
           
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            mailer = new Mailer();
            Console.WriteLine("Watcher started at: " + DateTime.Now);
            Console.WriteLine("Alert if CPU running lower than " + cpuThreshold + "%");
        }

        public void watch(Object source, ElapsedEventArgs e)
        {
            float percent = cpuCounter.NextValue();
            Console.Write((int)percent + "\t");
            if (percent < cpuThreshold)
            {
                count++;
                if (count > 10)
                {
                    DateTime now = DateTime.Now;
                    mailer.mail("CPU Usage Warning", "CPU running at " + percent + "%\nSystem time: " + now);
                    Console.WriteLine("\nWatcher terminated at: " + now);
                    timer.Enabled = false;
                }
            }
        }
    }
}
