using ProcessTimeTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTimeTracker.Handler
{
    public class ConsoleHandler
    {
        private ProcessService processService;
        private TrackerService trackerService;
        private TimerService timerService;

        public ConsoleHandler() {
            processService = new ProcessService();
            trackerService = new TrackerService();
            timerService = new TimerService(trackerService);
            timerService.Start();

            do
            {
                Console.Write("Add ID to Track: ");
                var trackid = Int32.Parse(Console.ReadLine());
                if (trackid == 0)
                    break;
                TrackProcessByListID(trackid);
            } while (true);
        }

        private void TrackProcessByListID(int trackid)
        {
            var trackProcess = processService.GetUntrackedProcesses().FirstOrDefault(e => e.ID == trackid);
            if(trackProcess != null)
                trackerService.TrackProcess(trackProcess);
        }
    }
}
