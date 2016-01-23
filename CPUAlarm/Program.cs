using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CPUAlarm
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int minuteInterval = 1;
            Console.WriteLine("Inverval: " + minuteInterval + " minutes");
            Timer timer = new Timer();
            Watcher watcher = new Watcher(timer, 25);
            timer.Elapsed += watcher.watch;
            timer.Interval = minuteInterval * 60 * 1000;
            timer.Enabled = true;
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }



    }
}
