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
    /// alle Prozesse in eine Liste
    /// Liste ausgeben und Prozesse auswählen zum Tracken
    /// </summary>
    public class ProcessService
    {
        private List<UntrackedProcess> untrackedProcesses;

        public ProcessService()
        {
            LoadRunningProcesses();
            ShowRunningProcesses();
        }

        public void ShowRunningProcesses()
        {
            var allProcesses = GetUntrackedProcesses();

            foreach (var process in allProcesses)
            {
                Console.Write("#" + process.ID + " | ");
                Console.Write(process.Name + ": ");
                Console.WriteLine(process.Path);
            }
            Console.WriteLine("Count: " + allProcesses.Count());
            Console.WriteLine();
        }

        public void LoadRunningProcesses()
        {
            Console.Write("Loading");
            untrackedProcesses = new List<UntrackedProcess>();
            foreach (var process in Process.GetProcesses())
            {
                Console.Write(".");
                try
                {
                    var newProcess = new UntrackedProcess();
                    newProcess.ID = untrackedProcesses.Count() + 1;
                    newProcess.Name = process.ProcessName;
                    newProcess.Path = process.MainModule.FileName;

                    if (untrackedProcesses.FirstOrDefault(e => e.Name.Equals(newProcess.Name)) != null)
                        continue;

                    untrackedProcesses.Add(newProcess);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("");
        }

        public List<UntrackedProcess> GetUntrackedProcesses()
        {
            return untrackedProcesses;
        }
    }
}
