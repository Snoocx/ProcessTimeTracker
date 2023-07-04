using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTimeTracker.Models
{
    public class TrackedProcess : UntrackedProcess
    {
        public double RunningTime { get; set; }
    }
}
