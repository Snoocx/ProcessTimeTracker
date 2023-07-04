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
        private TrackerService trackerService;
        private Timer timer;

        public TimerService(TrackerService trackerService)
        {
            this.trackerService = trackerService;
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
            //jede Sek. nach der ID schauen ob sie noch aktiv ist, wenn nicht Zeit nicht mehr hochzählen etc.
            foreach (var process in trackerService.GetTrackedProcesses())
            {
                var runningProcesses = Process.GetProcessesByName(process.Name);
                foreach(var runningProcess in runningProcesses)
                {
                    if (!runningProcess.HasExited)
                    {
                        process.RunningTime++;
                        if(process.RunningTime % 20 == 0)
                            Console.WriteLine($"{process.Name} tracked.. Total Time Running: {process.RunningTime} seconds.");
                        break;
                    }
                }
            }
        }
    }
}
