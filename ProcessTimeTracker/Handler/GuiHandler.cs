using ProcessTimeTracker.Models;
using ProcessTimeTracker.Services;

namespace ProcessTimeTracker.Handler
{
    public class GuiHandler
    {
        private ProcessService processService;
        private TrackerService trackerService;
        private TimerService timerService;

        public GuiHandler() {
            processService = new ProcessService();
            trackerService = new TrackerService();
            timerService = new TimerService(trackerService);
            timerService.Start();
        }

        public List<UntrackedProcess> GetUntrackedProcesses()
        {
            return processService.GetUntrackedProcesses();
        }

        public List<TrackedProcess> GetTrackedProcesses()
        {
            return trackerService.GetTrackedProcesses();
        }

        public void TrackProcessByListID(int trackid)
        {
            var trackProcess = processService.GetUntrackedProcesses().FirstOrDefault(e => e.ID == trackid);
            if (trackProcess != null)
                trackerService.TrackProcess(trackProcess);
        }
    }
}
