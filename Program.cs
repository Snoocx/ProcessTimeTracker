using ProcessTimeTracker;
using ProcessTimeTracker.Services;

namespace ProcessTimeTracker;

internal class Program
{
    private static void Main(string[] args)
    {
        var processService = new ProcessService();
        var trackerService = new TrackerService();
        var timerService = new TimerService(trackerService);
        timerService.Start();

        var trackid = 0;
        do
        {
            Console.Write("Add ID to Track: ");
            trackid = Int32.Parse(Console.ReadLine());
            var trackProcess = processService.GetUntrackedProcesses().FirstOrDefault(e => e.ID == trackid);
            trackerService.TrackProcess(trackProcess);
        } while (trackid != 0);
    }
}