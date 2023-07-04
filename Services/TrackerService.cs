using ProcessTimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTimeTracker.Services
{
    /// <summary>
    /// Prozesse werden hier zur Liste hinzugefügt um getrackt zu werden.
    /// </summary>
    public class TrackerService
    {
        private List<TrackedProcess> trackedProcesses;
        public TrackerService()
        {
            trackedProcesses = new List<TrackedProcess>();
        }

        public void TrackProcess(UntrackedProcess process) {
            var trackedProcess = new TrackedProcess();
            trackedProcess.Name = process.Name;
            trackedProcess.ID = process.ID;
            trackedProcess.RunningTime = 0;
            trackedProcesses.Add(trackedProcess);
        }
        public void UntrackProcess(TrackedProcess process) {
            trackedProcesses.Remove(process);
        }
        public List<TrackedProcess> GetTrackedProcesses() {
            return trackedProcesses;
        }
    }
}
