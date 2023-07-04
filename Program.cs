using ProcessTimeTracker;
using ProcessTimeTracker.Services;

namespace ProcessTimeTracker;

internal class Program
{
    private static void Main(string[] args)
    {
        var timerService = new TimerService();
        timerService.Start();

        Console.ReadKey(); 
    }
}