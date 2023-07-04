using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ProcessTimeTracker.Services
{
    /// <summary>
    /// Wird sekündlich aktualisiert und schaut nach den Prozessen gelistet im TrackerService
    /// </summary>
    public class TimerService
    {

        private ProcessService processService;
        private TrackerService trackerService;
        private Timer timer;

        public TimerService()
        {
            processService = new ProcessService();
            trackerService = new TrackerService();
            timer = new Timer(1000);
        }

        public void Start() {
            timer.Elapsed += TimeElapsed;
            timer.Start();
            Console.WriteLine("Timer started..");
        }

        public void Stop() { 
            timer.Stop();
            timer.Dispose();
        }

        private void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var process in trackerService.GetTrackedProcesses())
            {
                //jede Sek. nach der ID schauen ob sie noch aktiv ist, wenn nicht Zeit nicht mehr hochzählen etc.
                if (Process.GetProcessesByName(process.Name) != null)
                {
                    process.RunningTime++;
                    Console.WriteLine(process.Name + " tracked + 1sek. Total Time Running: " + process.RunningTime);
                }
            }
        }
    }
}
