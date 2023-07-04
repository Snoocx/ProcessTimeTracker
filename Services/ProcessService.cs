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
        public ProcessService() {
            var allProcesses = GetAllProcesses();

            foreach (var process in allProcesses)
            {
                Console.Write(process.Name + ": ");
                Console.WriteLine(process.Path);
            }
            Console.WriteLine("Count:" + allProcesses.Count());
        }

        public List<UntrackedProcess> GetAllProcesses()
        {
            Console.Write("Loading");
            var list = new List<UntrackedProcess>();
            foreach (var process in Process.GetProcesses())
            {
                Console.Write(".");
                try
                {
                    var newProcess = new UntrackedProcess();
                    newProcess.PID = process.Id;
                    newProcess.Name = process.ProcessName;
                    newProcess.Path = process.MainModule.FileName;

                    if (list.FirstOrDefault(e => e.Name.Equals(newProcess.Name)) != null)
                        continue;

                    list.Add(newProcess);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("");
            return list;
        }
    }
}
