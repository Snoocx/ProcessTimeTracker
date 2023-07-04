using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTimeTracker.Models
{
    public class UntrackedProcess
    {
        public string Name { get; set; }
        public int PID { get; set; }
        public string Path { get; set; }
    }
}
