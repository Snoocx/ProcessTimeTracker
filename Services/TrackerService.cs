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

            var teams = new TrackedProcess();
            teams.Name = "Teams";
            teams.PID = 0;
            teams.RunningTime = 0;

            trackedProcesses.Add(teams);
        }

        public void TrackProcess(UntrackedProcess process) { }
        public void UntrackProcess(TrackedProcess process) { }
        public List<TrackedProcess> GetTrackedProcesses() {
            return trackedProcesses;
        }
    }
}
